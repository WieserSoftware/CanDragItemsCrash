using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    public static class ListExtensions 
    {
        public static List<T> Shuffle<T>(this List<T> src)
        {
            int x = src.Count;
            List<T> dest = new List<T>(x);
            int [] idx = new int[src.Count];
            Random rng = new Random();
            for (int i = 0; i < x; i++) idx[i] = i;
            
            while (x > 0)
            {
                int sel = rng.Next(x);
                x--;
                dest.Add(src[idx[sel]]);
                idx[sel] = idx[x];                
            }
            return dest;
        }
    }

    public class Item
    {
        public int Value { get; set; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Item> items;

        public MainPage()
        {
            items = new List<Item>(100);
            for (int i = 0; i < 100; i++)
            {
                items.Add(new Item() { Value = i });
            }
            this.InitializeComponent();
            CVS.Source = items;
            
        }

        private void Catastrophe(object sender, DoubleTappedRoutedEventArgs e)
        {
            var newItems = items.Shuffle();
            CVS.Source = newItems;
        }
    }
}
