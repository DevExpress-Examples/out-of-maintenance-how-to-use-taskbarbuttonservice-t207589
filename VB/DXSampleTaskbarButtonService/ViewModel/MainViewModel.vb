Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports System
Imports System.Windows.Shell

Namespace DXSampleTaskbarButtonService.ViewModel

    <POCOViewModel>
    Public Class MainViewModel

        Private Property ThumbnailClipMargin As Integer

        Public Overridable Property Description As String

        Public Overridable Property ProgressValue As Double

        <BindableProperty(OnPropertyChangedMethodName:="UpdateProgressState")>
        Public Overridable Property IsNormalProgressState As Boolean

        <BindableProperty(OnPropertyChangedMethodName:="UpdateProgressState")>
        Public Overridable Property IsPausedProgressState As Boolean

        <BindableProperty(OnPropertyChangedMethodName:="UpdateProgressState")>
        Public Overridable Property IsErrorProgressState As Boolean

        <BindableProperty(OnPropertyChangedMethodName:="UpdateProgressState")>
        Public Overridable Property IsIndetermintateProgressState As Boolean

        <BindableProperty(OnPropertyChangedMethodName:="UpdateProgressState")>
        Public Overridable Property IsNoneProgressState As Boolean

        Protected Overridable ReadOnly Property TaskbarButtonService As ITaskbarButtonService
            Get
                Return Nothing
            End Get
        End Property

        Public Sub New()
            Description = "Hello, World!"
            ProgressValue = 0.5
            IsNormalProgressState = True
            ThumbnailClipMargin = 0
        End Sub

        Protected Sub UpdateProgressState()
            If TaskbarButtonService Is Nothing Then Return
            If IsNormalProgressState Then
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.Normal
            ElseIf IsPausedProgressState Then
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.Paused
            ElseIf IsErrorProgressState Then
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.Error
            ElseIf IsIndetermintateProgressState Then
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.Indeterminate
            ElseIf IsNoneProgressState Then
                TaskbarButtonService.ProgressState = TaskbarItemProgressState.None
            Else
                Throw New NotImplementedException()
            End If
        End Sub

        Public Sub IncreaseProgress()
            If ProgressValue < 1 Then
                ProgressValue += 0.1R
            End If
        End Sub

        Public Sub DecreaseProgress()
            If ProgressValue > 0 Then
                ProgressValue -= 0.1R
            End If
        End Sub
    End Class
End Namespace
