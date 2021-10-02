using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiBlazorSampleApp.Services
{
    public class TestSingletonService : ViewModel
    {
        private static int _staticIndex = 0;
        public int Index { get; set; }

        private int _counter;
        public int Counter { get => _counter; set { SetProperty(ref _counter, value); } }

        public TestSingletonService()
        {
            Index = _staticIndex++;
        }
    }
}
