using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace WPFDemo.ViewModel
{
    [DoNotNotify] // Fody.PropertyChanged is disabled
    public class MainViewModel : ViewModelBase
    {
        private bool _isExpand = true;

        public string Title { get; set; }

        public ICommand MyButtonCommand { get; }
        public ICommand TreeExpandCommand { get; }
        public ICommand TreeExpand2Command { get; }
        public ICommand TreeExpandFodyCommand { get; }
        public ICommand MouseRightButtonDownCommand { get; }

        public bool IsChecked { get; set; } = false;

        public NodeViewModel Node { get; set; } = new NodeViewModel();
        public Node2ViewModel Node2 { get; set; } = new Node2ViewModel();
        public NodeFodyViewModel NodeFody { get; set; } = new NodeFodyViewModel();

        public ObservableCollection<NodeMvvmViewModel> TreeNodes { get; set; } = new ObservableCollection<NodeMvvmViewModel>();
        public ObservableCollection<NodeMvvmViewModel> TreeNodes2 { get; set; } = new ObservableCollection<NodeMvvmViewModel>();
        public ObservableCollection<NodeFodyViewModel> TreeNodesFody { get; set; } = new ObservableCollection<NodeFodyViewModel>();

        public MainViewModel()
        {
            Title = "Hello MVVM Light" + (IsInDesignMode ? " (Design Mode)" : string.Empty);

            MyButtonCommand = new RelayCommand(() => MyButtonClick());
            TreeExpandCommand = new RelayCommand(() => TreeExpandClick());
            TreeExpand2Command = new RelayCommand(() => TreeExpand2Click());
            TreeExpandFodyCommand = new RelayCommand(() => TreeExpandFodyClick());
            MouseRightButtonDownCommand = new RelayCommand(() => MouseRightButtonDownClick());

            TreeNodes.Add(PopulateTreeItems(defaultExpand: _isExpand));
            TreeNodes2.Add(PopulateTreeItems(defaultExpand: _isExpand));
            TreeNodesFody.Add(PopulateTreeItemsFody(defaultExpand: _isExpand));
        }

        private void MyButtonClick()
        {
            IsChecked = !IsChecked;
            RaisePropertyChanged(() => IsChecked);

            Node.IsExpanded = !Node.IsExpanded;

            Node2.IsExpanded = !Node2.IsExpanded;
        }

        private void TreeExpandClick()
        {
            //TreeNodes.First().IsExpanded = false;
            //RaisePropertyChanged(() => TreeNodes);

            TreeNodes.Clear();
            _isExpand = !_isExpand;
            TreeNodes.Add(PopulateTreeItems(defaultExpand: _isExpand));
            RaisePropertyChanged(() => TreeNodes);
        }

        private void TreeExpand2Click()
        {
            _isExpand = !_isExpand;
            Traverse(TreeNodes2.First(), _isExpand);
        }

        private void TreeExpandFodyClick()
        {
            _isExpand = !_isExpand;
            TraverseFody(TreeNodesFody.First(), _isExpand);
        }

        private void MouseRightButtonDownClick()
        {
            MessageBox.Show("MouseRightButtonDownClick");
        }



        private NodeMvvmViewModel PopulateTreeItems(bool defaultExpand)
        {
            var rootNode = new NodeMvvmViewModel { Name = "Root", IsExpanded = defaultExpand };
            var child2Node = new NodeMvvmViewModel { Name = "Child 2", IsExpanded = defaultExpand };
            child2Node.InnerItems.Add(new NodeMvvmViewModel { Name = "SubChild" });
            rootNode.InnerItems.Add(new NodeMvvmViewModel { Name = "Child 1", IsExpanded = defaultExpand });
            rootNode.InnerItems.Add(child2Node);

            return rootNode;
        }

        private void Traverse(NodeMvvmViewModel root, bool isExpanded)
        {
            TraverseNode(root, isExpanded);
        }

        private void TraverseNode(NodeMvvmViewModel node, bool isExpanded)
        {
            if (node == null)
                return;

            node.IsExpanded = isExpanded;

            foreach (var innerItem in node.InnerItems)
            {
                TraverseNode(innerItem, isExpanded); // Recursive call for each child item
            }
        }


        private NodeFodyViewModel PopulateTreeItemsFody(bool defaultExpand)
        {
            var rootNode = new NodeFodyViewModel { Name = "Root", IsExpanded = defaultExpand };
            var child2Node = new NodeFodyViewModel { Name = "Child 2", IsExpanded = defaultExpand };
            child2Node.InnerItems.Add(new NodeFodyViewModel { Name = "SubChild" });
            rootNode.InnerItems.Add(new NodeFodyViewModel { Name = "Child 1", IsExpanded = defaultExpand });
            rootNode.InnerItems.Add(child2Node);

            return rootNode;
        }

        private void TraverseFody(NodeFodyViewModel root, bool isExpanded)
        {
            TraverseFodyNode(root, isExpanded);
        }

        private void TraverseFodyNode(NodeFodyViewModel node, bool isExpanded)
        {
            if (node == null)
                return;

            node.IsExpanded = isExpanded;

            foreach (var innerItem in node.InnerItems)
            {
                TraverseFodyNode(innerItem, isExpanded); // Recursive call for each child item
            }
        }
    }
}