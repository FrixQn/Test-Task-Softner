using System.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;

namespace TestProject.Extensions
{
    public static class AsyncExtensions
    {
        private static System.Collections.Generic.Dictionary<CancellationToken, CancellationTokenSource> _tokenSource = new();

        [RuntimeInitializeOnLoadMethod]
        private static void OnInitialize()
        {
            Application.quitting += EndAllTasks;
        }

        public static AxGrid.Model.DynamicModel SetDelayed(this AxGrid.Model.DynamicModel model, float delay, string name, object value)
        {
            var source = new CancellationTokenSource();
            _tokenSource.Add(source.Token, source);
            InvokeWithDelay(model, delay, name, value, source.Token);
            return model;
        }

        private static async void InvokeWithDelay(AxGrid.Model.DynamicModel model, float delay, string name, object value, CancellationToken token)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(delay), token);
                model.Set(name, value);
                _tokenSource.Remove(token);
            }
            catch (TaskCanceledException)
            {
                return;
            }
        }

        private static void EndAllTasks()
        {
            foreach (var source in _tokenSource.Values)
            {
                source.Cancel();
                source.Dispose();
            }

            _tokenSource.Clear();
            Application.quitting -= EndAllTasks;
        }
    }
}

