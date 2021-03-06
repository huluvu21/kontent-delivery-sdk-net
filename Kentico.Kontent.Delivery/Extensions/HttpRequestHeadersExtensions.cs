﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection;

namespace Kentico.Kontent.Delivery.Extensions
{
    internal static class HttpRequestHeadersExtensions
    {
        private const string SdkTrackingHeaderName = "X-KC-SDKID";
        private const string WaitForLoadingNewContentHeaderName = "X-KC-Wait-For-Loading-New-Content";
        private const string ContinuationHeaderName = "X-Continuation";

        private const string PackageRepositoryHost = "nuget.org";
        
        private static readonly Lazy<string> SdkVersion = new Lazy<String>(GetSdkVersion);
        private static readonly Lazy<string> SdkPackageId = new Lazy<String>(GetSdkPackageId);


        internal static void AddSdkTrackingHeader(this HttpRequestHeaders header)
        {
            header.Add(SdkTrackingHeaderName, $"{PackageRepositoryHost};{SdkPackageId.Value};{SdkVersion.Value}");
        }

        internal static void AddWaitForLoadingNewContentHeader(this HttpRequestHeaders header)
        {
            header.Add(WaitForLoadingNewContentHeaderName, "true");
        }

        internal static void AddAuthorizationHeader(this HttpRequestHeaders header, string scheme, string parameter)
        {
            header.Authorization = new AuthenticationHeaderValue(scheme, parameter);
        }

        internal static void AddContinuationHeader(this HttpRequestHeaders header, string continuation)
        {
            header.Add(ContinuationHeaderName, continuation);
        }

        private static string GetSdkVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string sdkVersion;

            try
            {
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                sdkVersion = fileVersionInfo.ProductVersion;
            }
            catch (FileNotFoundException)
            {
                // Invalid Location path of assembly in Android's Xamarin release mode (unchecked "Use a shared runtime" flag)
                // https://bugzilla.xamarin.com/show_bug.cgi?id=54678
                sdkVersion = "0.0.0";
            }

            return sdkVersion;
        }

        private static string GetSdkPackageId()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sdkPackageId = assembly.GetName().Name;

            return sdkPackageId;

        }
    }
}
