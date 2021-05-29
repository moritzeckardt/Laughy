//using BottomBar.Droid;
//using System.Collections.ObjectModel;
//using Xamarin.Forms;

//namespace Laughy.Droid.Utils
//{
//    public class PageController : IPageController
//    {
//		//Fields
//		private ReflectedProxy<Page> _proxy;


//		//Methods
//		public Rectangle ContainerArea
//		{
//			get
//			{
//				return _proxy.GetPropertyValue<Rectangle>();
//			}

//			set
//			{
//				_proxy.SetPropertyValue(value);
//			}
//		}

//		public bool IgnoresContainerArea
//		{
//			get
//			{
//				return _proxy.GetPropertyValue<bool>();
//			}

//			set
//			{
//				_proxy.SetPropertyValue(value);
//			}
//		}

//		public ObservableCollection<Element> InternalChildren
//		{
//			get
//			{
//				return _proxy.GetPropertyValue<ObservableCollection<Element>>();
//			}

//			set
//			{
//				_proxy.SetPropertyValue(value);
//			}
//		}


//		//Constructor
//		PageController(Page page)
//		{
//			_proxy = new ReflectedProxy<Page>(page);
//		}


//		//Methods
//		public static IPageController Create(Page page)
//		{
//			return new PageController(page);
//		}

//		public void SendAppearing()
//		{
//			_proxy.Call();
//		}

//		public void SendDisappearing()
//		{
//			_proxy.Call();
//		}
//	}
//}