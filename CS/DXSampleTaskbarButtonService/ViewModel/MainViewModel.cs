using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Windows.Shell;

namespace DXSampleTaskbarButtonService.ViewModel {
    [POCOViewModel]
    public class MainViewModel {
        private int ThumbnailClipMargin { get; set; }
        public virtual string Description { get; set; }
        public virtual double ProgressValue { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = "UpdateProgressState")]
        public virtual bool IsNormalProgressState { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = "UpdateProgressState")]
        public virtual bool IsPausedProgressState { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = "UpdateProgressState")]
        public virtual bool IsErrorProgressState { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = "UpdateProgressState")]
        public virtual bool IsIndetermintateProgressState { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = "UpdateProgressState")]
        public virtual bool IsNoneProgressState { get; set; }

        protected virtual ITaskbarButtonService TaskbarButtonService { get { return null; } }

        public MainViewModel() {
            Description = "Hello, World!";
            ProgressValue = 0.5;
            IsNormalProgressState = true;
            ThumbnailClipMargin = 0;
        }
        protected void UpdateProgressState() {
            if (TaskbarButtonService == null) return;
            if (IsNormalProgressState)
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.Normal;
            else if (IsPausedProgressState)
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.Paused;
            else if (IsErrorProgressState)
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.Error;
            else if (IsIndetermintateProgressState)
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.Indeterminate;
            else if (IsNoneProgressState)
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.None;
            else
                throw new NotImplementedException();
        }

        public void IncreaseProgress() {
            if (ProgressValue < 1) {
                ProgressValue += 0.1d;
            }
        }

        public void DecreaseProgress() {
            if (ProgressValue > 0) {
                ProgressValue -= 0.1d;
            }
        }
    }
}
