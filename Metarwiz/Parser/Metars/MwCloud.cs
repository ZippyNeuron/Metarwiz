using System;
using System.Text.RegularExpressions;
using ZippyNeuron.Metarwiz.Enums;
using ZippyNeuron.Metarwiz.Extensions;

namespace ZippyNeuron.Metarwiz.Parser.Metars
{
    public class MwCloud : BaseMetarItem
    {
        private const int Multiplier = 100;
        
        private readonly int _aboveGroundLevel;
        private readonly Cloud _cloud;
        private readonly CloudType _cloudType;
        private readonly string _altitudeOriginal;
        private readonly string _cloudOriginal;
        private readonly string _cloudTypeOriginal;

        public MwCloud(Match match)
        {
            _ = match ?? throw new ArgumentNullException(nameof(match));
            
            _altitudeOriginal = match.Groups["ALTITUDE"].Value;
            _cloudOriginal = match.Groups["CLOUD"].Value;
            _cloudTypeOriginal = match.Groups["CLOUDTYPE"].Value;

            if (!_altitudeOriginal.StartsWith("/"))
            {
                _ = int.TryParse(_altitudeOriginal, out _aboveGroundLevel);
            }

            if (!_cloudOriginal.StartsWith("/"))
            {
                _ = Enum.TryParse(_cloudOriginal, out _cloud);
            }

            if (!_cloudTypeOriginal.StartsWith("/"))
            {
                _ = Enum.TryParse(_cloudTypeOriginal, out _cloudType);
            }
        }

        public int AboveGroundLevel => _aboveGroundLevel * Multiplier;
        public Cloud Cloud => _cloud;
        public CloudType CloudType => _cloudType;
        public string CloudDescription => Cloud.GetDescription();
        
        public string CloudTypeDescription => CloudType.GetDescription();
        
        public static string Pattern
        {
            get
            {
                var clouds = string.Join("|", Enum.GetNames<Cloud>());

                var cloudTypes = string.Join("|", Enum.GetNames<CloudType>());

                return @$"( )(?<CLOUD>///|{clouds})(?<ALTITUDE>\d+|///|//)?(?<CLOUDTYPE>{cloudTypes}|///)?";
            }
        }

        public override string ToString()
        {
            var alt = (_altitudeOriginal.StartsWith("/") || String.IsNullOrEmpty(_altitudeOriginal)) ? _altitudeOriginal : _aboveGroundLevel.ToString("D3");

            return string.Concat(
                (_cloudOriginal.StartsWith("/") || _cloud == Cloud.Unspecified) ? _cloudOriginal : Enum.GetName(Cloud),
                alt,
                (_cloudTypeOriginal.StartsWith("/") || _cloudType == CloudType.Unspecified) ? _cloudTypeOriginal : Enum.GetName(CloudType)
            ); ;
        }
    }
}
