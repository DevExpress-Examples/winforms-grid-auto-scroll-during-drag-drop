using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Drawing;

namespace AutoScrollTimer {
    public class AutoScrollHelper {
        public AutoScrollHelper(GridView view) {
            fGrid = view.GridControl;
            fView = view;
            fScrollInfo = new ScrollInfo(this, view);
        }

        GridControl fGrid;
        GridView fView;
        ScrollInfo fScrollInfo;
        public int ThresholdInner = 20;
        public int ThresholdOutter = 100;
        public int HorizontalScrollStep = 10;
        public int ScrollTimerInterval {
            get {
                return fScrollInfo.scrollTimer.Interval;
            }
            set {
                fScrollInfo.scrollTimer.Interval = value;
            }
        }

        public void ScrollIfNeeded() {
            Point pt = fGrid.PointToClient(Control.MousePosition);
            Rectangle rect = fView.ViewRect;
            fScrollInfo.GoLeft = (pt.X > rect.Left - ThresholdOutter) && (pt.X < rect.Left + ThresholdInner);
            fScrollInfo.GoRight = (pt.X > rect.Right - ThresholdInner) && (pt.X < rect.Right + ThresholdOutter);
            fScrollInfo.GoUp = (pt.Y < rect.Top + ThresholdInner) && (pt.Y > rect.Top - ThresholdOutter);
            fScrollInfo.GoDown = (pt.Y > rect.Bottom - ThresholdInner) && (pt.Y < rect.Bottom + ThresholdOutter);
            Console.WriteLine("{0} {1} {2} {3} {4}", pt, fScrollInfo.GoLeft, fScrollInfo.GoRight, fScrollInfo.GoUp, fScrollInfo.GoDown);
        }

        internal class ScrollInfo {
            internal Timer scrollTimer;
            GridView view = null;
            bool left, right, up, down;

            AutoScrollHelper owner;
            public ScrollInfo(AutoScrollHelper owner, GridView view) {
                this.owner = owner;
                this.view = view;
                this.scrollTimer = new Timer();
                this.scrollTimer.Tick += new EventHandler(scrollTimer_Tick);
            }
            public bool GoLeft {
                get { return left; }
                set {
                    if(left != value) {
                        left = value;
                        CalcInfo();
                    }
                }
            }
            public bool GoRight {
                get { return right; }
                set {
                    if(right != value) {
                        right = value;
                        CalcInfo();
                    }
                }
            }
            public bool GoUp {
                get { return up; }
                set {
                    if(up != value) {
                        up = value;
                        CalcInfo();
                    }
                }
            }
            public bool GoDown {
                get { return down; }
                set {
                    if(down != value) {
                        down = value;
                        CalcInfo();
                    }
                }
            }
            private void scrollTimer_Tick(object sender, System.EventArgs e) {
                owner.ScrollIfNeeded();

                if(GoDown) 
                    view.TopRowIndex++;
                if(GoUp) 
                    view.TopRowIndex--;
                if(GoLeft) 
                    view.LeftCoord -= owner.HorizontalScrollStep;
                if(GoRight) 
                    view.LeftCoord += owner.HorizontalScrollStep;

                if((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
                    scrollTimer.Stop();
            }
            void CalcInfo() {
                if(!(GoDown && GoLeft && GoRight && GoUp)) 
                    scrollTimer.Stop();

                if(GoDown || GoLeft || GoRight || GoUp) 
                    scrollTimer.Start();
            }
        }
    }
}
