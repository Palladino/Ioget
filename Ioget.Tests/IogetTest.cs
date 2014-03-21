﻿using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Ioget.Tests
{
    [TestFixture]
    public class IogetTest
    {
        [Test]
        public void ShouldContructObjectWithParamenterString()
        {
            var dic = new Dictionary<string, string>
            {
                {"f1", "a"},
            };

            var myObject = new Instantiator().Bind(dic, typeof(My<string>));
            Assert.AreEqual(My.Create("a"), myObject);
        }

        [Test]
        public void ShouldContructObjectWithParameterInt()
        {
            var dic = new Dictionary<string, string>
            {
                {"f1", "1"}
            };

            var myObject = new Instantiator().Bind(dic, typeof(My<int>));
            Assert.AreEqual(My.Create(1), myObject);
        }

        [Test]
        public void ShouldContructObjectWithParameterLong()
        {
            var dic = new Dictionary<string, string>
            {
                {"f1", "1"}
            };

            var myObject = new Instantiator().Bind(dic, typeof(My<long>));
            Assert.AreEqual(My.Create(1L), myObject);
        }

        [Test]
        public void ShouldWorkWithTuples()
        {
            var dic = new Dictionary<string, string>
            {
                {"item1", "a"}
            };

            var myObject = new Instantiator().Bind(dic, typeof(Tuple<string>));
            Assert.AreEqual(new Tuple<string>("a"), myObject);
        }
    }

    public struct My<T>
    {
        private readonly T f1;
        public My(T f1)
        {
            this.f1 = f1;
        }

    }
    public static class My
    {
        public static My<T> Create<T>(T t) { return new My<T>(t); }
    }

}