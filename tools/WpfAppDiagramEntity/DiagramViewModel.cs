using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace WpfAppDiagramEntity
{
    public class DiagramViewModel
    {
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        private SourceCache<ComponentViewModel, string> componentCache;
        private readonly ReadOnlyObservableCollection<ComponentViewModel> _items;

        public DiagramViewModel(IEnumerable<ComponentViewModel> componentViewModels)
        {
            componentCache = new SourceCache<ComponentViewModel, string>(x => x.Text);
            componentCache.AddOrUpdate(componentViewModels);
            componentCache
                .Connect()
                .ObserveOnDispatcher()
                .Bind(out _items)
                .Subscribe()
                .DisposeWith(disposables);
                        
        }

        public ReadOnlyObservableCollection<ComponentViewModel> Items => _items;

        public int Width => Items.Max(x => x.X + x.Size);
        public int Height => Items.Max(x => x.Y + x.Size);
    }

    public class ComponentViewModel
    {
        public int X { get; init; }
        public int Y { get; init; }
        public int Size { get; init; }        
        public string Text { get; init; }
    }
}
