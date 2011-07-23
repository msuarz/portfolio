using System;
using System.Collections.Generic;
using System.Linq;
using UltimateSoftware.Foundation.Services.Common.Tests;
using Environment = System.Environment;

namespace Features 
{
    public static class Extensions 
    {
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
                .All(x => Actual.Get(x).Equals(Expected.Get(x)));
        }

        public static string Join(this IEnumerable<string> Values, string Separator) 
        {
            return String.Join(Separator, Values);
        }

        public static bool IsSimple(this Type Type)
        {
            return Type.IsPrimitive || Type.Equals(typeof(string));
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
