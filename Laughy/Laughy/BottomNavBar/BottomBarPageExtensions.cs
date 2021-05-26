//using Xamarin.Forms;

//namespace Laughy.BottomNavBar
//{
//    public static class BottomBarPageExtensions
//    {
//        //Bindable properties
//        public static readonly BindableProperty TabColorProperty = BindableProperty.CreateAttached(
//                "TabColor",
//                typeof(Color),
//                typeof(BottomBarPageExtensions),
//                Color.Transparent);

//        public static readonly BindableProperty BadgeCountProperty = BindableProperty.CreateAttached(
//            "BadgeCount",
//            typeof(int),
//            typeof(BottomBarPageExtensions),
//            0);

//        public static readonly BindableProperty BadgeColorProperty = BindableProperty.CreateAttached(
//            "BadgeColor",
//            typeof(Color),
//            typeof(BottomBarPageExtensions),
//            Color.Red);


//        //Methods
//        public static void SetTabColor(BindableObject bindable, Color color)
//        {
//            bindable.SetValue(TabColorProperty, color);
//        }

//        public static Color GetTabColor(BindableObject bindable)
//        {
//            return (Color)bindable.GetValue(TabColorProperty);
//        }

//        public static void SetBadgeCount(BindableObject bindable, int badgeCount)
//        {
//            bindable.SetValue(BadgeCountProperty, badgeCount);
//        }

//        public static int GetBadgeCount(BindableObject bindable)
//        {
//            return (int)bindable.GetValue(BadgeCountProperty);
//        }

//        public static void SetBadgeColor(BindableObject bindable, Color color)
//        {
//            bindable.SetValue(BadgeColorProperty, color);
//        }

//        public static Color GetBadgeColor(BindableObject bindable)
//        {
//            return (Color)bindable.GetValue(BadgeColorProperty);
//        }       
//    }
//}
