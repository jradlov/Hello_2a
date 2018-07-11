using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Threading.Tasks;

//using System.Threading;   // don't use this for threading
using Java.Lang;            // Java version of threading works better

// Udemy ex: Grant K. course, section 3.17 - Slow Text Mover
// Need a timer to slow down the test moving

// The instructor's solution (Hello_2) crashes!  Don't know why...
// On the course Q&A somebody posted the solution done here (Hello_2a).
// It works great.  No need to create a separate thread from 
// the Ui thread if do the Sleep in async mode

namespace Hello_2a {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button btn = FindViewById<Button>(Resource.Id.button1);
            TextView txtView = FindViewById<TextView>(Resource.Id.textView1);
            EditText editTxt = FindViewById<EditText>(Resource.Id.editText1);

            btn.Click += async delegate {
                txtView.Text = "";

                foreach(char c in editTxt.Text) {
                    editTxt.Text = editTxt.Text.Remove(0, 1);
                    txtView.Append(c.ToString());
                    // still in UI thread but no prob because of ASYNC mode
                    await Task.Delay(300);
                }
            };

        }
    }
}

