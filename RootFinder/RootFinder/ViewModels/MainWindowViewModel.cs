using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using RootFinder.BusinessLayer.Validators;
using RootFinder.EventArg;
using RootFinder.ViewModels.Base.Commands;
using RootFinder.ViewModels.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RootFinder.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Events
        public EventHandler<FunctionEventArgs> OnDrawPlotButtonPressedEvent;
        #endregion

        #region Fields

        private string m_title;

        private string m_xMin;

        private string m_xMax;

        private string m_a;

        private string m_c;
       
        private bool m_inputValid;

        private string m_dx;

        private double m_eps;

        private OxyPlot.Wpf.PlotView m_PlotView;
        
        #endregion

        #region Properties

        public string Title 
        {
            get=>m_title; 
            set=>Set(ref m_title, value);
        }


        public string XMinStr 
        {
            get=>m_xMin;
            set=>Set(ref m_xMin,value);                
        }

        public string XMaxStr 
        {
            get=>m_xMax; 
            set=> Set(ref m_xMax, value);
        }

        public string AStr 
        { 
            get=> m_a; 
            set=> Set(ref m_a, value);
        }

        public string CStr
        { 
            get => m_c;
            set=>Set(ref m_c, value);
        }

        public string Dx 
        { 
            get=>m_dx;
            set=>Set(ref m_dx, value); 
        }

        public PlotView PlotView 
        {
            get=>m_PlotView; 
            set=>Set(ref m_PlotView, value); 
        }
        #endregion

        #region IData Error Info

        public override string this[string columnName]
        {
            get 
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(XMinStr):
                        SetValidArrayValue(0, ValidationHelper.ValidateDoubleNumberInput(XMinStr, out error));
                        break;
                    case nameof(XMaxStr):
                        SetValidArrayValue(1, ValidationHelper.ValidateDoubleNumberInput(XMinStr, out error));
                        break;
                    case nameof(AStr):
                        SetValidArrayValue(2, ValidationHelper.ValidateDoubleNumberInput(AStr, out error));
                        break;
                    case nameof(CStr):
                        SetValidArrayValue(3, ValidationHelper.ValidateDoubleNumberInput(CStr, out error));
                        break;
                    case nameof(Dx):
                        SetValidArrayValue(4, ValidationHelper.ValidateDoubleNumberInput(Dx, out error));
                        break;
                }

                m_inputValid = ValidateFields(0, GetValidArrayCount() - 1);

                return error;
            }
        }

        #endregion

        #region Commands
        public ICommand OnDrawButtonPressed { get; }

        public ICommand OnGetResultButtonPressed { get; }
        #endregion

        #region Ctor
        public MainWindowViewModel() : base(5)
        {
            #region Init Fields
            m_title = "RootFinder";

            m_a = string.Empty;
            m_c = string.Empty;
            m_xMax = string.Empty;
            m_xMin = string.Empty;

            m_dx = string.Empty;

            m_inputValid = false;
            m_PlotView = new PlotView();
            #endregion

            #region Init Commands
            OnDrawButtonPressed = new Command(
                OnDrawButtonPressedExecute,
                CanOnDrawButtonPressedExecute
                );

            OnGetResultButtonPressed = new Command(
                OnGetResultButtonPressedExecute,
                CanOnGetResultButtonPressedExecute
                );
            #endregion
        }
        #endregion

        #region Methods

        #region On Draw Button Pressed

        private bool CanOnDrawButtonPressedExecute(object p) => m_inputValid;

        private void OnDrawButtonPressedExecute(object p)
        {
            this.OnDrawPlotButtonPressedEvent?.Invoke(this, 
                new FunctionEventArgs(Function, double.Parse(XMinStr),
                double.Parse(XMaxStr), double.Parse(Dx), "Some FUnction"));
        }
        #endregion

        #region On Get Result Button Pressed

        private bool CanOnGetResultButtonPressedExecute(object p) => m_inputValid;

        private void OnGetResultButtonPressedExecute(object p)
        { 
            
        }

        #endregion

        private double Function(double x)
        {
            double a = double.Parse(AStr);
            double c = double.Parse(CStr);

            return a * Math.Pow(x, 2) + Math.Sin(x + 0.5)*x + c;
        }

        #endregion
    }
}
