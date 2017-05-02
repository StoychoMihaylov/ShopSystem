using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models.BindingModels
{
    public class AddMonitorBm
    {
        [Display(Name = "Model")]

        public string ModelName { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string Description4 { get; set; }

        public string Description5 { get; set; }

        [Display(Name = "LCD Size")]

        public string LCDSize { get; set; }

        public string Resolution { get; set; }

        [Display(Name = "Aspect Ratio")]

        public string AspectRatio { get; set; }

        [Display(Name = "Picel Pitch")]

        public string PixelPitch { get; set; }

        [Display(Name = "USB Hub")]

        public string USBHub { get; set; }

        [Display(Name = "Input Connector")]

        public string InputConnector { get; set; }

        [Display(Name = "Included Signal Cable")]

        public string IncludedSignalCable { get; set; }

        public string VESA { get; set; }

        [Display(Name = "Auto Game Mode")]

        public string AutoGameMode { get; set; }

        [Display(Name = "Low Blue Light")]

        public string LowBlueLight { get; set; }

        [Display(Name = "Filter Free Technology")]

        public string FilterFreeTechnology { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public byte[] Image3 { get; set; }

        public byte[] Image4 { get; set; }

        public byte[] Image5 { get; set; }
    }
}
