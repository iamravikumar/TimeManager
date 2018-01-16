﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public class InvariantDecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.Metadata.IsComplexType && (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?)))
            {
                return new InvariantDecimalModelBinder(context.Metadata.ModelType);
            }

            return null;
        }
    }

    public class InvariantDecimalModelBinder : IModelBinder
    {
        private readonly SimpleTypeModelBinder _baseBinder;

        public InvariantDecimalModelBinder(Type modelType)
        {
            _baseBinder = new SimpleTypeModelBinder(modelType);
        }
   

        System.Threading.Tasks.Task IModelBinder.BindModelAsync(ModelBindingContext bindingContext)
        {
                if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));

                var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

                if (valueProviderResult != ValueProviderResult.None)
                {
                    bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                    var valueAsString = valueProviderResult.FirstValue;
                    decimal result;

                    // Use invariant culture
                    if (decimal.TryParse(valueAsString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result))
                    {
                        bindingContext.Result = ModelBindingResult.Success(result);
                        return System.Threading.Tasks.Task.CompletedTask;
                    }
                }

                // If we haven't handled it, then we'll let the base SimpleTypeModelBinder handle it
                return _baseBinder.BindModelAsync(bindingContext);
            }
        }
}
