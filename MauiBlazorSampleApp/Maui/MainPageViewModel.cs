using DependencyInjectionMauiBlazor;
using MauiBlazorSampleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiBlazorSampleApp
{
    public class MainPageViewModel : ViewModel
    {
        public TestSingletonService Testeur { get; } 
        public MainPageViewModel()
        {
            Testeur = Resolver.ServiceProvider.GetRequiredService<TestSingletonService>();
        }

        private ICommand _counterIncrementCommand;
        public ICommand CounterIncrementCommand => _counterIncrementCommand ??= new Command(CounterIncrement);

        private void CounterIncrement()
        {
            Testeur.Counter++;
        }
    }
}
