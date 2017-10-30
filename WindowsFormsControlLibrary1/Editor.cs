using System;
using System.IO;
using System.Windows.Forms;

using EventPublisher;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary1
{
    public partial class Editor : UserControl
    {
        public Guid Id;

        private bool _leftBoxDirty;

        public Editor(string txtLeftText, string txtRightText)
        {
            InitializeComponent();
            Id = Guid.NewGuid();
            SubScribeEvents();
            txtRight.Text = txtRightText;
            txtLeft.Text = txtLeftText;
            txtLeft_TextChanged(null, null);

        }

        public string LeftTextBoxText{
            get
            {
                return txtLeft.Text;
            }
        }

        public string RightTextBoxText
        {
            get
            {
                return txtRight.Text;
            }
        }

        string _txtLeftText;
        private void txtLeft_TextChanged(object sender, EventArgs e)
        {
      
            if(string.IsNullOrEmpty(txtLeft.Text))
            {
                return;
            }

            _txtLeftText = txtLeft.Text;

            Task.Run(() => Lapa(_txtLeftText));
          //  EventContainer.PublishEvent(EventPublisher.Events.LeftTextBoxChanged.ToString(), eventArg);
        }

        private void Lapa(string text)
        {
            Thread.Sleep(500);

            if(_txtLeftText == text)
            {
                var eventArg = new EventArg(Id, _txtLeftText);
                EventContainer.PublishEvent(EventPublisher.Events.LeftTextBoxChanged.ToString(), eventArg);
            }
        }

        private void txtRight_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventPublisher.Events.SetRightTextBoxText.ToString(), SetRightTextBoxText);
            EventContainer.SubscribeEvent(EventPublisher.Events.SetBottomTextBoxText.ToString(), SetBottomTextBoxText);
            EventContainer.SubscribeEvent(EventPublisher.Events.SaveLeftTextBoxChanges.ToString(), SaveLeftBoxText);
        }


        private void SaveLeftBoxText(EventArg eventArg)
        {
          
        }

        private void SetRightTextBoxText(EventArg eventArg)
        {
            if (!this.ValidEvent(eventArg))
            {
                return;
            }

            BeginInvoke((Action)(() => txtRight.Text = eventArg.Arg.ToString()));
        }

        private void SetBottomTextBoxText(EventArg eventArg)
        {
            if (!this.ValidEvent(eventArg))
            {
                return;
            }

            BeginInvoke((Action)(() => txtBotttom.Text = eventArg.Arg.ToString()));
        }

        private bool ValidEvent(EventArg eventArg)
        {
            return eventArg.EventId == Id;
        }

        private void txtBotttom_TextChanged(object sender, EventArgs e)
        {

        }

   }
}
