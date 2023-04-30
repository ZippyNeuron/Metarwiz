using System;
using System.Text.RegularExpressions;
using ZippyNeuron.Metarwiz.Parser.Types;
using ZippyNeuron.Metarwiz.Parser.Helpers;

namespace ZippyNeuron.Metarwiz.Parser.Metars
{
    public class MwCloud : MetarItem
    {
        private const int Multiplier = 100;
        
        private readonly int _aboveGroundLevel;
        private readonly CloudType _cloud;
        private readonly CloudFormType _cloudType;
        private readonly string _altitudeOriginal;
        private readonly string _cloudOriginal;
        private readonly string _cloudTypeOriginal;

        internal MwCloud(Match match)
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
        public CloudType Cloud => _cloud;
        public CloudFormType CloudType => _cloudType;
        public string CloudDescription => Cloud.GetDescription();
        
        public string CloudTypeDescription => CloudType.GetDescription();

        internal static string Pattern
        {
            get
            {
                var clouds = string.Join("|", Enum.GetNames<CloudType>());

                var cloudTypes = string.Join("|", Enum.GetNames<CloudFormType>());

                return @$"( )(?<CLOUD>///|{clouds})(?<ALTITUDE>\d+|///|//)?(?<CLOUDTYPE>{cloudTypes}|///)?";
            }
        }

        public override string ToString()
        {
            var alt = (_altitudeOriginal.StartsWith("/") || String.IsNullOrEmpty(_altitudeOriginal)) ? _altitudeOriginal : _aboveGroundLevel.ToString("D3");

            return string.Concat(
                (_cloudOriginal.StartsWith("/") || _cloud == Types.CloudType.Unspecified) ? _cloudOriginal : Enum.GetName(Cloud),
                alt,
                (_cloudTypeOriginal.StartsWith("/") || _cloudType == CloudFormType.Unspecified) ? _cloudTypeOriginal : Enum.GetName(CloudType)
            ); ;
        }
    }
}
