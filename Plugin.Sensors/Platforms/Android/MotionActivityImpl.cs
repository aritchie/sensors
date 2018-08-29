using System;
using System.Reactive.Linq;
using Android.App;
using Android.Gms.Location;
using Android.Gms.Tasks;


namespace Plugin.Sensors
{
    public class MotionActivityImpl : Java.Lang.Object,
                                      IMotionActivity,
                                      IOnSuccessListener,
                                      IOnFailureListener
    {
        public bool IsSupported => true;

        //<uses-permission android:name="com.google.android.gms.permission.ACITIVITY_RECOGNITION" />
        public IObservable<MotionActivityEvent> WhenActivityChanged() => Observable.Create<MotionActivityEvent>(ob =>
        {
            //var request = new ActivityTransition.Builder();

            var client = ActivityRecognition.GetClient(Application.Context);
            var task = client.RequestActivityUpdates(0, null);
            task.AddOnSuccessListener(this);
            task.AddOnFailureListener(this);

            return () => { };
        });


        public void OnFailure(Java.Lang.Exception e)
        {
            throw new NotImplementedException();
        }


        public void OnSuccess(Java.Lang.Object result)
        {
            throw new NotImplementedException();
        }
    }
}
