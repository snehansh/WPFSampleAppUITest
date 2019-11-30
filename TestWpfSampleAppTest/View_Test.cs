﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using WPFSampleAppTest;

namespace TestWpfSampleAppTest
{
    [Apartment(ApartmentState.STA)]
    [TestFixture]
    public class View_Test
    {
        private App app;
        private MainWindow mainWindow;
        private View view;
        private ButtonAutomationPeer buttonPeer;
        private TextBoxAutomationPeer textBoxPeer;

        [SetUp]
        public void SetUp()
        {
            //View view = new View();
            //MainWindow window = new MainWindow();
            //window.Content = view;

            //window.ShowDialog();

            Application.ResourceAssembly = Assembly.GetAssembly(typeof(App));

            app = new App();
            app.InitializeComponent();

            mainWindow = new MainWindow();
            app.MainWindow = mainWindow;

            view = new View();
            Assert.That(view, Is.Not.Null);

            //view.Show();
            mainWindow.Content = view;
            mainWindow.Show();



            //WindowAutomationPeer
            UserControlAutomationPeer viewAutomationPeer = new UserControlAutomationPeer(view);
            List<AutomationPeer> children = viewAutomationPeer.GetChildren();

            //figure out type of the children before cast
            buttonPeer = (ButtonAutomationPeer)children[0];
            textBoxPeer = (TextBoxAutomationPeer)children[1];
        }

        [Test]
        public void OnLoad_Test()
        {
            Assert.That("0", Is.EqualTo(((IValueProvider)textBoxPeer).Value));
            Button button = (Button)buttonPeer.Owner;
            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);
            Assert.That("1", Is.EqualTo(((IValueProvider)textBoxPeer).Value));
        }

        [TearDown]
        public void TearDown()
        {
            mainWindow.Close();
        }

    }
}
