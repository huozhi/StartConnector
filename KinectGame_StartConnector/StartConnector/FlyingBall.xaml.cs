﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace StartConnector
{
	public partial class FlyingBall : UserControl
	{
        /********** DATA MEMBER **************/
        public Image img;
        public bool isClosed;
        public int eId;   // queue id
        public double xV; // x dir velocity 
        public double yV; // y dir velocity
        public BallState state;
        /********** DATA MEMBER **************/
		public FlyingBall()
		{
			this.InitializeComponent();
		}

        public void RotateBall()
        {
            // rotating
            ChangeFootballAngle.Angle = (ChangeFootballAngle.Angle + 30) % 360;
        }
       


        private void ReleaseImage()
        {
            this.isClosed = false;
            this.img.Source = null;
            this.img.Margin = new Thickness(
                GameKernel.startPoint[eId].X,
                GameKernel.startPoint[eId].Y,
                0,
                0
            );
            Canvas.SetLeft(img, 0);
            Canvas.SetTop(img, 0);
            this.state = BallState.NONE;
            GameWindow.playerStatus = ScoreStatus.SCO_NULL;
        }

        public void MoveBall()
        {
            switch(eId)
            {
                case 0:
                    MoveLeftBall();
                    break;
                case 1:
                    MoveObliqueLeftBall();
                    break;
                case 2:
                    MoveMiddleBall();
                    break;
                case 3:
                    MoveObliqueRightBall();
                    break;
                case 4:
                    MoveRightBall();
                    break;
                default:
                    break;
            }
        }

        public void MoveLeftBall()
        {
            Storyboard moveLeftAction = (Storyboard)Resources["MoveLeft"];
            moveLeftAction.Begin();
        }

        public void MoveObliqueLeftBall()
        {
            Storyboard moveLeftAction = (Storyboard)Resources["MoveObliqueLeft"];
            moveLeftAction.Begin();
        }
        public void MoveMiddleBall()
        {
            Storyboard moveLeftAction = (Storyboard)Resources["MoveMiddle"];
            moveLeftAction.Begin();
        }

        public void MoveObliqueRightBall()
        {
            Storyboard moveLeftAction = (Storyboard)Resources["MoveObliqueRight"];
            moveLeftAction.Begin();
        }

        public void MoveRightBall()
        {
            Storyboard moveLeftAction = (Storyboard)Resources["MoveRight"];
            moveLeftAction.Begin();
        }
	}
}