#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Indicators
{
	public class FiveMinutePulse : Indicator
	{
		protected override void OnStateChange()
	    {
	        if (State == State.SetDefaults)
	        {
	            Description = @"Highlight the second 5-minute bar within each 15-minute period.";
	            Name = "FiveMinutePulse";
	            Calculate = Calculate.OnPriceChange;
	            IsOverlay = true; // To display on the price panel
	            // Adding 5-minute bars
				
				UpColor = Brushes.DodgerBlue;
				DownColor = Brushes.OrangeRed;
	        }
			else if (State == State.Configure)
			{AddDataSeries(Data.BarsPeriodType.Minute, 5);}
	    }
	
	    protected override void OnBarUpdate()
	    {
	        // Ensure we're working with 5-minute bars and have at least 2 bars for comparison
	        if (BarsInProgress != 1 || CurrentBars[1] < 2) return;
	
	        // Every third 5-minute bar starting from the second one is the second bar of a 15-minute period
	        // We use modulo arithmetic to find every third bar
	        if ((CurrentBars[1] + 2) % 3 == 0)
	        {
	            // Highlight the second bar of each 15-minute period
	            // This is achieved by changing the bar color on the primary series
	            // We adjust the index to match the 15-minute primary bars series
				// Highlight the corresponding bar on the primary (15-minute) series
	            BarBrushes[0] = Close[0]<Open[0] ? DownColor : UpColor; 
				CandleOutlineBrushes[0] = Close[0]<Open[0] ? DownColor : UpColor; 
	        }
	    }
		
		[NinjaScriptProperty]
		[XmlIgnore]
		[Display(Name = "Up Bar Color", GroupName = "Signal Setup", Order = 60)]
		public Brush UpColor
		{ get; set; }
		[Browsable(false)]
		public string UpColorSerializable
		{
			get { return Serialize.BrushToString(UpColor); }
			set { UpColor = Serialize.StringToBrush(value); }
		}
		// ---
		[NinjaScriptProperty]
		[XmlIgnore]
		[Display(Name = "Sell Color", GroupName = "Signal Setup", Order = 70)]
		public Brush DownColor
		{ get; set; }
		[Browsable(false)]
		public string DownColorSerializable
		{
			get { return Serialize.BrushToString(DownColor); }
			set { DownColor = Serialize.StringToBrush(value); }
		}
	}
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		private FiveMinutePulse[] cacheFiveMinutePulse;
		public FiveMinutePulse FiveMinutePulse(Brush upColor, Brush downColor)
		{
			return FiveMinutePulse(Input, upColor, downColor);
		}

		public FiveMinutePulse FiveMinutePulse(ISeries<double> input, Brush upColor, Brush downColor)
		{
			if (cacheFiveMinutePulse != null)
				for (int idx = 0; idx < cacheFiveMinutePulse.Length; idx++)
					if (cacheFiveMinutePulse[idx] != null && cacheFiveMinutePulse[idx].UpColor == upColor && cacheFiveMinutePulse[idx].DownColor == downColor && cacheFiveMinutePulse[idx].EqualsInput(input))
						return cacheFiveMinutePulse[idx];
			return CacheIndicator<FiveMinutePulse>(new FiveMinutePulse(){ UpColor = upColor, DownColor = downColor }, input, ref cacheFiveMinutePulse);
		}
	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		public Indicators.FiveMinutePulse FiveMinutePulse(Brush upColor, Brush downColor)
		{
			return indicator.FiveMinutePulse(Input, upColor, downColor);
		}

		public Indicators.FiveMinutePulse FiveMinutePulse(ISeries<double> input , Brush upColor, Brush downColor)
		{
			return indicator.FiveMinutePulse(input, upColor, downColor);
		}
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		public Indicators.FiveMinutePulse FiveMinutePulse(Brush upColor, Brush downColor)
		{
			return indicator.FiveMinutePulse(Input, upColor, downColor);
		}

		public Indicators.FiveMinutePulse FiveMinutePulse(ISeries<double> input , Brush upColor, Brush downColor)
		{
			return indicator.FiveMinutePulse(input, upColor, downColor);
		}
	}
}

#endregion
