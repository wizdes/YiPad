using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragablz;

namespace PadTest1
{
    public class MainWindowViewModel
    {
        private readonly IInterTabClient _interTabClient;
        private readonly ObservableCollection<TabContent> _tabContents = new ObservableCollection<TabContent>();

        private static int numDocs;
        public static TabContent tabby;

        public MainWindowViewModel()
        {
            _interTabClient = new DefaultInterTabClient();
            numDocs = 1;
        }

        public static MainWindowViewModel CreateInitView()
        {
            var result = new MainWindowViewModel();

            var tab = new TabContent("Untitled-" + numDocs++, new TextControl());
            tabby = tab;
            result.TabContents.Add(tab);

            return result;
        }

        public ObservableCollection<TabContent> TabContents
        {
            get { return _tabContents; }
        }

        public IInterTabClient InterTabClient
        {
            get { return _interTabClient; }
        }

        public static Func<object> NewItemFactory
        {
            get { return () => new TabContent("Untitled-" + numDocs++, new TextControl()); }
        }
    }
}
