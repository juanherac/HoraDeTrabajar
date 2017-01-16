using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HoraDeTrabajar
{
	public class App : Application
	{
		 public interface IAuthenticate
		 {
			 Task<bool> Authenticate();
		 }

		 public static IAuthenticate Authenticator { get; private set; }

		 public static void Init(IAuthenticate authenticator)
		 {
			 Authenticator = authenticator;
		 }

		public App ()
		{
			// The root page of your application
			MainPage = new TodoList();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

