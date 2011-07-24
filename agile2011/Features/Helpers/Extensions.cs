﻿using System;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Common.Tests;
using UltimateSoftware.Foundation.Services.Acceptance.Tests;
using Environment = System.Environment;

namespace Features 
{
    public static class Extensions 
    {
        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static void ForEach<T>(this IEnumerable<T> Items, Action<T> Do)
        {
            foreach (var Item in Items) Do(Item);
        }

        public static string CamelCase(this string Words) 
        {
            return Words.Split(new [] {' '})
                .Aggregate(string.Empty, (Result, Current) => 
                    Result + Current.Capitalize());
        }

        public static string Ln(this string Line) 
        {
            return Line + Environment.NewLine;
        }

        public static string Capitalize(this string Word)
        {
            if (string.IsNullOrEmpty(Word)) return Word;

            return Word[0].ToString().ToUpperInvariant() + Word.Substring(1);
        }

        public static bool Matches(this object Expected, object Actual)
        {
            return Expected.GetType().GetProperties()
                .Where(x => x.PropertyType.IsSimple() 
                    && Expected.Get(x).HasValue())
                .All(x => Actual.Get(x).IsEqualTo(Expected.Get(x)));
        }

        public static bool IsEqualTo(this object One, object Another)
        {
            return 
                One is decimal ? Math.Abs((decimal)One - (decimal)Another) < 1 :
                One.Equals(Another);
        }

        public static string Join(this IEnumerable<string> Values, string Separator) 
        {
            return String.Join(Separator, Values);
        }

        public static bool IsSimple(this Type Type)
        {
            return Type.Equals(typeof(string)) 
                || Type.IsValueType 
                || Type.IsPrimitive;
        }

        public static string NotFoundIn(this object O, IEnumerable<object> Objects)
        {
            return 
                "Could not find " + O.GetType().Name.Ln() + 
                    O.AsString().Ln() +
                O.GetType().Name.Pluralize() + " found (" + Objects.Count() + "): ".Ln() + 
                    Objects.Select((x, i) => (i+1) + ". " + x.AsString()).Join("".Ln());
        }

        public static void ShouldContain(this IEnumerable<object> Items, object Item)
        {
            if (Items.Any(Item.Matches)) return;
            
            Assert.Fail(Item.NotFoundIn(Items));
        }

        public static void ShouldMatch(this object One, object Another)
        {
            if (One.Matches(Another)) return;
            
            Assert.Fail(
                "Expected: " + One.AsString().Ln() +
                "Actual: " + Another.AsString().Ln());
        }

        public static string AsString(this object O)
        {
            return 
                "[ " + 
                O.GetType().GetProperties()
                .Where(x => x.PropertyType.IsSimple() 
                    && O.Get(x).HasValue())
                .Select(x => x.Name + ": " + O.Get(x))
                .Join(", ") + 
                " ]";
        }

        public static void Update(this object Expected, object Actual)
        {
            Expected.GetType().GetProperties()
                .Where(x => x.CanRead && Expected.Get(x).HasValue())
                .ForEach(x => Actual.Set(x, Expected.Get(x)));
        }

        public static bool HasValue(this object O)
        {
            return 
                O is string ? (O as string).HasValue() :
                O is DateTime ? (DateTime)O != default(DateTime) :
                O is decimal ? (decimal) O != 0 :
                O != null;
        }

        public static bool HasValue(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        public static string Name(this object O)
        {
            return O.Get("FirstName") + " " + O.Get("LastName");
        }
    }
}
