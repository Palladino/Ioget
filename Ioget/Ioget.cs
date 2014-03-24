﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ioget
{
    public class Instantiator
    {
        private readonly List<Conversion<object>> convertions; 

        public Instantiator()
        {
            convertions = new List<Conversion<object>>
            {
                new ByteConversion(),
                new ShortConversion(),
                new IntConversion(), 
                new LongConversion(),
                new FloatConversion(),
                new DoubleConversion(),
                new BooleanConversion(),
                new StringConversion(),
                new EnumConversion(),
                new CharConversion(),
                new ConversionNotFound(),
            };
        }

        public object Bind(Dictionary<string, string> dic, Type type)
        {
            var constructor = type.GetConstructors().First();
            var parameters = constructor.GetParameters().Select(p => ResolveType(p, dic[p.Name]));
            return constructor.Invoke(parameters.ToArray());
        }

        private object ResolveType(ParameterInfo info, string value)
        {
            return convertions.First(c => c.IsApplicable(info)).Apply(info, value);
        }
    }
}
