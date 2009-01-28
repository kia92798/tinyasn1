using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CSharpAsn1CRT;

namespace TAP_0311_DNA
{

    public partial class RootNode : Asn1SequenceOfObject<DataInterChange>
    {
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[2] { 0x41,0x42 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<DataInterChange> CreateEmptyChild { get { return delegate() { return new DataInterChange (); }; } }
    }

    public partial class OperatorSpecInformation : Asn1ChoiceObject
    {

        public City city
        {
            get { return m_children[ClassDef.m_children["city"].m_index] as City; }
        }
        public City Create_city()
        {
            return CreateChild("city") as City;
        }

        public City_MMS city_mms
        {
            get { return m_children[ClassDef.m_children["city_mms"].m_index] as City_MMS; }
        }
        public City_MMS Create_city_mms()
        {
            return CreateChild("city_mms") as City_MMS;
        }

        public SGw_SMS sgw_sms
        {
            get { return m_children[ClassDef.m_children["sgw_sms"].m_index] as SGw_SMS; }
        }
        public SGw_SMS Create_sgw_sms()
        {
            return CreateChild("sgw_sms") as SGw_SMS;
        }

        public SGw_MMS sgw_mms
        {
            get { return m_children[ClassDef.m_children["sgw_mms"].m_index] as SGw_MMS; }
        }
        public SGw_MMS Create_sgw_mms()
        {
            return CreateChild("sgw_mms") as SGw_MMS;
        }

        public SGw_WAP sgw_wap
        {
            get { return m_children[ClassDef.m_children["sgw_wap"].m_index] as SGw_WAP; }
        }
        public SGw_WAP Create_sgw_wap()
        {
            return CreateChild("sgw_wap") as SGw_WAP;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8123);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8123);
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new OperatorSpecInformationClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public OperatorSpecInformation()
        {
            m_children = new Asn1Object[5];
        }
        public class OperatorSpecInformationClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public OperatorSpecInformationClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("city", 0, CreateCity);
                m_posChildren.Add(0x5F8620, ch);
                m_children.Add("city", ch);
                ch = new NamedChild("city_mms", 1, CreateCity_MMS);
                m_posChildren.Add(0x5F8621, ch);
                m_children.Add("city_mms", ch);
                ch = new NamedChild("sgw_sms", 2, CreateSGw_SMS);
                m_posChildren.Add(0x5F8622, ch);
                m_children.Add("sgw_sms", ch);
                ch = new NamedChild("sgw_mms", 3, CreateSGw_MMS);
                m_posChildren.Add(0x5F8623, ch);
                m_children.Add("sgw_mms", ch);
                ch = new NamedChild("sgw_wap", 4, CreateSGw_WAP);
                m_posChildren.Add(0x5F8624, ch);
                m_children.Add("sgw_wap", ch);
            }
            public static City CreateCity() { return new City();}
            public static City_MMS CreateCity_MMS() { return new City_MMS();}
            public static SGw_SMS CreateSGw_SMS() { return new SGw_SMS();}
            public static SGw_MMS CreateSGw_MMS() { return new SGw_MMS();}
            public static SGw_WAP CreateSGw_WAP() { return new SGw_WAP();}
        }
    }

    public partial class OSFBCDString : BCDString
    {
    }

    public partial class OSFAsciiString : AsciiString
    {
    }

    public partial class OSFInteger : Asn1IntegerObject
    {
    }

    public partial class CallIdentificationNumber : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFF"},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F862B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F862B);
        }
    }

    public partial class ChargedParty : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FF"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F862C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F862C);
        }
    }

    public partial class ChargingCase : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFF"},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F862D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F862D);
        }
    }

    public partial class TariffClass : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFF"},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F862E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F862E);
        }
    }

    public partial class OutgoingRoute : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","       "},
            {"Size","7"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F862F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F862F);
        }
    }

    public partial class IncomingRoute : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","       "},
            {"Size","7"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8630);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8630);
        }
    }

    public partial class EOSInfo : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FF"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8631);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8631);
        }
    }

    public partial class LastPartialOutput : OSFInteger
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","0"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8632);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8632);
        }
    }

    public partial class PartialOutputRecNum : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","0"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8633);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8633);
        }
    }

    public partial class FaultCode : OSFInteger
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","0"},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8634);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8634);
        }
    }

    public partial class INMarkingofMS : OSFInteger
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","0"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8635);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8635);
        }
    }

    public partial class AccountCode : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFF"},
            {"Size","5"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8636);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8636);
        }
    }

    public partial class TypeofNumber : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","F"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8637);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8637);
        }
    }

    public partial class NumberingPlanIndicator : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","F"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8638);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8638);
        }
    }

    public partial class TranslatedNumber : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"},
            {"Size","19"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8639);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8639);
        }
    }

    public partial class ServiceCode : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","00"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F863A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F863A);
        }
    }

    public partial class TypeofAccess : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","00"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F863B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F863B);
        }
    }

    public partial class FunctionTrace : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFFFFFFFFFFFFFF"},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F863C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F863C);
        }
    }

    public partial class CallType : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FF"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F863D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F863D);
        }
    }

    public partial class ServiceSubscriberId : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFFFFFFFFFFFFFF"},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F863E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F863E);
        }
    }

    public partial class CostDistributionCode : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFFFFFFFFFFFFFF"},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F863F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F863F);
        }
    }

    public partial class ExtraCostDistributionCode : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFFFFFFFFFFFFFF"},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8640);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8640);
        }
    }

    public partial class PublicNumberCalledNumber : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFF"},
            {"Size","8"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8641);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8641);
        }
    }

    public partial class ExtraDestinationNumber : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFF"},
            {"Size","8"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8642);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8642);
        }
    }

    public partial class LocationIndicatorCallingParty : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FF"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8643);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8643);
        }
    }

    public partial class LocationIndicatorCalledParty : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FF"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8644);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8644);
        }
    }

    public partial class TypeofTermination : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FF"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8645);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8645);
        }
    }

    public partial class LocationNumber : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFFFFFFFFFFFFFF"},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8646);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8646);
        }
    }

    public partial class PublicNumberCallingNumber : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFFF"},
            {"Size","8"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8647);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8647);
        }
    }

    public partial class TransitCDRIndicator : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","0"},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8648);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8648);
        }
    }

    public partial class City : Asn1SequenceObject
    {

        public CallIdentificationNumber callIdentificationNumber
        {
            get { return m_children[ClassDef.m_children["callIdentificationNumber"].m_index] as CallIdentificationNumber; }
        }
        public CallIdentificationNumber Create_callIdentificationNumber()
        {
            return CreateChild("callIdentificationNumber") as CallIdentificationNumber;
        }

        public ChargedParty chargedParty
        {
            get { return m_children[ClassDef.m_children["chargedParty"].m_index] as ChargedParty; }
        }
        public ChargedParty Create_chargedParty()
        {
            return CreateChild("chargedParty") as ChargedParty;
        }

        public ChargingCase chargingCase
        {
            get { return m_children[ClassDef.m_children["chargingCase"].m_index] as ChargingCase; }
        }
        public ChargingCase Create_chargingCase()
        {
            return CreateChild("chargingCase") as ChargingCase;
        }

        public TariffClass tariffClass
        {
            get { return m_children[ClassDef.m_children["tariffClass"].m_index] as TariffClass; }
        }
        public TariffClass Create_tariffClass()
        {
            return CreateChild("tariffClass") as TariffClass;
        }

        public OutgoingRoute outgoingRoute
        {
            get { return m_children[ClassDef.m_children["outgoingRoute"].m_index] as OutgoingRoute; }
        }
        public OutgoingRoute Create_outgoingRoute()
        {
            return CreateChild("outgoingRoute") as OutgoingRoute;
        }

        public IncomingRoute incomingRoute
        {
            get { return m_children[ClassDef.m_children["incomingRoute"].m_index] as IncomingRoute; }
        }
        public IncomingRoute Create_incomingRoute()
        {
            return CreateChild("incomingRoute") as IncomingRoute;
        }

        public EOSInfo eOSInfo
        {
            get { return m_children[ClassDef.m_children["eOSInfo"].m_index] as EOSInfo; }
        }
        public EOSInfo Create_eOSInfo()
        {
            return CreateChild("eOSInfo") as EOSInfo;
        }

        public LastPartialOutput lastPartialOutput
        {
            get { return m_children[ClassDef.m_children["lastPartialOutput"].m_index] as LastPartialOutput; }
        }
        public LastPartialOutput Create_lastPartialOutput()
        {
            return CreateChild("lastPartialOutput") as LastPartialOutput;
        }

        public PartialOutputRecNum partialOutputRecNum
        {
            get { return m_children[ClassDef.m_children["partialOutputRecNum"].m_index] as PartialOutputRecNum; }
        }
        public PartialOutputRecNum Create_partialOutputRecNum()
        {
            return CreateChild("partialOutputRecNum") as PartialOutputRecNum;
        }

        public FaultCode faultCode
        {
            get { return m_children[ClassDef.m_children["faultCode"].m_index] as FaultCode; }
        }
        public FaultCode Create_faultCode()
        {
            return CreateChild("faultCode") as FaultCode;
        }

        public INMarkingofMS iNMarkingofMS
        {
            get { return m_children[ClassDef.m_children["iNMarkingofMS"].m_index] as INMarkingofMS; }
        }
        public INMarkingofMS Create_iNMarkingofMS()
        {
            return CreateChild("iNMarkingofMS") as INMarkingofMS;
        }

        public AccountCode accountCode
        {
            get { return m_children[ClassDef.m_children["accountCode"].m_index] as AccountCode; }
        }
        public AccountCode Create_accountCode()
        {
            return CreateChild("accountCode") as AccountCode;
        }

        public TypeofNumber typeofNumber
        {
            get { return m_children[ClassDef.m_children["typeofNumber"].m_index] as TypeofNumber; }
        }
        public TypeofNumber Create_typeofNumber()
        {
            return CreateChild("typeofNumber") as TypeofNumber;
        }

        public NumberingPlanIndicator numberingPlanIndicator
        {
            get { return m_children[ClassDef.m_children["numberingPlanIndicator"].m_index] as NumberingPlanIndicator; }
        }
        public NumberingPlanIndicator Create_numberingPlanIndicator()
        {
            return CreateChild("numberingPlanIndicator") as NumberingPlanIndicator;
        }

        public TranslatedNumber translatedNumber
        {
            get { return m_children[ClassDef.m_children["translatedNumber"].m_index] as TranslatedNumber; }
        }
        public TranslatedNumber Create_translatedNumber()
        {
            return CreateChild("translatedNumber") as TranslatedNumber;
        }

        public ServiceCode serviceCode
        {
            get { return m_children[ClassDef.m_children["serviceCode"].m_index] as ServiceCode; }
        }
        public ServiceCode Create_serviceCode()
        {
            return CreateChild("serviceCode") as ServiceCode;
        }

        public TypeofAccess typeofAccess
        {
            get { return m_children[ClassDef.m_children["typeofAccess"].m_index] as TypeofAccess; }
        }
        public TypeofAccess Create_typeofAccess()
        {
            return CreateChild("typeofAccess") as TypeofAccess;
        }

        public FunctionTrace functionTrace
        {
            get { return m_children[ClassDef.m_children["functionTrace"].m_index] as FunctionTrace; }
        }
        public FunctionTrace Create_functionTrace()
        {
            return CreateChild("functionTrace") as FunctionTrace;
        }

        public CallType callType
        {
            get { return m_children[ClassDef.m_children["callType"].m_index] as CallType; }
        }
        public CallType Create_callType()
        {
            return CreateChild("callType") as CallType;
        }

        public ServiceSubscriberId serviceSubscriberId
        {
            get { return m_children[ClassDef.m_children["serviceSubscriberId"].m_index] as ServiceSubscriberId; }
        }
        public ServiceSubscriberId Create_serviceSubscriberId()
        {
            return CreateChild("serviceSubscriberId") as ServiceSubscriberId;
        }

        public CostDistributionCode costDistributionCode
        {
            get { return m_children[ClassDef.m_children["costDistributionCode"].m_index] as CostDistributionCode; }
        }
        public CostDistributionCode Create_costDistributionCode()
        {
            return CreateChild("costDistributionCode") as CostDistributionCode;
        }

        public ExtraCostDistributionCode extraCostDistributionCode
        {
            get { return m_children[ClassDef.m_children["extraCostDistributionCode"].m_index] as ExtraCostDistributionCode; }
        }
        public ExtraCostDistributionCode Create_extraCostDistributionCode()
        {
            return CreateChild("extraCostDistributionCode") as ExtraCostDistributionCode;
        }

        public PublicNumberCalledNumber publicNumberCalledNumber
        {
            get { return m_children[ClassDef.m_children["publicNumberCalledNumber"].m_index] as PublicNumberCalledNumber; }
        }
        public PublicNumberCalledNumber Create_publicNumberCalledNumber()
        {
            return CreateChild("publicNumberCalledNumber") as PublicNumberCalledNumber;
        }

        public ExtraDestinationNumber extraDestinationNumber
        {
            get { return m_children[ClassDef.m_children["extraDestinationNumber"].m_index] as ExtraDestinationNumber; }
        }
        public ExtraDestinationNumber Create_extraDestinationNumber()
        {
            return CreateChild("extraDestinationNumber") as ExtraDestinationNumber;
        }

        public LocationIndicatorCallingParty locationIndicatorCallingParty
        {
            get { return m_children[ClassDef.m_children["locationIndicatorCallingParty"].m_index] as LocationIndicatorCallingParty; }
        }
        public LocationIndicatorCallingParty Create_locationIndicatorCallingParty()
        {
            return CreateChild("locationIndicatorCallingParty") as LocationIndicatorCallingParty;
        }

        public LocationIndicatorCalledParty locationIndicatorCalledParty
        {
            get { return m_children[ClassDef.m_children["locationIndicatorCalledParty"].m_index] as LocationIndicatorCalledParty; }
        }
        public LocationIndicatorCalledParty Create_locationIndicatorCalledParty()
        {
            return CreateChild("locationIndicatorCalledParty") as LocationIndicatorCalledParty;
        }

        public TypeofTermination typeofTermination
        {
            get { return m_children[ClassDef.m_children["typeofTermination"].m_index] as TypeofTermination; }
        }
        public TypeofTermination Create_typeofTermination()
        {
            return CreateChild("typeofTermination") as TypeofTermination;
        }

        public LocationNumber locationNumber
        {
            get { return m_children[ClassDef.m_children["locationNumber"].m_index] as LocationNumber; }
        }
        public LocationNumber Create_locationNumber()
        {
            return CreateChild("locationNumber") as LocationNumber;
        }

        public PublicNumberCallingNumber publicNumberCallingNumber
        {
            get { return m_children[ClassDef.m_children["publicNumberCallingNumber"].m_index] as PublicNumberCallingNumber; }
        }
        public PublicNumberCallingNumber Create_publicNumberCallingNumber()
        {
            return CreateChild("publicNumberCallingNumber") as PublicNumberCallingNumber;
        }

        public TransitCDRIndicator transitCDRIndicator
        {
            get { return m_children[ClassDef.m_children["transitCDRIndicator"].m_index] as TransitCDRIndicator; }
        }
        public TransitCDRIndicator Create_transitCDRIndicator()
        {
            return CreateChild("transitCDRIndicator") as TransitCDRIndicator;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8620);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8620);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new CityClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public City()
        {
            m_children = new Asn1Object[30];
        }
        public class CityClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public CityClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("callIdentificationNumber", 0, CreateCallIdentificationNumber, false, null);
                m_posChildren.Add(0x5F862B, ch);
                m_children.Add("callIdentificationNumber", ch);

                ch = new OptionalNamedChild("chargedParty", 1, CreateChargedParty, false, null);
                m_posChildren.Add(0x5F862C, ch);
                m_children.Add("chargedParty", ch);

                ch = new OptionalNamedChild("chargingCase", 2, CreateChargingCase, false, null);
                m_posChildren.Add(0x5F862D, ch);
                m_children.Add("chargingCase", ch);

                ch = new OptionalNamedChild("tariffClass", 3, CreateTariffClass, false, null);
                m_posChildren.Add(0x5F862E, ch);
                m_children.Add("tariffClass", ch);

                ch = new OptionalNamedChild("outgoingRoute", 4, CreateOutgoingRoute, false, null);
                m_posChildren.Add(0x5F862F, ch);
                m_children.Add("outgoingRoute", ch);

                ch = new OptionalNamedChild("incomingRoute", 5, CreateIncomingRoute, false, null);
                m_posChildren.Add(0x5F8630, ch);
                m_children.Add("incomingRoute", ch);

                ch = new OptionalNamedChild("eOSInfo", 6, CreateEOSInfo, false, null);
                m_posChildren.Add(0x5F8631, ch);
                m_children.Add("eOSInfo", ch);

                ch = new OptionalNamedChild("lastPartialOutput", 7, CreateLastPartialOutput, false, null);
                m_posChildren.Add(0x5F8632, ch);
                m_children.Add("lastPartialOutput", ch);

                ch = new OptionalNamedChild("partialOutputRecNum", 8, CreatePartialOutputRecNum, false, null);
                m_posChildren.Add(0x5F8633, ch);
                m_children.Add("partialOutputRecNum", ch);

                ch = new OptionalNamedChild("faultCode", 9, CreateFaultCode, false, null);
                m_posChildren.Add(0x5F8634, ch);
                m_children.Add("faultCode", ch);

                ch = new OptionalNamedChild("iNMarkingofMS", 10, CreateINMarkingofMS, false, null);
                m_posChildren.Add(0x5F8635, ch);
                m_children.Add("iNMarkingofMS", ch);

                ch = new OptionalNamedChild("accountCode", 11, CreateAccountCode, false, null);
                m_posChildren.Add(0x5F8636, ch);
                m_children.Add("accountCode", ch);

                ch = new OptionalNamedChild("typeofNumber", 12, CreateTypeofNumber, false, null);
                m_posChildren.Add(0x5F8637, ch);
                m_children.Add("typeofNumber", ch);

                ch = new OptionalNamedChild("numberingPlanIndicator", 13, CreateNumberingPlanIndicator, false, null);
                m_posChildren.Add(0x5F8638, ch);
                m_children.Add("numberingPlanIndicator", ch);

                ch = new OptionalNamedChild("translatedNumber", 14, CreateTranslatedNumber, false, null);
                m_posChildren.Add(0x5F8639, ch);
                m_children.Add("translatedNumber", ch);

                ch = new OptionalNamedChild("serviceCode", 15, CreateServiceCode, false, null);
                m_posChildren.Add(0x5F863A, ch);
                m_children.Add("serviceCode", ch);

                ch = new OptionalNamedChild("typeofAccess", 16, CreateTypeofAccess, false, null);
                m_posChildren.Add(0x5F863B, ch);
                m_children.Add("typeofAccess", ch);

                ch = new OptionalNamedChild("functionTrace", 17, CreateFunctionTrace, false, null);
                m_posChildren.Add(0x5F863C, ch);
                m_children.Add("functionTrace", ch);

                ch = new OptionalNamedChild("callType", 18, CreateCallType, false, null);
                m_posChildren.Add(0x5F863D, ch);
                m_children.Add("callType", ch);

                ch = new OptionalNamedChild("serviceSubscriberId", 19, CreateServiceSubscriberId, false, null);
                m_posChildren.Add(0x5F863E, ch);
                m_children.Add("serviceSubscriberId", ch);

                ch = new OptionalNamedChild("costDistributionCode", 20, CreateCostDistributionCode, false, null);
                m_posChildren.Add(0x5F863F, ch);
                m_children.Add("costDistributionCode", ch);

                ch = new OptionalNamedChild("extraCostDistributionCode", 21, CreateExtraCostDistributionCode, false, null);
                m_posChildren.Add(0x5F8640, ch);
                m_children.Add("extraCostDistributionCode", ch);

                ch = new OptionalNamedChild("publicNumberCalledNumber", 22, CreatePublicNumberCalledNumber, false, null);
                m_posChildren.Add(0x5F8641, ch);
                m_children.Add("publicNumberCalledNumber", ch);

                ch = new OptionalNamedChild("extraDestinationNumber", 23, CreateExtraDestinationNumber, false, null);
                m_posChildren.Add(0x5F8642, ch);
                m_children.Add("extraDestinationNumber", ch);

                ch = new OptionalNamedChild("locationIndicatorCallingParty", 24, CreateLocationIndicatorCallingParty, false, null);
                m_posChildren.Add(0x5F8643, ch);
                m_children.Add("locationIndicatorCallingParty", ch);

                ch = new OptionalNamedChild("locationIndicatorCalledParty", 25, CreateLocationIndicatorCalledParty, false, null);
                m_posChildren.Add(0x5F8644, ch);
                m_children.Add("locationIndicatorCalledParty", ch);

                ch = new OptionalNamedChild("typeofTermination", 26, CreateTypeofTermination, false, null);
                m_posChildren.Add(0x5F8645, ch);
                m_children.Add("typeofTermination", ch);

                ch = new OptionalNamedChild("locationNumber", 27, CreateLocationNumber, false, null);
                m_posChildren.Add(0x5F8646, ch);
                m_children.Add("locationNumber", ch);

                ch = new OptionalNamedChild("publicNumberCallingNumber", 28, CreatePublicNumberCallingNumber, false, null);
                m_posChildren.Add(0x5F8647, ch);
                m_children.Add("publicNumberCallingNumber", ch);

                ch = new OptionalNamedChild("transitCDRIndicator", 29, CreateTransitCDRIndicator, false, null);
                m_posChildren.Add(0x5F8648, ch);
                m_children.Add("transitCDRIndicator", ch);

            }
            public static CallIdentificationNumber CreateCallIdentificationNumber() { return new CallIdentificationNumber();}
            public static ChargedParty CreateChargedParty() { return new ChargedParty();}
            public static ChargingCase CreateChargingCase() { return new ChargingCase();}
            public static TariffClass CreateTariffClass() { return new TariffClass();}
            public static OutgoingRoute CreateOutgoingRoute() { return new OutgoingRoute();}
            public static IncomingRoute CreateIncomingRoute() { return new IncomingRoute();}
            public static EOSInfo CreateEOSInfo() { return new EOSInfo();}
            public static LastPartialOutput CreateLastPartialOutput() { return new LastPartialOutput();}
            public static PartialOutputRecNum CreatePartialOutputRecNum() { return new PartialOutputRecNum();}
            public static FaultCode CreateFaultCode() { return new FaultCode();}
            public static INMarkingofMS CreateINMarkingofMS() { return new INMarkingofMS();}
            public static AccountCode CreateAccountCode() { return new AccountCode();}
            public static TypeofNumber CreateTypeofNumber() { return new TypeofNumber();}
            public static NumberingPlanIndicator CreateNumberingPlanIndicator() { return new NumberingPlanIndicator();}
            public static TranslatedNumber CreateTranslatedNumber() { return new TranslatedNumber();}
            public static ServiceCode CreateServiceCode() { return new ServiceCode();}
            public static TypeofAccess CreateTypeofAccess() { return new TypeofAccess();}
            public static FunctionTrace CreateFunctionTrace() { return new FunctionTrace();}
            public static CallType CreateCallType() { return new CallType();}
            public static ServiceSubscriberId CreateServiceSubscriberId() { return new ServiceSubscriberId();}
            public static CostDistributionCode CreateCostDistributionCode() { return new CostDistributionCode();}
            public static ExtraCostDistributionCode CreateExtraCostDistributionCode() { return new ExtraCostDistributionCode();}
            public static PublicNumberCalledNumber CreatePublicNumberCalledNumber() { return new PublicNumberCalledNumber();}
            public static ExtraDestinationNumber CreateExtraDestinationNumber() { return new ExtraDestinationNumber();}
            public static LocationIndicatorCallingParty CreateLocationIndicatorCallingParty() { return new LocationIndicatorCallingParty();}
            public static LocationIndicatorCalledParty CreateLocationIndicatorCalledParty() { return new LocationIndicatorCalledParty();}
            public static TypeofTermination CreateTypeofTermination() { return new TypeofTermination();}
            public static LocationNumber CreateLocationNumber() { return new LocationNumber();}
            public static PublicNumberCallingNumber CreatePublicNumberCallingNumber() { return new PublicNumberCallingNumber();}
            public static TransitCDRIndicator CreateTransitCDRIndicator() { return new TransitCDRIndicator();}
        }
    }

    public partial class CdrType : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFF"},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F864A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F864A);
        }
    }

    public partial class MsgId : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                     "},
            {"Size","21"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F864B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F864B);
        }
    }

    public partial class MsgFrom : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                                "},
            {"Size","32"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F864C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F864C);
        }
    }

    public partial class MsgTo : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                                "},
            {"Size","32"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F864D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F864D);
        }
    }

    public partial class MsgSize : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFF"},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F864E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F864E);
        }
    }

    public partial class MsgOriginIndicator : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFF"},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F864F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F864F);
        }
    }

    public partial class ExternalApplicationAddress : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                                        "},
            {"Size","40"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8650);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8650);
        }
    }

    public partial class XTecnomenMMsCharging : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFF"},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8651);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8651);
        }
    }

    public partial class ServiceProviderId : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFF"},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8652);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8652);
        }
    }

    public partial class ParentMsgId : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                                "},
            {"Size","32"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8653);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8653);
        }
    }

    public partial class MsgNumRecipients : OSFBCDString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFF"},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8654);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8654);
        }
    }

    public partial class BIMSI : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","FFFFFFFFFFFFFFF"},
            {"Size","15"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8655);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8655);
        }
    }

    public partial class City_MMS : Asn1SequenceObject
    {

        public CdrType cdrType
        {
            get { return m_children[ClassDef.m_children["cdrType"].m_index] as CdrType; }
        }
        public CdrType Create_cdrType()
        {
            return CreateChild("cdrType") as CdrType;
        }

        public MsgId msgId
        {
            get { return m_children[ClassDef.m_children["msgId"].m_index] as MsgId; }
        }
        public MsgId Create_msgId()
        {
            return CreateChild("msgId") as MsgId;
        }

        public MsgFrom msgFrom
        {
            get { return m_children[ClassDef.m_children["msgFrom"].m_index] as MsgFrom; }
        }
        public MsgFrom Create_msgFrom()
        {
            return CreateChild("msgFrom") as MsgFrom;
        }

        public MsgTo msgTo
        {
            get { return m_children[ClassDef.m_children["msgTo"].m_index] as MsgTo; }
        }
        public MsgTo Create_msgTo()
        {
            return CreateChild("msgTo") as MsgTo;
        }

        public MsgSize msgSize
        {
            get { return m_children[ClassDef.m_children["msgSize"].m_index] as MsgSize; }
        }
        public MsgSize Create_msgSize()
        {
            return CreateChild("msgSize") as MsgSize;
        }

        public MsgOriginIndicator msgOriginIndicator
        {
            get { return m_children[ClassDef.m_children["msgOriginIndicator"].m_index] as MsgOriginIndicator; }
        }
        public MsgOriginIndicator Create_msgOriginIndicator()
        {
            return CreateChild("msgOriginIndicator") as MsgOriginIndicator;
        }

        public ExternalApplicationAddress externalApplicationAddress
        {
            get { return m_children[ClassDef.m_children["externalApplicationAddress"].m_index] as ExternalApplicationAddress; }
        }
        public ExternalApplicationAddress Create_externalApplicationAddress()
        {
            return CreateChild("externalApplicationAddress") as ExternalApplicationAddress;
        }

        public XTecnomenMMsCharging xTecnomenMMsCharging
        {
            get { return m_children[ClassDef.m_children["xTecnomenMMsCharging"].m_index] as XTecnomenMMsCharging; }
        }
        public XTecnomenMMsCharging Create_xTecnomenMMsCharging()
        {
            return CreateChild("xTecnomenMMsCharging") as XTecnomenMMsCharging;
        }

        public ServiceProviderId serviceProviderId
        {
            get { return m_children[ClassDef.m_children["serviceProviderId"].m_index] as ServiceProviderId; }
        }
        public ServiceProviderId Create_serviceProviderId()
        {
            return CreateChild("serviceProviderId") as ServiceProviderId;
        }

        public ParentMsgId parentMsgId
        {
            get { return m_children[ClassDef.m_children["parentMsgId"].m_index] as ParentMsgId; }
        }
        public ParentMsgId Create_parentMsgId()
        {
            return CreateChild("parentMsgId") as ParentMsgId;
        }

        public MsgNumRecipients msgNumRecipients
        {
            get { return m_children[ClassDef.m_children["msgNumRecipients"].m_index] as MsgNumRecipients; }
        }
        public MsgNumRecipients Create_msgNumRecipients()
        {
            return CreateChild("msgNumRecipients") as MsgNumRecipients;
        }

        public BIMSI bIMSI
        {
            get { return m_children[ClassDef.m_children["bIMSI"].m_index] as BIMSI; }
        }
        public BIMSI Create_bIMSI()
        {
            return CreateChild("bIMSI") as BIMSI;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8621);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8621);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new City_MMSClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public City_MMS()
        {
            m_children = new Asn1Object[12];
        }
        public class City_MMSClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public City_MMSClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("cdrType", 0, CreateCdrType, false, null);
                m_posChildren.Add(0x5F864A, ch);
                m_children.Add("cdrType", ch);

                ch = new OptionalNamedChild("msgId", 1, CreateMsgId, false, null);
                m_posChildren.Add(0x5F864B, ch);
                m_children.Add("msgId", ch);

                ch = new OptionalNamedChild("msgFrom", 2, CreateMsgFrom, false, null);
                m_posChildren.Add(0x5F864C, ch);
                m_children.Add("msgFrom", ch);

                ch = new OptionalNamedChild("msgTo", 3, CreateMsgTo, false, null);
                m_posChildren.Add(0x5F864D, ch);
                m_children.Add("msgTo", ch);

                ch = new OptionalNamedChild("msgSize", 4, CreateMsgSize, false, null);
                m_posChildren.Add(0x5F864E, ch);
                m_children.Add("msgSize", ch);

                ch = new OptionalNamedChild("msgOriginIndicator", 5, CreateMsgOriginIndicator, false, null);
                m_posChildren.Add(0x5F864F, ch);
                m_children.Add("msgOriginIndicator", ch);

                ch = new OptionalNamedChild("externalApplicationAddress", 6, CreateExternalApplicationAddress, false, null);
                m_posChildren.Add(0x5F8650, ch);
                m_children.Add("externalApplicationAddress", ch);

                ch = new OptionalNamedChild("xTecnomenMMsCharging", 7, CreateXTecnomenMMsCharging, false, null);
                m_posChildren.Add(0x5F8651, ch);
                m_children.Add("xTecnomenMMsCharging", ch);

                ch = new OptionalNamedChild("serviceProviderId", 8, CreateServiceProviderId, false, null);
                m_posChildren.Add(0x5F8652, ch);
                m_children.Add("serviceProviderId", ch);

                ch = new OptionalNamedChild("parentMsgId", 9, CreateParentMsgId, false, null);
                m_posChildren.Add(0x5F8653, ch);
                m_children.Add("parentMsgId", ch);

                ch = new OptionalNamedChild("msgNumRecipients", 10, CreateMsgNumRecipients, false, null);
                m_posChildren.Add(0x5F8654, ch);
                m_children.Add("msgNumRecipients", ch);

                ch = new OptionalNamedChild("bIMSI", 11, CreateBIMSI, false, null);
                m_posChildren.Add(0x5F8655, ch);
                m_children.Add("bIMSI", ch);

            }
            public static CdrType CreateCdrType() { return new CdrType();}
            public static MsgId CreateMsgId() { return new MsgId();}
            public static MsgFrom CreateMsgFrom() { return new MsgFrom();}
            public static MsgTo CreateMsgTo() { return new MsgTo();}
            public static MsgSize CreateMsgSize() { return new MsgSize();}
            public static MsgOriginIndicator CreateMsgOriginIndicator() { return new MsgOriginIndicator();}
            public static ExternalApplicationAddress CreateExternalApplicationAddress() { return new ExternalApplicationAddress();}
            public static XTecnomenMMsCharging CreateXTecnomenMMsCharging() { return new XTecnomenMMsCharging();}
            public static ServiceProviderId CreateServiceProviderId() { return new ServiceProviderId();}
            public static ParentMsgId CreateParentMsgId() { return new ParentMsgId();}
            public static MsgNumRecipients CreateMsgNumRecipients() { return new MsgNumRecipients();}
            public static BIMSI CreateBIMSI() { return new BIMSI();}
        }
    }

    public partial class CallIdentificationNumber_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","      "},
            {"Size","6"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8657);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8657);
        }
    }

    public partial class ChargedParty_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8658);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8658);
        }
    }

    public partial class ChargingCase_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","  "},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8659);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8659);
        }
    }

    public partial class TariffClass_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","    "},
            {"Size","4"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F865A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F865A);
        }
    }

    public partial class OutgoingRoute_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","       "},
            {"Size","7"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F865B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F865B);
        }
    }

    public partial class IncomingRoute_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","       "},
            {"Size","7"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F865C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F865C);
        }
    }

    public partial class EOSInfo_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F865D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F865D);
        }
    }

    public partial class LastPartialOutput_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F865E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F865E);
        }
    }

    public partial class PartialOutputRecNum_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F865F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F865F);
        }
    }

    public partial class FaultCode_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","  "},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8660);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8660);
        }
    }

    public partial class INMarkingOfMS : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8661);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8661);
        }
    }

    public partial class AccountCode_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","      "},
            {"Size","6"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8662);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8662);
        }
    }

    public partial class TypeOfNumber : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8663);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8663);
        }
    }

    public partial class NumperingPlanIndicator : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8664);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8664);
        }
    }

    public partial class TranslatedIndicator : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                   "},
            {"Size","19"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8665);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8665);
        }
    }

    public partial class ServiceCode_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8666);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8666);
        }
    }

    public partial class TypeOfAccess : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8667);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8667);
        }
    }

    public partial class FunctionTrace_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","              "},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8668);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8668);
        }
    }

    public partial class CallType_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8669);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8669);
        }
    }

    public partial class ServiceSubscriberId_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","              "},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F866A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F866A);
        }
    }

    public partial class CostDistributionCode_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","              "},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F866B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F866B);
        }
    }

    public partial class ExtraCostDistributionCode_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","              "},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F866C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F866C);
        }
    }

    public partial class PublicNumberCalledNumber_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","        "},
            {"Size","8"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F866D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F866D);
        }
    }

    public partial class ExtraDestinationNumber_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","        "},
            {"Size","8"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F866E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F866E);
        }
    }

    public partial class LocationIndicatorCallingParty_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F866F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F866F);
        }
    }

    public partial class LocationIndicatorCalledParty_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8670);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8670);
        }
    }

    public partial class TypeOfTermination : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8671);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8671);
        }
    }

    public partial class LocationNumber_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","              "},
            {"Size","14"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8672);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8672);
        }
    }

    public partial class PublicNumberCallingNumber_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","        "},
            {"Size","8"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8673);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8673);
        }
    }

    public partial class TransitCDRIndicator_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV"," "},
            {"Size","1"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8674);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8674);
        }
    }

    public partial class ServiceProviderName : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                        "},
            {"Size","24"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8675);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8675);
        }
    }

    public partial class ServiceDescription : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                        "},
            {"Size","24"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8676);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8676);
        }
    }

    public partial class ServiceCategoryID : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","   "},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8677);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8677);
        }
    }

    public partial class ServiceDescriptionID : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","   "},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8678);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8678);
        }
    }

    public partial class SGw_SMS : Asn1SequenceObject
    {

        public CallIdentificationNumber_1 callIdentificationNumber
        {
            get { return m_children[ClassDef.m_children["callIdentificationNumber"].m_index] as CallIdentificationNumber_1; }
        }
        public CallIdentificationNumber_1 Create_callIdentificationNumber()
        {
            return CreateChild("callIdentificationNumber") as CallIdentificationNumber_1;
        }

        public ChargedParty_1 chargedParty
        {
            get { return m_children[ClassDef.m_children["chargedParty"].m_index] as ChargedParty_1; }
        }
        public ChargedParty_1 Create_chargedParty()
        {
            return CreateChild("chargedParty") as ChargedParty_1;
        }

        public ChargingCase_1 chargingCase
        {
            get { return m_children[ClassDef.m_children["chargingCase"].m_index] as ChargingCase_1; }
        }
        public ChargingCase_1 Create_chargingCase()
        {
            return CreateChild("chargingCase") as ChargingCase_1;
        }

        public TariffClass_1 tariffClass
        {
            get { return m_children[ClassDef.m_children["tariffClass"].m_index] as TariffClass_1; }
        }
        public TariffClass_1 Create_tariffClass()
        {
            return CreateChild("tariffClass") as TariffClass_1;
        }

        public OutgoingRoute_1 outgoingRoute
        {
            get { return m_children[ClassDef.m_children["outgoingRoute"].m_index] as OutgoingRoute_1; }
        }
        public OutgoingRoute_1 Create_outgoingRoute()
        {
            return CreateChild("outgoingRoute") as OutgoingRoute_1;
        }

        public IncomingRoute_1 incomingRoute
        {
            get { return m_children[ClassDef.m_children["incomingRoute"].m_index] as IncomingRoute_1; }
        }
        public IncomingRoute_1 Create_incomingRoute()
        {
            return CreateChild("incomingRoute") as IncomingRoute_1;
        }

        public EOSInfo_1 eOSInfo
        {
            get { return m_children[ClassDef.m_children["eOSInfo"].m_index] as EOSInfo_1; }
        }
        public EOSInfo_1 Create_eOSInfo()
        {
            return CreateChild("eOSInfo") as EOSInfo_1;
        }

        public LastPartialOutput_1 lastPartialOutput
        {
            get { return m_children[ClassDef.m_children["lastPartialOutput"].m_index] as LastPartialOutput_1; }
        }
        public LastPartialOutput_1 Create_lastPartialOutput()
        {
            return CreateChild("lastPartialOutput") as LastPartialOutput_1;
        }

        public PartialOutputRecNum_1 partialOutputRecNum
        {
            get { return m_children[ClassDef.m_children["partialOutputRecNum"].m_index] as PartialOutputRecNum_1; }
        }
        public PartialOutputRecNum_1 Create_partialOutputRecNum()
        {
            return CreateChild("partialOutputRecNum") as PartialOutputRecNum_1;
        }

        public FaultCode_1 faultCode
        {
            get { return m_children[ClassDef.m_children["faultCode"].m_index] as FaultCode_1; }
        }
        public FaultCode_1 Create_faultCode()
        {
            return CreateChild("faultCode") as FaultCode_1;
        }

        public INMarkingOfMS iNMarkingOfMS
        {
            get { return m_children[ClassDef.m_children["iNMarkingOfMS"].m_index] as INMarkingOfMS; }
        }
        public INMarkingOfMS Create_iNMarkingOfMS()
        {
            return CreateChild("iNMarkingOfMS") as INMarkingOfMS;
        }

        public AccountCode_1 accountCode
        {
            get { return m_children[ClassDef.m_children["accountCode"].m_index] as AccountCode_1; }
        }
        public AccountCode_1 Create_accountCode()
        {
            return CreateChild("accountCode") as AccountCode_1;
        }

        public TypeOfNumber typeOfNumber
        {
            get { return m_children[ClassDef.m_children["typeOfNumber"].m_index] as TypeOfNumber; }
        }
        public TypeOfNumber Create_typeOfNumber()
        {
            return CreateChild("typeOfNumber") as TypeOfNumber;
        }

        public NumperingPlanIndicator numperingPlanIndicator
        {
            get { return m_children[ClassDef.m_children["numperingPlanIndicator"].m_index] as NumperingPlanIndicator; }
        }
        public NumperingPlanIndicator Create_numperingPlanIndicator()
        {
            return CreateChild("numperingPlanIndicator") as NumperingPlanIndicator;
        }

        public TranslatedIndicator translatedIndicator
        {
            get { return m_children[ClassDef.m_children["translatedIndicator"].m_index] as TranslatedIndicator; }
        }
        public TranslatedIndicator Create_translatedIndicator()
        {
            return CreateChild("translatedIndicator") as TranslatedIndicator;
        }

        public ServiceCode_1 serviceCode
        {
            get { return m_children[ClassDef.m_children["serviceCode"].m_index] as ServiceCode_1; }
        }
        public ServiceCode_1 Create_serviceCode()
        {
            return CreateChild("serviceCode") as ServiceCode_1;
        }

        public TypeOfAccess typeOfAccess
        {
            get { return m_children[ClassDef.m_children["typeOfAccess"].m_index] as TypeOfAccess; }
        }
        public TypeOfAccess Create_typeOfAccess()
        {
            return CreateChild("typeOfAccess") as TypeOfAccess;
        }

        public FunctionTrace_1 functionTrace
        {
            get { return m_children[ClassDef.m_children["functionTrace"].m_index] as FunctionTrace_1; }
        }
        public FunctionTrace_1 Create_functionTrace()
        {
            return CreateChild("functionTrace") as FunctionTrace_1;
        }

        public CallType_1 callType
        {
            get { return m_children[ClassDef.m_children["callType"].m_index] as CallType_1; }
        }
        public CallType_1 Create_callType()
        {
            return CreateChild("callType") as CallType_1;
        }

        public ServiceSubscriberId_1 serviceSubscriberId
        {
            get { return m_children[ClassDef.m_children["serviceSubscriberId"].m_index] as ServiceSubscriberId_1; }
        }
        public ServiceSubscriberId_1 Create_serviceSubscriberId()
        {
            return CreateChild("serviceSubscriberId") as ServiceSubscriberId_1;
        }

        public CostDistributionCode_1 costDistributionCode
        {
            get { return m_children[ClassDef.m_children["costDistributionCode"].m_index] as CostDistributionCode_1; }
        }
        public CostDistributionCode_1 Create_costDistributionCode()
        {
            return CreateChild("costDistributionCode") as CostDistributionCode_1;
        }

        public ExtraCostDistributionCode_1 extraCostDistributionCode
        {
            get { return m_children[ClassDef.m_children["extraCostDistributionCode"].m_index] as ExtraCostDistributionCode_1; }
        }
        public ExtraCostDistributionCode_1 Create_extraCostDistributionCode()
        {
            return CreateChild("extraCostDistributionCode") as ExtraCostDistributionCode_1;
        }

        public PublicNumberCalledNumber_1 publicNumberCalledNumber
        {
            get { return m_children[ClassDef.m_children["publicNumberCalledNumber"].m_index] as PublicNumberCalledNumber_1; }
        }
        public PublicNumberCalledNumber_1 Create_publicNumberCalledNumber()
        {
            return CreateChild("publicNumberCalledNumber") as PublicNumberCalledNumber_1;
        }

        public ExtraDestinationNumber_1 extraDestinationNumber
        {
            get { return m_children[ClassDef.m_children["extraDestinationNumber"].m_index] as ExtraDestinationNumber_1; }
        }
        public ExtraDestinationNumber_1 Create_extraDestinationNumber()
        {
            return CreateChild("extraDestinationNumber") as ExtraDestinationNumber_1;
        }

        public LocationIndicatorCallingParty_1 locationIndicatorCallingParty
        {
            get { return m_children[ClassDef.m_children["locationIndicatorCallingParty"].m_index] as LocationIndicatorCallingParty_1; }
        }
        public LocationIndicatorCallingParty_1 Create_locationIndicatorCallingParty()
        {
            return CreateChild("locationIndicatorCallingParty") as LocationIndicatorCallingParty_1;
        }

        public LocationIndicatorCalledParty_1 locationIndicatorCalledParty
        {
            get { return m_children[ClassDef.m_children["locationIndicatorCalledParty"].m_index] as LocationIndicatorCalledParty_1; }
        }
        public LocationIndicatorCalledParty_1 Create_locationIndicatorCalledParty()
        {
            return CreateChild("locationIndicatorCalledParty") as LocationIndicatorCalledParty_1;
        }

        public TypeOfTermination typeOfTermination
        {
            get { return m_children[ClassDef.m_children["typeOfTermination"].m_index] as TypeOfTermination; }
        }
        public TypeOfTermination Create_typeOfTermination()
        {
            return CreateChild("typeOfTermination") as TypeOfTermination;
        }

        public LocationNumber_1 locationNumber
        {
            get { return m_children[ClassDef.m_children["locationNumber"].m_index] as LocationNumber_1; }
        }
        public LocationNumber_1 Create_locationNumber()
        {
            return CreateChild("locationNumber") as LocationNumber_1;
        }

        public PublicNumberCallingNumber_1 publicNumberCallingNumber
        {
            get { return m_children[ClassDef.m_children["publicNumberCallingNumber"].m_index] as PublicNumberCallingNumber_1; }
        }
        public PublicNumberCallingNumber_1 Create_publicNumberCallingNumber()
        {
            return CreateChild("publicNumberCallingNumber") as PublicNumberCallingNumber_1;
        }

        public TransitCDRIndicator_1 transitCDRIndicator
        {
            get { return m_children[ClassDef.m_children["transitCDRIndicator"].m_index] as TransitCDRIndicator_1; }
        }
        public TransitCDRIndicator_1 Create_transitCDRIndicator()
        {
            return CreateChild("transitCDRIndicator") as TransitCDRIndicator_1;
        }

        public ServiceProviderName serviceProviderName
        {
            get { return m_children[ClassDef.m_children["serviceProviderName"].m_index] as ServiceProviderName; }
        }
        public ServiceProviderName Create_serviceProviderName()
        {
            return CreateChild("serviceProviderName") as ServiceProviderName;
        }

        public ServiceDescription serviceDescription
        {
            get { return m_children[ClassDef.m_children["serviceDescription"].m_index] as ServiceDescription; }
        }
        public ServiceDescription Create_serviceDescription()
        {
            return CreateChild("serviceDescription") as ServiceDescription;
        }

        public ServiceCategoryID serviceCategoryID
        {
            get { return m_children[ClassDef.m_children["serviceCategoryID"].m_index] as ServiceCategoryID; }
        }
        public ServiceCategoryID Create_serviceCategoryID()
        {
            return CreateChild("serviceCategoryID") as ServiceCategoryID;
        }

        public ServiceDescriptionID serviceDescriptionID
        {
            get { return m_children[ClassDef.m_children["serviceDescriptionID"].m_index] as ServiceDescriptionID; }
        }
        public ServiceDescriptionID Create_serviceDescriptionID()
        {
            return CreateChild("serviceDescriptionID") as ServiceDescriptionID;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8622);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8622);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new SGw_SMSClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public SGw_SMS()
        {
            m_children = new Asn1Object[34];
        }
        public class SGw_SMSClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public SGw_SMSClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("callIdentificationNumber", 0, CreateCallIdentificationNumber_1, false, null);
                m_posChildren.Add(0x5F8657, ch);
                m_children.Add("callIdentificationNumber", ch);

                ch = new OptionalNamedChild("chargedParty", 1, CreateChargedParty_1, false, null);
                m_posChildren.Add(0x5F8658, ch);
                m_children.Add("chargedParty", ch);

                ch = new OptionalNamedChild("chargingCase", 2, CreateChargingCase_1, false, null);
                m_posChildren.Add(0x5F8659, ch);
                m_children.Add("chargingCase", ch);

                ch = new OptionalNamedChild("tariffClass", 3, CreateTariffClass_1, false, null);
                m_posChildren.Add(0x5F865A, ch);
                m_children.Add("tariffClass", ch);

                ch = new OptionalNamedChild("outgoingRoute", 4, CreateOutgoingRoute_1, false, null);
                m_posChildren.Add(0x5F865B, ch);
                m_children.Add("outgoingRoute", ch);

                ch = new OptionalNamedChild("incomingRoute", 5, CreateIncomingRoute_1, false, null);
                m_posChildren.Add(0x5F865C, ch);
                m_children.Add("incomingRoute", ch);

                ch = new OptionalNamedChild("eOSInfo", 6, CreateEOSInfo_1, false, null);
                m_posChildren.Add(0x5F865D, ch);
                m_children.Add("eOSInfo", ch);

                ch = new OptionalNamedChild("lastPartialOutput", 7, CreateLastPartialOutput_1, false, null);
                m_posChildren.Add(0x5F865E, ch);
                m_children.Add("lastPartialOutput", ch);

                ch = new OptionalNamedChild("partialOutputRecNum", 8, CreatePartialOutputRecNum_1, false, null);
                m_posChildren.Add(0x5F865F, ch);
                m_children.Add("partialOutputRecNum", ch);

                ch = new OptionalNamedChild("faultCode", 9, CreateFaultCode_1, false, null);
                m_posChildren.Add(0x5F8660, ch);
                m_children.Add("faultCode", ch);

                ch = new OptionalNamedChild("iNMarkingOfMS", 10, CreateINMarkingOfMS, false, null);
                m_posChildren.Add(0x5F8661, ch);
                m_children.Add("iNMarkingOfMS", ch);

                ch = new OptionalNamedChild("accountCode", 11, CreateAccountCode_1, false, null);
                m_posChildren.Add(0x5F8662, ch);
                m_children.Add("accountCode", ch);

                ch = new OptionalNamedChild("typeOfNumber", 12, CreateTypeOfNumber, false, null);
                m_posChildren.Add(0x5F8663, ch);
                m_children.Add("typeOfNumber", ch);

                ch = new OptionalNamedChild("numperingPlanIndicator", 13, CreateNumperingPlanIndicator, false, null);
                m_posChildren.Add(0x5F8664, ch);
                m_children.Add("numperingPlanIndicator", ch);

                ch = new OptionalNamedChild("translatedIndicator", 14, CreateTranslatedIndicator, false, null);
                m_posChildren.Add(0x5F8665, ch);
                m_children.Add("translatedIndicator", ch);

                ch = new OptionalNamedChild("serviceCode", 15, CreateServiceCode_1, false, null);
                m_posChildren.Add(0x5F8666, ch);
                m_children.Add("serviceCode", ch);

                ch = new OptionalNamedChild("typeOfAccess", 16, CreateTypeOfAccess, false, null);
                m_posChildren.Add(0x5F8667, ch);
                m_children.Add("typeOfAccess", ch);

                ch = new OptionalNamedChild("functionTrace", 17, CreateFunctionTrace_1, false, null);
                m_posChildren.Add(0x5F8668, ch);
                m_children.Add("functionTrace", ch);

                ch = new OptionalNamedChild("callType", 18, CreateCallType_1, false, null);
                m_posChildren.Add(0x5F8669, ch);
                m_children.Add("callType", ch);

                ch = new OptionalNamedChild("serviceSubscriberId", 19, CreateServiceSubscriberId_1, false, null);
                m_posChildren.Add(0x5F866A, ch);
                m_children.Add("serviceSubscriberId", ch);

                ch = new OptionalNamedChild("costDistributionCode", 20, CreateCostDistributionCode_1, false, null);
                m_posChildren.Add(0x5F866B, ch);
                m_children.Add("costDistributionCode", ch);

                ch = new OptionalNamedChild("extraCostDistributionCode", 21, CreateExtraCostDistributionCode_1, false, null);
                m_posChildren.Add(0x5F866C, ch);
                m_children.Add("extraCostDistributionCode", ch);

                ch = new OptionalNamedChild("publicNumberCalledNumber", 22, CreatePublicNumberCalledNumber_1, false, null);
                m_posChildren.Add(0x5F866D, ch);
                m_children.Add("publicNumberCalledNumber", ch);

                ch = new OptionalNamedChild("extraDestinationNumber", 23, CreateExtraDestinationNumber_1, false, null);
                m_posChildren.Add(0x5F866E, ch);
                m_children.Add("extraDestinationNumber", ch);

                ch = new OptionalNamedChild("locationIndicatorCallingParty", 24, CreateLocationIndicatorCallingParty_1, false, null);
                m_posChildren.Add(0x5F866F, ch);
                m_children.Add("locationIndicatorCallingParty", ch);

                ch = new OptionalNamedChild("locationIndicatorCalledParty", 25, CreateLocationIndicatorCalledParty_1, false, null);
                m_posChildren.Add(0x5F8670, ch);
                m_children.Add("locationIndicatorCalledParty", ch);

                ch = new OptionalNamedChild("typeOfTermination", 26, CreateTypeOfTermination, false, null);
                m_posChildren.Add(0x5F8671, ch);
                m_children.Add("typeOfTermination", ch);

                ch = new OptionalNamedChild("locationNumber", 27, CreateLocationNumber_1, false, null);
                m_posChildren.Add(0x5F8672, ch);
                m_children.Add("locationNumber", ch);

                ch = new OptionalNamedChild("publicNumberCallingNumber", 28, CreatePublicNumberCallingNumber_1, false, null);
                m_posChildren.Add(0x5F8673, ch);
                m_children.Add("publicNumberCallingNumber", ch);

                ch = new OptionalNamedChild("transitCDRIndicator", 29, CreateTransitCDRIndicator_1, false, null);
                m_posChildren.Add(0x5F8674, ch);
                m_children.Add("transitCDRIndicator", ch);

                ch = new OptionalNamedChild("serviceProviderName", 30, CreateServiceProviderName, false, null);
                m_posChildren.Add(0x5F8675, ch);
                m_children.Add("serviceProviderName", ch);

                ch = new OptionalNamedChild("serviceDescription", 31, CreateServiceDescription, false, null);
                m_posChildren.Add(0x5F8676, ch);
                m_children.Add("serviceDescription", ch);

                ch = new OptionalNamedChild("serviceCategoryID", 32, CreateServiceCategoryID, false, null);
                m_posChildren.Add(0x5F8677, ch);
                m_children.Add("serviceCategoryID", ch);

                ch = new OptionalNamedChild("serviceDescriptionID", 33, CreateServiceDescriptionID, false, null);
                m_posChildren.Add(0x5F8678, ch);
                m_children.Add("serviceDescriptionID", ch);

            }
            public static CallIdentificationNumber_1 CreateCallIdentificationNumber_1() { return new CallIdentificationNumber_1();}
            public static ChargedParty_1 CreateChargedParty_1() { return new ChargedParty_1();}
            public static ChargingCase_1 CreateChargingCase_1() { return new ChargingCase_1();}
            public static TariffClass_1 CreateTariffClass_1() { return new TariffClass_1();}
            public static OutgoingRoute_1 CreateOutgoingRoute_1() { return new OutgoingRoute_1();}
            public static IncomingRoute_1 CreateIncomingRoute_1() { return new IncomingRoute_1();}
            public static EOSInfo_1 CreateEOSInfo_1() { return new EOSInfo_1();}
            public static LastPartialOutput_1 CreateLastPartialOutput_1() { return new LastPartialOutput_1();}
            public static PartialOutputRecNum_1 CreatePartialOutputRecNum_1() { return new PartialOutputRecNum_1();}
            public static FaultCode_1 CreateFaultCode_1() { return new FaultCode_1();}
            public static INMarkingOfMS CreateINMarkingOfMS() { return new INMarkingOfMS();}
            public static AccountCode_1 CreateAccountCode_1() { return new AccountCode_1();}
            public static TypeOfNumber CreateTypeOfNumber() { return new TypeOfNumber();}
            public static NumperingPlanIndicator CreateNumperingPlanIndicator() { return new NumperingPlanIndicator();}
            public static TranslatedIndicator CreateTranslatedIndicator() { return new TranslatedIndicator();}
            public static ServiceCode_1 CreateServiceCode_1() { return new ServiceCode_1();}
            public static TypeOfAccess CreateTypeOfAccess() { return new TypeOfAccess();}
            public static FunctionTrace_1 CreateFunctionTrace_1() { return new FunctionTrace_1();}
            public static CallType_1 CreateCallType_1() { return new CallType_1();}
            public static ServiceSubscriberId_1 CreateServiceSubscriberId_1() { return new ServiceSubscriberId_1();}
            public static CostDistributionCode_1 CreateCostDistributionCode_1() { return new CostDistributionCode_1();}
            public static ExtraCostDistributionCode_1 CreateExtraCostDistributionCode_1() { return new ExtraCostDistributionCode_1();}
            public static PublicNumberCalledNumber_1 CreatePublicNumberCalledNumber_1() { return new PublicNumberCalledNumber_1();}
            public static ExtraDestinationNumber_1 CreateExtraDestinationNumber_1() { return new ExtraDestinationNumber_1();}
            public static LocationIndicatorCallingParty_1 CreateLocationIndicatorCallingParty_1() { return new LocationIndicatorCallingParty_1();}
            public static LocationIndicatorCalledParty_1 CreateLocationIndicatorCalledParty_1() { return new LocationIndicatorCalledParty_1();}
            public static TypeOfTermination CreateTypeOfTermination() { return new TypeOfTermination();}
            public static LocationNumber_1 CreateLocationNumber_1() { return new LocationNumber_1();}
            public static PublicNumberCallingNumber_1 CreatePublicNumberCallingNumber_1() { return new PublicNumberCallingNumber_1();}
            public static TransitCDRIndicator_1 CreateTransitCDRIndicator_1() { return new TransitCDRIndicator_1();}
            public static ServiceProviderName CreateServiceProviderName() { return new ServiceProviderName();}
            public static ServiceDescription CreateServiceDescription() { return new ServiceDescription();}
            public static ServiceCategoryID CreateServiceCategoryID() { return new ServiceCategoryID();}
            public static ServiceDescriptionID CreateServiceDescriptionID() { return new ServiceDescriptionID();}
        }
    }

    public partial class CdrType_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","    "},
            {"Size","4"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F867A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F867A);
        }
    }

    public partial class MsgId_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                     "},
            {"Size","21"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F867B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F867B);
        }
    }

    public partial class MsgFrom_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                                "},
            {"Size","32"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F867C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F867C);
        }
    }

    public partial class MsgTo_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                                "},
            {"Size","32"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F867D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F867D);
        }
    }

    public partial class MsgSize_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","      "},
            {"Size","6"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F867E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F867E);
        }
    }

    public partial class MsgOriginIndicator_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","  "},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F867F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F867F);
        }
    }

    public partial class ExternalApplicationAddress_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                                        "},
            {"Size","40"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8700);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8700);
        }
    }

    public partial class MMsCharging : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","   "},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8701);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8701);
        }
    }

    public partial class ServiceProviderId_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","    "},
            {"Size","4"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8702);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8702);
        }
    }

    public partial class ParentMsgId_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                                "},
            {"Size","32"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8703);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8703);
        }
    }

    public partial class MsgNumRecipients_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","     "},
            {"Size","5"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8704);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8704);
        }
    }

    public partial class BIMSI_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","               "},
            {"Size","15"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8705);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8705);
        }
    }

    public partial class ServiceProviderName_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                        "},
            {"Size","24"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8706);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8706);
        }
    }

    public partial class ServiceDescription_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","                        "},
            {"Size","24"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8707);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8707);
        }
    }

    public partial class ServiceCategoryID_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","   "},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8708);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8708);
        }
    }

    public partial class ServiceDescriptionID_1 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","   "},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8709);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8709);
        }
    }

    public partial class SGw_MMS : Asn1SequenceObject
    {

        public CdrType_1 cdrType
        {
            get { return m_children[ClassDef.m_children["cdrType"].m_index] as CdrType_1; }
        }
        public CdrType_1 Create_cdrType()
        {
            return CreateChild("cdrType") as CdrType_1;
        }

        public MsgId_1 msgId
        {
            get { return m_children[ClassDef.m_children["msgId"].m_index] as MsgId_1; }
        }
        public MsgId_1 Create_msgId()
        {
            return CreateChild("msgId") as MsgId_1;
        }

        public MsgFrom_1 msgFrom
        {
            get { return m_children[ClassDef.m_children["msgFrom"].m_index] as MsgFrom_1; }
        }
        public MsgFrom_1 Create_msgFrom()
        {
            return CreateChild("msgFrom") as MsgFrom_1;
        }

        public MsgTo_1 msgTo
        {
            get { return m_children[ClassDef.m_children["msgTo"].m_index] as MsgTo_1; }
        }
        public MsgTo_1 Create_msgTo()
        {
            return CreateChild("msgTo") as MsgTo_1;
        }

        public MsgSize_1 msgSize
        {
            get { return m_children[ClassDef.m_children["msgSize"].m_index] as MsgSize_1; }
        }
        public MsgSize_1 Create_msgSize()
        {
            return CreateChild("msgSize") as MsgSize_1;
        }

        public MsgOriginIndicator_1 msgOriginIndicator
        {
            get { return m_children[ClassDef.m_children["msgOriginIndicator"].m_index] as MsgOriginIndicator_1; }
        }
        public MsgOriginIndicator_1 Create_msgOriginIndicator()
        {
            return CreateChild("msgOriginIndicator") as MsgOriginIndicator_1;
        }

        public ExternalApplicationAddress_1 externalApplicationAddress
        {
            get { return m_children[ClassDef.m_children["externalApplicationAddress"].m_index] as ExternalApplicationAddress_1; }
        }
        public ExternalApplicationAddress_1 Create_externalApplicationAddress()
        {
            return CreateChild("externalApplicationAddress") as ExternalApplicationAddress_1;
        }

        public MMsCharging mMsCharging
        {
            get { return m_children[ClassDef.m_children["mMsCharging"].m_index] as MMsCharging; }
        }
        public MMsCharging Create_mMsCharging()
        {
            return CreateChild("mMsCharging") as MMsCharging;
        }

        public ServiceProviderId_1 serviceProviderId
        {
            get { return m_children[ClassDef.m_children["serviceProviderId"].m_index] as ServiceProviderId_1; }
        }
        public ServiceProviderId_1 Create_serviceProviderId()
        {
            return CreateChild("serviceProviderId") as ServiceProviderId_1;
        }

        public ParentMsgId_1 parentMsgId
        {
            get { return m_children[ClassDef.m_children["parentMsgId"].m_index] as ParentMsgId_1; }
        }
        public ParentMsgId_1 Create_parentMsgId()
        {
            return CreateChild("parentMsgId") as ParentMsgId_1;
        }

        public MsgNumRecipients_1 msgNumRecipients
        {
            get { return m_children[ClassDef.m_children["msgNumRecipients"].m_index] as MsgNumRecipients_1; }
        }
        public MsgNumRecipients_1 Create_msgNumRecipients()
        {
            return CreateChild("msgNumRecipients") as MsgNumRecipients_1;
        }

        public BIMSI_1 bIMSI
        {
            get { return m_children[ClassDef.m_children["bIMSI"].m_index] as BIMSI_1; }
        }
        public BIMSI_1 Create_bIMSI()
        {
            return CreateChild("bIMSI") as BIMSI_1;
        }

        public ServiceProviderName_1 serviceProviderName
        {
            get { return m_children[ClassDef.m_children["serviceProviderName"].m_index] as ServiceProviderName_1; }
        }
        public ServiceProviderName_1 Create_serviceProviderName()
        {
            return CreateChild("serviceProviderName") as ServiceProviderName_1;
        }

        public ServiceDescription_1 serviceDescription
        {
            get { return m_children[ClassDef.m_children["serviceDescription"].m_index] as ServiceDescription_1; }
        }
        public ServiceDescription_1 Create_serviceDescription()
        {
            return CreateChild("serviceDescription") as ServiceDescription_1;
        }

        public ServiceCategoryID_1 serviceCategoryID
        {
            get { return m_children[ClassDef.m_children["serviceCategoryID"].m_index] as ServiceCategoryID_1; }
        }
        public ServiceCategoryID_1 Create_serviceCategoryID()
        {
            return CreateChild("serviceCategoryID") as ServiceCategoryID_1;
        }

        public ServiceDescriptionID_1 serviceDescriptionID
        {
            get { return m_children[ClassDef.m_children["serviceDescriptionID"].m_index] as ServiceDescriptionID_1; }
        }
        public ServiceDescriptionID_1 Create_serviceDescriptionID()
        {
            return CreateChild("serviceDescriptionID") as ServiceDescriptionID_1;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8623);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8623);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new SGw_MMSClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public SGw_MMS()
        {
            m_children = new Asn1Object[16];
        }
        public class SGw_MMSClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public SGw_MMSClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("cdrType", 0, CreateCdrType_1, false, null);
                m_posChildren.Add(0x5F867A, ch);
                m_children.Add("cdrType", ch);

                ch = new OptionalNamedChild("msgId", 1, CreateMsgId_1, false, null);
                m_posChildren.Add(0x5F867B, ch);
                m_children.Add("msgId", ch);

                ch = new OptionalNamedChild("msgFrom", 2, CreateMsgFrom_1, false, null);
                m_posChildren.Add(0x5F867C, ch);
                m_children.Add("msgFrom", ch);

                ch = new OptionalNamedChild("msgTo", 3, CreateMsgTo_1, false, null);
                m_posChildren.Add(0x5F867D, ch);
                m_children.Add("msgTo", ch);

                ch = new OptionalNamedChild("msgSize", 4, CreateMsgSize_1, false, null);
                m_posChildren.Add(0x5F867E, ch);
                m_children.Add("msgSize", ch);

                ch = new OptionalNamedChild("msgOriginIndicator", 5, CreateMsgOriginIndicator_1, false, null);
                m_posChildren.Add(0x5F867F, ch);
                m_children.Add("msgOriginIndicator", ch);

                ch = new OptionalNamedChild("externalApplicationAddress", 6, CreateExternalApplicationAddress_1, false, null);
                m_posChildren.Add(0x5F8700, ch);
                m_children.Add("externalApplicationAddress", ch);

                ch = new OptionalNamedChild("mMsCharging", 7, CreateMMsCharging, false, null);
                m_posChildren.Add(0x5F8701, ch);
                m_children.Add("mMsCharging", ch);

                ch = new OptionalNamedChild("serviceProviderId", 8, CreateServiceProviderId_1, false, null);
                m_posChildren.Add(0x5F8702, ch);
                m_children.Add("serviceProviderId", ch);

                ch = new OptionalNamedChild("parentMsgId", 9, CreateParentMsgId_1, false, null);
                m_posChildren.Add(0x5F8703, ch);
                m_children.Add("parentMsgId", ch);

                ch = new OptionalNamedChild("msgNumRecipients", 10, CreateMsgNumRecipients_1, false, null);
                m_posChildren.Add(0x5F8704, ch);
                m_children.Add("msgNumRecipients", ch);

                ch = new OptionalNamedChild("bIMSI", 11, CreateBIMSI_1, false, null);
                m_posChildren.Add(0x5F8705, ch);
                m_children.Add("bIMSI", ch);

                ch = new OptionalNamedChild("serviceProviderName", 12, CreateServiceProviderName_1, false, null);
                m_posChildren.Add(0x5F8706, ch);
                m_children.Add("serviceProviderName", ch);

                ch = new OptionalNamedChild("serviceDescription", 13, CreateServiceDescription_1, false, null);
                m_posChildren.Add(0x5F8707, ch);
                m_children.Add("serviceDescription", ch);

                ch = new OptionalNamedChild("serviceCategoryID", 14, CreateServiceCategoryID_1, false, null);
                m_posChildren.Add(0x5F8708, ch);
                m_children.Add("serviceCategoryID", ch);

                ch = new OptionalNamedChild("serviceDescriptionID", 15, CreateServiceDescriptionID_1, false, null);
                m_posChildren.Add(0x5F8709, ch);
                m_children.Add("serviceDescriptionID", ch);

            }
            public static CdrType_1 CreateCdrType_1() { return new CdrType_1();}
            public static MsgId_1 CreateMsgId_1() { return new MsgId_1();}
            public static MsgFrom_1 CreateMsgFrom_1() { return new MsgFrom_1();}
            public static MsgTo_1 CreateMsgTo_1() { return new MsgTo_1();}
            public static MsgSize_1 CreateMsgSize_1() { return new MsgSize_1();}
            public static MsgOriginIndicator_1 CreateMsgOriginIndicator_1() { return new MsgOriginIndicator_1();}
            public static ExternalApplicationAddress_1 CreateExternalApplicationAddress_1() { return new ExternalApplicationAddress_1();}
            public static MMsCharging CreateMMsCharging() { return new MMsCharging();}
            public static ServiceProviderId_1 CreateServiceProviderId_1() { return new ServiceProviderId_1();}
            public static ParentMsgId_1 CreateParentMsgId_1() { return new ParentMsgId_1();}
            public static MsgNumRecipients_1 CreateMsgNumRecipients_1() { return new MsgNumRecipients_1();}
            public static BIMSI_1 CreateBIMSI_1() { return new BIMSI_1();}
            public static ServiceProviderName_1 CreateServiceProviderName_1() { return new ServiceProviderName_1();}
            public static ServiceDescription_1 CreateServiceDescription_1() { return new ServiceDescription_1();}
            public static ServiceCategoryID_1 CreateServiceCategoryID_1() { return new ServiceCategoryID_1();}
            public static ServiceDescriptionID_1 CreateServiceDescriptionID_1() { return new ServiceDescriptionID_1();}
        }
    }

    public partial class CDRType : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","  "},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F870B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F870B);
        }
    }

    public partial class SubscriberType : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","  "},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F870C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F870C);
        }
    }

    public partial class ErrorCode : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","    "},
            {"Size","4"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F870D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F870D);
        }
    }

    public partial class AccessType : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","  "},
            {"Size","2"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F870E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F870E);
        }
    }

    public partial class TariffClass_2 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","    "},
            {"Size","4"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F870F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F870F);
        }
    }

    public partial class ServiceCategoryID_2 : OSFAsciiString
    {
        private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()
        {
            {"DV","   "},
            {"Size","3"},
        };
        public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8710);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8710);
        }
    }

    public partial class SGw_WAP : Asn1SequenceObject
    {

        public CDRType cDRType
        {
            get { return m_children[ClassDef.m_children["cDRType"].m_index] as CDRType; }
        }
        public CDRType Create_cDRType()
        {
            return CreateChild("cDRType") as CDRType;
        }

        public SubscriberType subscriberType
        {
            get { return m_children[ClassDef.m_children["subscriberType"].m_index] as SubscriberType; }
        }
        public SubscriberType Create_subscriberType()
        {
            return CreateChild("subscriberType") as SubscriberType;
        }

        public ErrorCode errorCode
        {
            get { return m_children[ClassDef.m_children["errorCode"].m_index] as ErrorCode; }
        }
        public ErrorCode Create_errorCode()
        {
            return CreateChild("errorCode") as ErrorCode;
        }

        public AccessType accessType
        {
            get { return m_children[ClassDef.m_children["accessType"].m_index] as AccessType; }
        }
        public AccessType Create_accessType()
        {
            return CreateChild("accessType") as AccessType;
        }

        public TariffClass_2 tariffClass
        {
            get { return m_children[ClassDef.m_children["tariffClass"].m_index] as TariffClass_2; }
        }
        public TariffClass_2 Create_tariffClass()
        {
            return CreateChild("tariffClass") as TariffClass_2;
        }

        public ServiceCategoryID_2 serviceCategoryID
        {
            get { return m_children[ClassDef.m_children["serviceCategoryID"].m_index] as ServiceCategoryID_2; }
        }
        public ServiceCategoryID_2 Create_serviceCategoryID()
        {
            return CreateChild("serviceCategoryID") as ServiceCategoryID_2;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8624);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8624);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new SGw_WAPClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public SGw_WAP()
        {
            m_children = new Asn1Object[6];
        }
        public class SGw_WAPClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public SGw_WAPClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("cDRType", 0, CreateCDRType, false, null);
                m_posChildren.Add(0x5F870B, ch);
                m_children.Add("cDRType", ch);

                ch = new OptionalNamedChild("subscriberType", 1, CreateSubscriberType, false, null);
                m_posChildren.Add(0x5F870C, ch);
                m_children.Add("subscriberType", ch);

                ch = new OptionalNamedChild("errorCode", 2, CreateErrorCode, false, null);
                m_posChildren.Add(0x5F870D, ch);
                m_children.Add("errorCode", ch);

                ch = new OptionalNamedChild("accessType", 3, CreateAccessType, false, null);
                m_posChildren.Add(0x5F870E, ch);
                m_children.Add("accessType", ch);

                ch = new OptionalNamedChild("tariffClass", 4, CreateTariffClass_2, false, null);
                m_posChildren.Add(0x5F870F, ch);
                m_children.Add("tariffClass", ch);

                ch = new OptionalNamedChild("serviceCategoryID", 5, CreateServiceCategoryID_2, false, null);
                m_posChildren.Add(0x5F8710, ch);
                m_children.Add("serviceCategoryID", ch);

            }
            public static CDRType CreateCDRType() { return new CDRType();}
            public static SubscriberType CreateSubscriberType() { return new SubscriberType();}
            public static ErrorCode CreateErrorCode() { return new ErrorCode();}
            public static AccessType CreateAccessType() { return new AccessType();}
            public static TariffClass_2 CreateTariffClass_2() { return new TariffClass_2();}
            public static ServiceCategoryID_2 CreateServiceCategoryID_2() { return new ServiceCategoryID_2();}
        }
    }

    public partial class DataInterChange : Asn1ChoiceObject
    {

        public TransferBatch transferBatch
        {
            get { return m_children[ClassDef.m_children["transferBatch"].m_index] as TransferBatch; }
        }
        public TransferBatch Create_transferBatch()
        {
            return CreateChild("transferBatch") as TransferBatch;
        }

        public Notification notification
        {
            get { return m_children[ClassDef.m_children["notification"].m_index] as Notification; }
        }
        public Notification Create_notification()
        {
            return CreateChild("notification") as Notification;
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new DataInterChangeClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public DataInterChange()
        {
            m_children = new Asn1Object[2];
        }
        public class DataInterChangeClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public DataInterChangeClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("transferBatch", 0, CreateTransferBatch);
                m_posChildren.Add(0x41, ch);
                m_children.Add("transferBatch", ch);
                ch = new NamedChild("notification", 1, CreateNotification);
                m_posChildren.Add(0x42, ch);
                m_children.Add("notification", ch);
            }
            public static TransferBatch CreateTransferBatch() { return new TransferBatch();}
            public static Notification CreateNotification() { return new Notification();}
        }
    }

    public partial class TransferBatch : Asn1SequenceObject
    {

        public BatchControlInfo batchControlInfo
        {
            get { return m_children[ClassDef.m_children["batchControlInfo"].m_index] as BatchControlInfo; }
        }
        public BatchControlInfo Create_batchControlInfo()
        {
            return CreateChild("batchControlInfo") as BatchControlInfo;
        }

        public AccountingInfo accountingInfo
        {
            get { return m_children[ClassDef.m_children["accountingInfo"].m_index] as AccountingInfo; }
        }
        public AccountingInfo Create_accountingInfo()
        {
            return CreateChild("accountingInfo") as AccountingInfo;
        }

        public NetworkInfo networkInfo
        {
            get { return m_children[ClassDef.m_children["networkInfo"].m_index] as NetworkInfo; }
        }
        public NetworkInfo Create_networkInfo()
        {
            return CreateChild("networkInfo") as NetworkInfo;
        }

        public MessageDescriptionInfoList messageDescriptionInfo
        {
            get { return m_children[ClassDef.m_children["messageDescriptionInfo"].m_index] as MessageDescriptionInfoList; }
        }
        public MessageDescriptionInfoList Create_messageDescriptionInfo()
        {
            return CreateChild("messageDescriptionInfo") as MessageDescriptionInfoList;
        }

        public CallEventDetailList callEventDetails
        {
            get { return m_children[ClassDef.m_children["callEventDetails"].m_index] as CallEventDetailList; }
        }
        public CallEventDetailList Create_callEventDetails()
        {
            return CreateChild("callEventDetails") as CallEventDetailList;
        }

        public AuditControlInfo auditControlInfo
        {
            get { return m_children[ClassDef.m_children["auditControlInfo"].m_index] as AuditControlInfo; }
        }
        public AuditControlInfo Create_auditControlInfo()
        {
            return CreateChild("auditControlInfo") as AuditControlInfo;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x41);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x41);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TransferBatchClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TransferBatch()
        {
            m_children = new Asn1Object[6];
        }
        public class TransferBatchClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TransferBatchClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("batchControlInfo", 0, CreateBatchControlInfo, true, null);
                m_posChildren.Add(0x44, ch);
                m_children.Add("batchControlInfo", ch);

                ch = new OptionalNamedChild("accountingInfo", 1, CreateAccountingInfo, true, null);
                m_posChildren.Add(0x45, ch);
                m_children.Add("accountingInfo", ch);

                ch = new OptionalNamedChild("networkInfo", 2, CreateNetworkInfo, true, null);
                m_posChildren.Add(0x46, ch);
                m_children.Add("networkInfo", ch);

                ch = new OptionalNamedChild("messageDescriptionInfo", 3, CreateMessageDescriptionInfoList, true, null);
                m_posChildren.Add(0x48, ch);
                m_children.Add("messageDescriptionInfo", ch);

                ch = new OptionalNamedChild("callEventDetails", 4, CreateCallEventDetailList, true, null);
                m_posChildren.Add(0x43, ch);
                m_children.Add("callEventDetails", ch);

                ch = new OptionalNamedChild("auditControlInfo", 5, CreateAuditControlInfo, true, null);
                m_posChildren.Add(0x4F, ch);
                m_children.Add("auditControlInfo", ch);

            }
            public static BatchControlInfo CreateBatchControlInfo() { return new BatchControlInfo();}
            public static AccountingInfo CreateAccountingInfo() { return new AccountingInfo();}
            public static NetworkInfo CreateNetworkInfo() { return new NetworkInfo();}
            public static MessageDescriptionInfoList CreateMessageDescriptionInfoList() { return new MessageDescriptionInfoList();}
            public static CallEventDetailList CreateCallEventDetailList() { return new CallEventDetailList();}
            public static AuditControlInfo CreateAuditControlInfo() { return new AuditControlInfo();}
        }
    }

    public partial class Notification : Asn1SequenceObject
    {

        public Sender sender
        {
            get { return m_children[ClassDef.m_children["sender"].m_index] as Sender; }
        }
        public Sender Create_sender()
        {
            return CreateChild("sender") as Sender;
        }

        public Recipient recipient
        {
            get { return m_children[ClassDef.m_children["recipient"].m_index] as Recipient; }
        }
        public Recipient Create_recipient()
        {
            return CreateChild("recipient") as Recipient;
        }

        public FileSequenceNumber fileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["fileSequenceNumber"].m_index] as FileSequenceNumber; }
        }
        public FileSequenceNumber Create_fileSequenceNumber()
        {
            return CreateChild("fileSequenceNumber") as FileSequenceNumber;
        }

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public FileCreationTimeStamp fileCreationTimeStamp
        {
            get { return m_children[ClassDef.m_children["fileCreationTimeStamp"].m_index] as FileCreationTimeStamp; }
        }
        public FileCreationTimeStamp Create_fileCreationTimeStamp()
        {
            return CreateChild("fileCreationTimeStamp") as FileCreationTimeStamp;
        }

        public FileAvailableTimeStamp fileAvailableTimeStamp
        {
            get { return m_children[ClassDef.m_children["fileAvailableTimeStamp"].m_index] as FileAvailableTimeStamp; }
        }
        public FileAvailableTimeStamp Create_fileAvailableTimeStamp()
        {
            return CreateChild("fileAvailableTimeStamp") as FileAvailableTimeStamp;
        }

        public TransferCutOffTimeStamp transferCutOffTimeStamp
        {
            get { return m_children[ClassDef.m_children["transferCutOffTimeStamp"].m_index] as TransferCutOffTimeStamp; }
        }
        public TransferCutOffTimeStamp Create_transferCutOffTimeStamp()
        {
            return CreateChild("transferCutOffTimeStamp") as TransferCutOffTimeStamp;
        }

        public SpecificationVersionNumber specificationVersionNumber
        {
            get { return m_children[ClassDef.m_children["specificationVersionNumber"].m_index] as SpecificationVersionNumber; }
        }
        public SpecificationVersionNumber Create_specificationVersionNumber()
        {
            return CreateChild("specificationVersionNumber") as SpecificationVersionNumber;
        }

        public ReleaseVersionNumber releaseVersionNumber
        {
            get { return m_children[ClassDef.m_children["releaseVersionNumber"].m_index] as ReleaseVersionNumber; }
        }
        public ReleaseVersionNumber Create_releaseVersionNumber()
        {
            return CreateChild("releaseVersionNumber") as ReleaseVersionNumber;
        }

        public FileTypeIndicator fileTypeIndicator
        {
            get { return m_children[ClassDef.m_children["fileTypeIndicator"].m_index] as FileTypeIndicator; }
        }
        public FileTypeIndicator Create_fileTypeIndicator()
        {
            return CreateChild("fileTypeIndicator") as FileTypeIndicator;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x42);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x42);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new NotificationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Notification()
        {
            m_children = new Asn1Object[11];
        }
        public class NotificationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public NotificationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("sender", 0, CreateSender, true, null);
                m_posChildren.Add(0x5F8144, ch);
                m_children.Add("sender", ch);

                ch = new OptionalNamedChild("recipient", 1, CreateRecipient, true, null);
                m_posChildren.Add(0x5F8136, ch);
                m_children.Add("recipient", ch);

                ch = new OptionalNamedChild("fileSequenceNumber", 2, CreateFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F6D, ch);
                m_children.Add("fileSequenceNumber", ch);

                ch = new OptionalNamedChild("rapFileSequenceNumber", 3, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("fileCreationTimeStamp", 4, CreateFileCreationTimeStamp, true, null);
                m_posChildren.Add(0x5F6C, ch);
                m_children.Add("fileCreationTimeStamp", ch);

                ch = new OptionalNamedChild("fileAvailableTimeStamp", 5, CreateFileAvailableTimeStamp, true, null);
                m_posChildren.Add(0x5F6B, ch);
                m_children.Add("fileAvailableTimeStamp", ch);

                ch = new OptionalNamedChild("transferCutOffTimeStamp", 6, CreateTransferCutOffTimeStamp, true, null);
                m_posChildren.Add(0x5F8163, ch);
                m_children.Add("transferCutOffTimeStamp", ch);

                ch = new OptionalNamedChild("specificationVersionNumber", 7, CreateSpecificationVersionNumber, true, null);
                m_posChildren.Add(0x5F8149, ch);
                m_children.Add("specificationVersionNumber", ch);

                ch = new OptionalNamedChild("releaseVersionNumber", 8, CreateReleaseVersionNumber, true, null);
                m_posChildren.Add(0x5F813D, ch);
                m_children.Add("releaseVersionNumber", ch);

                ch = new OptionalNamedChild("fileTypeIndicator", 9, CreateFileTypeIndicator, true, null);
                m_posChildren.Add(0x5F6E, ch);
                m_children.Add("fileTypeIndicator", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 10, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static Sender CreateSender() { return new Sender();}
            public static Recipient CreateRecipient() { return new Recipient();}
            public static FileSequenceNumber CreateFileSequenceNumber() { return new FileSequenceNumber();}
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static FileCreationTimeStamp CreateFileCreationTimeStamp() { return new FileCreationTimeStamp();}
            public static FileAvailableTimeStamp CreateFileAvailableTimeStamp() { return new FileAvailableTimeStamp();}
            public static TransferCutOffTimeStamp CreateTransferCutOffTimeStamp() { return new TransferCutOffTimeStamp();}
            public static SpecificationVersionNumber CreateSpecificationVersionNumber() { return new SpecificationVersionNumber();}
            public static ReleaseVersionNumber CreateReleaseVersionNumber() { return new ReleaseVersionNumber();}
            public static FileTypeIndicator CreateFileTypeIndicator() { return new FileTypeIndicator();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class CallEventDetailList : Asn1SequenceOfObject<CallEventDetail>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x43);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x43);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[7] { 0x49,0x4A,0x4B,0x4C,0x4E,0x51,0x5F8229 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<CallEventDetail> CreateEmptyChild { get { return delegate() { return new CallEventDetail (); }; } }
    }

    public partial class CallEventDetail : Asn1ChoiceObject
    {

        public MobileOriginatedCall mobileOriginatedCall
        {
            get { return m_children[ClassDef.m_children["mobileOriginatedCall"].m_index] as MobileOriginatedCall; }
        }
        public MobileOriginatedCall Create_mobileOriginatedCall()
        {
            return CreateChild("mobileOriginatedCall") as MobileOriginatedCall;
        }

        public MobileTerminatedCall mobileTerminatedCall
        {
            get { return m_children[ClassDef.m_children["mobileTerminatedCall"].m_index] as MobileTerminatedCall; }
        }
        public MobileTerminatedCall Create_mobileTerminatedCall()
        {
            return CreateChild("mobileTerminatedCall") as MobileTerminatedCall;
        }

        public SupplServiceEvent supplServiceEvent
        {
            get { return m_children[ClassDef.m_children["supplServiceEvent"].m_index] as SupplServiceEvent; }
        }
        public SupplServiceEvent Create_supplServiceEvent()
        {
            return CreateChild("supplServiceEvent") as SupplServiceEvent;
        }

        public ServiceCentreUsage serviceCentreUsage
        {
            get { return m_children[ClassDef.m_children["serviceCentreUsage"].m_index] as ServiceCentreUsage; }
        }
        public ServiceCentreUsage Create_serviceCentreUsage()
        {
            return CreateChild("serviceCentreUsage") as ServiceCentreUsage;
        }

        public GprsCall gprsCall
        {
            get { return m_children[ClassDef.m_children["gprsCall"].m_index] as GprsCall; }
        }
        public GprsCall Create_gprsCall()
        {
            return CreateChild("gprsCall") as GprsCall;
        }

        public ContentTransaction contentTransaction
        {
            get { return m_children[ClassDef.m_children["contentTransaction"].m_index] as ContentTransaction; }
        }
        public ContentTransaction Create_contentTransaction()
        {
            return CreateChild("contentTransaction") as ContentTransaction;
        }

        public LocationService locationService
        {
            get { return m_children[ClassDef.m_children["locationService"].m_index] as LocationService; }
        }
        public LocationService Create_locationService()
        {
            return CreateChild("locationService") as LocationService;
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new CallEventDetailClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public CallEventDetail()
        {
            m_children = new Asn1Object[7];
        }
        public class CallEventDetailClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public CallEventDetailClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("mobileOriginatedCall", 0, CreateMobileOriginatedCall);
                m_posChildren.Add(0x49, ch);
                m_children.Add("mobileOriginatedCall", ch);
                ch = new NamedChild("mobileTerminatedCall", 1, CreateMobileTerminatedCall);
                m_posChildren.Add(0x4A, ch);
                m_children.Add("mobileTerminatedCall", ch);
                ch = new NamedChild("supplServiceEvent", 2, CreateSupplServiceEvent);
                m_posChildren.Add(0x4B, ch);
                m_children.Add("supplServiceEvent", ch);
                ch = new NamedChild("serviceCentreUsage", 3, CreateServiceCentreUsage);
                m_posChildren.Add(0x4C, ch);
                m_children.Add("serviceCentreUsage", ch);
                ch = new NamedChild("gprsCall", 4, CreateGprsCall);
                m_posChildren.Add(0x4E, ch);
                m_children.Add("gprsCall", ch);
                ch = new NamedChild("contentTransaction", 5, CreateContentTransaction);
                m_posChildren.Add(0x51, ch);
                m_children.Add("contentTransaction", ch);
                ch = new NamedChild("locationService", 6, CreateLocationService);
                m_posChildren.Add(0x5F8229, ch);
                m_children.Add("locationService", ch);
            }
            public static MobileOriginatedCall CreateMobileOriginatedCall() { return new MobileOriginatedCall();}
            public static MobileTerminatedCall CreateMobileTerminatedCall() { return new MobileTerminatedCall();}
            public static SupplServiceEvent CreateSupplServiceEvent() { return new SupplServiceEvent();}
            public static ServiceCentreUsage CreateServiceCentreUsage() { return new ServiceCentreUsage();}
            public static GprsCall CreateGprsCall() { return new GprsCall();}
            public static ContentTransaction CreateContentTransaction() { return new ContentTransaction();}
            public static LocationService CreateLocationService() { return new LocationService();}
        }
    }

    public partial class BatchControlInfo : Asn1SequenceObject
    {

        public Sender sender
        {
            get { return m_children[ClassDef.m_children["sender"].m_index] as Sender; }
        }
        public Sender Create_sender()
        {
            return CreateChild("sender") as Sender;
        }

        public Recipient recipient
        {
            get { return m_children[ClassDef.m_children["recipient"].m_index] as Recipient; }
        }
        public Recipient Create_recipient()
        {
            return CreateChild("recipient") as Recipient;
        }

        public FileSequenceNumber fileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["fileSequenceNumber"].m_index] as FileSequenceNumber; }
        }
        public FileSequenceNumber Create_fileSequenceNumber()
        {
            return CreateChild("fileSequenceNumber") as FileSequenceNumber;
        }

        public FileCreationTimeStamp fileCreationTimeStamp
        {
            get { return m_children[ClassDef.m_children["fileCreationTimeStamp"].m_index] as FileCreationTimeStamp; }
        }
        public FileCreationTimeStamp Create_fileCreationTimeStamp()
        {
            return CreateChild("fileCreationTimeStamp") as FileCreationTimeStamp;
        }

        public TransferCutOffTimeStamp transferCutOffTimeStamp
        {
            get { return m_children[ClassDef.m_children["transferCutOffTimeStamp"].m_index] as TransferCutOffTimeStamp; }
        }
        public TransferCutOffTimeStamp Create_transferCutOffTimeStamp()
        {
            return CreateChild("transferCutOffTimeStamp") as TransferCutOffTimeStamp;
        }

        public FileAvailableTimeStamp fileAvailableTimeStamp
        {
            get { return m_children[ClassDef.m_children["fileAvailableTimeStamp"].m_index] as FileAvailableTimeStamp; }
        }
        public FileAvailableTimeStamp Create_fileAvailableTimeStamp()
        {
            return CreateChild("fileAvailableTimeStamp") as FileAvailableTimeStamp;
        }

        public SpecificationVersionNumber specificationVersionNumber
        {
            get { return m_children[ClassDef.m_children["specificationVersionNumber"].m_index] as SpecificationVersionNumber; }
        }
        public SpecificationVersionNumber Create_specificationVersionNumber()
        {
            return CreateChild("specificationVersionNumber") as SpecificationVersionNumber;
        }

        public ReleaseVersionNumber releaseVersionNumber
        {
            get { return m_children[ClassDef.m_children["releaseVersionNumber"].m_index] as ReleaseVersionNumber; }
        }
        public ReleaseVersionNumber Create_releaseVersionNumber()
        {
            return CreateChild("releaseVersionNumber") as ReleaseVersionNumber;
        }

        public FileTypeIndicator fileTypeIndicator
        {
            get { return m_children[ClassDef.m_children["fileTypeIndicator"].m_index] as FileTypeIndicator; }
        }
        public FileTypeIndicator Create_fileTypeIndicator()
        {
            return CreateChild("fileTypeIndicator") as FileTypeIndicator;
        }

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x44);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x44);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new BatchControlInfoClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public BatchControlInfo()
        {
            m_children = new Asn1Object[11];
        }
        public class BatchControlInfoClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public BatchControlInfoClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("sender", 0, CreateSender, true, null);
                m_posChildren.Add(0x5F8144, ch);
                m_children.Add("sender", ch);

                ch = new OptionalNamedChild("recipient", 1, CreateRecipient, true, null);
                m_posChildren.Add(0x5F8136, ch);
                m_children.Add("recipient", ch);

                ch = new OptionalNamedChild("fileSequenceNumber", 2, CreateFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F6D, ch);
                m_children.Add("fileSequenceNumber", ch);

                ch = new OptionalNamedChild("fileCreationTimeStamp", 3, CreateFileCreationTimeStamp, true, null);
                m_posChildren.Add(0x5F6C, ch);
                m_children.Add("fileCreationTimeStamp", ch);

                ch = new OptionalNamedChild("transferCutOffTimeStamp", 4, CreateTransferCutOffTimeStamp, true, null);
                m_posChildren.Add(0x5F8163, ch);
                m_children.Add("transferCutOffTimeStamp", ch);

                ch = new OptionalNamedChild("fileAvailableTimeStamp", 5, CreateFileAvailableTimeStamp, true, null);
                m_posChildren.Add(0x5F6B, ch);
                m_children.Add("fileAvailableTimeStamp", ch);

                ch = new OptionalNamedChild("specificationVersionNumber", 6, CreateSpecificationVersionNumber, true, null);
                m_posChildren.Add(0x5F8149, ch);
                m_children.Add("specificationVersionNumber", ch);

                ch = new OptionalNamedChild("releaseVersionNumber", 7, CreateReleaseVersionNumber, true, null);
                m_posChildren.Add(0x5F813D, ch);
                m_children.Add("releaseVersionNumber", ch);

                ch = new OptionalNamedChild("fileTypeIndicator", 8, CreateFileTypeIndicator, true, null);
                m_posChildren.Add(0x5F6E, ch);
                m_children.Add("fileTypeIndicator", ch);

                ch = new OptionalNamedChild("rapFileSequenceNumber", 9, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 10, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static Sender CreateSender() { return new Sender();}
            public static Recipient CreateRecipient() { return new Recipient();}
            public static FileSequenceNumber CreateFileSequenceNumber() { return new FileSequenceNumber();}
            public static FileCreationTimeStamp CreateFileCreationTimeStamp() { return new FileCreationTimeStamp();}
            public static TransferCutOffTimeStamp CreateTransferCutOffTimeStamp() { return new TransferCutOffTimeStamp();}
            public static FileAvailableTimeStamp CreateFileAvailableTimeStamp() { return new FileAvailableTimeStamp();}
            public static SpecificationVersionNumber CreateSpecificationVersionNumber() { return new SpecificationVersionNumber();}
            public static ReleaseVersionNumber CreateReleaseVersionNumber() { return new ReleaseVersionNumber();}
            public static FileTypeIndicator CreateFileTypeIndicator() { return new FileTypeIndicator();}
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class AccountingInfo : Asn1SequenceObject
    {

        public TaxationList taxation
        {
            get { return m_children[ClassDef.m_children["taxation"].m_index] as TaxationList; }
        }
        public TaxationList Create_taxation()
        {
            return CreateChild("taxation") as TaxationList;
        }

        public DiscountingList discounting
        {
            get { return m_children[ClassDef.m_children["discounting"].m_index] as DiscountingList; }
        }
        public DiscountingList Create_discounting()
        {
            return CreateChild("discounting") as DiscountingList;
        }

        public LocalCurrency localCurrency
        {
            get { return m_children[ClassDef.m_children["localCurrency"].m_index] as LocalCurrency; }
        }
        public LocalCurrency Create_localCurrency()
        {
            return CreateChild("localCurrency") as LocalCurrency;
        }

        public TapCurrency tapCurrency
        {
            get { return m_children[ClassDef.m_children["tapCurrency"].m_index] as TapCurrency; }
        }
        public TapCurrency Create_tapCurrency()
        {
            return CreateChild("tapCurrency") as TapCurrency;
        }

        public CurrencyConversionList currencyConversionInfo
        {
            get { return m_children[ClassDef.m_children["currencyConversionInfo"].m_index] as CurrencyConversionList; }
        }
        public CurrencyConversionList Create_currencyConversionInfo()
        {
            return CreateChild("currencyConversionInfo") as CurrencyConversionList;
        }

        public TapDecimalPlaces tapDecimalPlaces
        {
            get { return m_children[ClassDef.m_children["tapDecimalPlaces"].m_index] as TapDecimalPlaces; }
        }
        public TapDecimalPlaces Create_tapDecimalPlaces()
        {
            return CreateChild("tapDecimalPlaces") as TapDecimalPlaces;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x45);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x45);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new AccountingInfoClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public AccountingInfo()
        {
            m_children = new Asn1Object[6];
        }
        public class AccountingInfoClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public AccountingInfoClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("taxation", 0, CreateTaxationList, true, null);
                m_posChildren.Add(0x5F8153, ch);
                m_children.Add("taxation", ch);

                ch = new OptionalNamedChild("discounting", 1, CreateDiscountingList, true, null);
                m_posChildren.Add(0x5F5F, ch);
                m_children.Add("discounting", ch);

                ch = new OptionalNamedChild("localCurrency", 2, CreateLocalCurrency, true, null);
                m_posChildren.Add(0x5F8107, ch);
                m_children.Add("localCurrency", ch);

                ch = new OptionalNamedChild("tapCurrency", 3, CreateTapCurrency, true, null);
                m_posChildren.Add(0x5F8152, ch);
                m_children.Add("tapCurrency", ch);

                ch = new OptionalNamedChild("currencyConversionInfo", 4, CreateCurrencyConversionList, true, null);
                m_posChildren.Add(0x5F50, ch);
                m_children.Add("currencyConversionInfo", ch);

                ch = new OptionalNamedChild("tapDecimalPlaces", 5, CreateTapDecimalPlaces, true, null);
                m_posChildren.Add(0x5F8174, ch);
                m_children.Add("tapDecimalPlaces", ch);

            }
            public static TaxationList CreateTaxationList() { return new TaxationList();}
            public static DiscountingList CreateDiscountingList() { return new DiscountingList();}
            public static LocalCurrency CreateLocalCurrency() { return new LocalCurrency();}
            public static TapCurrency CreateTapCurrency() { return new TapCurrency();}
            public static CurrencyConversionList CreateCurrencyConversionList() { return new CurrencyConversionList();}
            public static TapDecimalPlaces CreateTapDecimalPlaces() { return new TapDecimalPlaces();}
        }
    }

    public partial class NetworkInfo : Asn1SequenceObject
    {

        public UtcTimeOffsetInfoList utcTimeOffsetInfo
        {
            get { return m_children[ClassDef.m_children["utcTimeOffsetInfo"].m_index] as UtcTimeOffsetInfoList; }
        }
        public UtcTimeOffsetInfoList Create_utcTimeOffsetInfo()
        {
            return CreateChild("utcTimeOffsetInfo") as UtcTimeOffsetInfoList;
        }

        public RecEntityInfoList recEntityInfo
        {
            get { return m_children[ClassDef.m_children["recEntityInfo"].m_index] as RecEntityInfoList; }
        }
        public RecEntityInfoList Create_recEntityInfo()
        {
            return CreateChild("recEntityInfo") as RecEntityInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x46);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x46);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new NetworkInfoClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public NetworkInfo()
        {
            m_children = new Asn1Object[2];
        }
        public class NetworkInfoClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public NetworkInfoClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("utcTimeOffsetInfo", 0, CreateUtcTimeOffsetInfoList, true, null);
                m_posChildren.Add(0x5F816A, ch);
                m_children.Add("utcTimeOffsetInfo", ch);

                ch = new OptionalNamedChild("recEntityInfo", 1, CreateRecEntityInfoList, true, null);
                m_posChildren.Add(0x5F813C, ch);
                m_children.Add("recEntityInfo", ch);

            }
            public static UtcTimeOffsetInfoList CreateUtcTimeOffsetInfoList() { return new UtcTimeOffsetInfoList();}
            public static RecEntityInfoList CreateRecEntityInfoList() { return new RecEntityInfoList();}
        }
    }

    public partial class MessageDescriptionInfoList : Asn1SequenceOfObject<MessageDescriptionInformation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x48);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x48);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F810F } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<MessageDescriptionInformation> CreateEmptyChild { get { return delegate() { return new MessageDescriptionInformation (); }; } }
    }

    public partial class MobileOriginatedCall : Asn1SequenceObject
    {

        public MoBasicCallInformation basicCallInformation
        {
            get { return m_children[ClassDef.m_children["basicCallInformation"].m_index] as MoBasicCallInformation; }
        }
        public MoBasicCallInformation Create_basicCallInformation()
        {
            return CreateChild("basicCallInformation") as MoBasicCallInformation;
        }

        public LocationInformation locationInformation
        {
            get { return m_children[ClassDef.m_children["locationInformation"].m_index] as LocationInformation; }
        }
        public LocationInformation Create_locationInformation()
        {
            return CreateChild("locationInformation") as LocationInformation;
        }

        public ImeiOrEsn equipmentIdentifier
        {
            get { return m_children[ClassDef.m_children["equipmentIdentifier"].m_index] as ImeiOrEsn; }
        }
        public ImeiOrEsn Create_equipmentIdentifier()
        {
            return CreateChild("equipmentIdentifier") as ImeiOrEsn;
        }

        public BasicServiceUsedList basicServiceUsedList
        {
            get { return m_children[ClassDef.m_children["basicServiceUsedList"].m_index] as BasicServiceUsedList; }
        }
        public BasicServiceUsedList Create_basicServiceUsedList()
        {
            return CreateChild("basicServiceUsedList") as BasicServiceUsedList;
        }

        public SupplServiceCode supplServiceCode
        {
            get { return m_children[ClassDef.m_children["supplServiceCode"].m_index] as SupplServiceCode; }
        }
        public SupplServiceCode Create_supplServiceCode()
        {
            return CreateChild("supplServiceCode") as SupplServiceCode;
        }

        public ThirdPartyInformation thirdPartyInformation
        {
            get { return m_children[ClassDef.m_children["thirdPartyInformation"].m_index] as ThirdPartyInformation; }
        }
        public ThirdPartyInformation Create_thirdPartyInformation()
        {
            return CreateChild("thirdPartyInformation") as ThirdPartyInformation;
        }

        public CamelServiceUsed camelServiceUsed
        {
            get { return m_children[ClassDef.m_children["camelServiceUsed"].m_index] as CamelServiceUsed; }
        }
        public CamelServiceUsed Create_camelServiceUsed()
        {
            return CreateChild("camelServiceUsed") as CamelServiceUsed;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x49);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x49);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new MobileOriginatedCallClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public MobileOriginatedCall()
        {
            m_children = new Asn1Object[8];
        }
        public class MobileOriginatedCallClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public MobileOriginatedCallClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("basicCallInformation", 0, CreateMoBasicCallInformation, true, null);
                m_posChildren.Add(0x5F8113, ch);
                m_children.Add("basicCallInformation", ch);

                ch = new OptionalNamedChild("locationInformation", 1, CreateLocationInformation, true, null);
                m_posChildren.Add(0x5F810A, ch);
                m_children.Add("locationInformation", ch);

                ch = new OptionalNamedChild("equipmentIdentifier", 2, CreateImeiOrEsn, true, null);
                m_posChildren.Add(0x5F832D, ch);
                m_children.Add("equipmentIdentifier", ch);

                ch = new OptionalNamedChild("basicServiceUsedList", 3, CreateBasicServiceUsedList, true, null);
                m_posChildren.Add(0x5F26, ch);
                m_children.Add("basicServiceUsedList", ch);

                ch = new OptionalNamedChild("supplServiceCode", 4, CreateSupplServiceCode, true, null);
                m_posChildren.Add(0x5F8151, ch);
                m_children.Add("supplServiceCode", ch);

                ch = new OptionalNamedChild("thirdPartyInformation", 5, CreateThirdPartyInformation, true, null);
                m_posChildren.Add(0x5F815B, ch);
                m_children.Add("thirdPartyInformation", ch);

                ch = new OptionalNamedChild("camelServiceUsed", 6, CreateCamelServiceUsed, true, null);
                m_posChildren.Add(0x5F39, ch);
                m_children.Add("camelServiceUsed", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 7, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static MoBasicCallInformation CreateMoBasicCallInformation() { return new MoBasicCallInformation();}
            public static LocationInformation CreateLocationInformation() { return new LocationInformation();}
            public static ImeiOrEsn CreateImeiOrEsn() { return new ImeiOrEsn();}
            public static BasicServiceUsedList CreateBasicServiceUsedList() { return new BasicServiceUsedList();}
            public static SupplServiceCode CreateSupplServiceCode() { return new SupplServiceCode();}
            public static ThirdPartyInformation CreateThirdPartyInformation() { return new ThirdPartyInformation();}
            public static CamelServiceUsed CreateCamelServiceUsed() { return new CamelServiceUsed();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class MobileTerminatedCall : Asn1SequenceObject
    {

        public MtBasicCallInformation basicCallInformation
        {
            get { return m_children[ClassDef.m_children["basicCallInformation"].m_index] as MtBasicCallInformation; }
        }
        public MtBasicCallInformation Create_basicCallInformation()
        {
            return CreateChild("basicCallInformation") as MtBasicCallInformation;
        }

        public LocationInformation locationInformation
        {
            get { return m_children[ClassDef.m_children["locationInformation"].m_index] as LocationInformation; }
        }
        public LocationInformation Create_locationInformation()
        {
            return CreateChild("locationInformation") as LocationInformation;
        }

        public ImeiOrEsn equipmentIdentifier
        {
            get { return m_children[ClassDef.m_children["equipmentIdentifier"].m_index] as ImeiOrEsn; }
        }
        public ImeiOrEsn Create_equipmentIdentifier()
        {
            return CreateChild("equipmentIdentifier") as ImeiOrEsn;
        }

        public BasicServiceUsedList basicServiceUsedList
        {
            get { return m_children[ClassDef.m_children["basicServiceUsedList"].m_index] as BasicServiceUsedList; }
        }
        public BasicServiceUsedList Create_basicServiceUsedList()
        {
            return CreateChild("basicServiceUsedList") as BasicServiceUsedList;
        }

        public CamelServiceUsed camelServiceUsed
        {
            get { return m_children[ClassDef.m_children["camelServiceUsed"].m_index] as CamelServiceUsed; }
        }
        public CamelServiceUsed Create_camelServiceUsed()
        {
            return CreateChild("camelServiceUsed") as CamelServiceUsed;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x4A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x4A);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new MobileTerminatedCallClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public MobileTerminatedCall()
        {
            m_children = new Asn1Object[6];
        }
        public class MobileTerminatedCallClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public MobileTerminatedCallClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("basicCallInformation", 0, CreateMtBasicCallInformation, true, null);
                m_posChildren.Add(0x5F8119, ch);
                m_children.Add("basicCallInformation", ch);

                ch = new OptionalNamedChild("locationInformation", 1, CreateLocationInformation, true, null);
                m_posChildren.Add(0x5F810A, ch);
                m_children.Add("locationInformation", ch);

                ch = new OptionalNamedChild("equipmentIdentifier", 2, CreateImeiOrEsn, true, null);
                m_posChildren.Add(0x5F832D, ch);
                m_children.Add("equipmentIdentifier", ch);

                ch = new OptionalNamedChild("basicServiceUsedList", 3, CreateBasicServiceUsedList, true, null);
                m_posChildren.Add(0x5F26, ch);
                m_children.Add("basicServiceUsedList", ch);

                ch = new OptionalNamedChild("camelServiceUsed", 4, CreateCamelServiceUsed, true, null);
                m_posChildren.Add(0x5F39, ch);
                m_children.Add("camelServiceUsed", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 5, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static MtBasicCallInformation CreateMtBasicCallInformation() { return new MtBasicCallInformation();}
            public static LocationInformation CreateLocationInformation() { return new LocationInformation();}
            public static ImeiOrEsn CreateImeiOrEsn() { return new ImeiOrEsn();}
            public static BasicServiceUsedList CreateBasicServiceUsedList() { return new BasicServiceUsedList();}
            public static CamelServiceUsed CreateCamelServiceUsed() { return new CamelServiceUsed();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class SupplServiceEvent : Asn1SequenceObject
    {

        public ChargeableSubscriber chargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["chargeableSubscriber"].m_index] as ChargeableSubscriber; }
        }
        public ChargeableSubscriber Create_chargeableSubscriber()
        {
            return CreateChild("chargeableSubscriber") as ChargeableSubscriber;
        }

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public LocationInformation locationInformation
        {
            get { return m_children[ClassDef.m_children["locationInformation"].m_index] as LocationInformation; }
        }
        public LocationInformation Create_locationInformation()
        {
            return CreateChild("locationInformation") as LocationInformation;
        }

        public ImeiOrEsn equipmentIdentifier
        {
            get { return m_children[ClassDef.m_children["equipmentIdentifier"].m_index] as ImeiOrEsn; }
        }
        public ImeiOrEsn Create_equipmentIdentifier()
        {
            return CreateChild("equipmentIdentifier") as ImeiOrEsn;
        }

        public SupplServiceUsed supplServiceUsed
        {
            get { return m_children[ClassDef.m_children["supplServiceUsed"].m_index] as SupplServiceUsed; }
        }
        public SupplServiceUsed Create_supplServiceUsed()
        {
            return CreateChild("supplServiceUsed") as SupplServiceUsed;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x4B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x4B);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new SupplServiceEventClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public SupplServiceEvent()
        {
            m_children = new Asn1Object[6];
        }
        public class SupplServiceEventClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public SupplServiceEventClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargeableSubscriber", 0, CreateChargeableSubscriber, true, null);
                m_posChildren.Add(0x5F832B, ch);
                m_children.Add("chargeableSubscriber", ch);

                ch = new OptionalNamedChild("rapFileSequenceNumber", 1, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("locationInformation", 2, CreateLocationInformation, true, null);
                m_posChildren.Add(0x5F810A, ch);
                m_children.Add("locationInformation", ch);

                ch = new OptionalNamedChild("equipmentIdentifier", 3, CreateImeiOrEsn, true, null);
                m_posChildren.Add(0x5F832D, ch);
                m_children.Add("equipmentIdentifier", ch);

                ch = new OptionalNamedChild("supplServiceUsed", 4, CreateSupplServiceUsed, true, null);
                m_posChildren.Add(0x5F814E, ch);
                m_children.Add("supplServiceUsed", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 5, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static ChargeableSubscriber CreateChargeableSubscriber() { return new ChargeableSubscriber();}
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static LocationInformation CreateLocationInformation() { return new LocationInformation();}
            public static ImeiOrEsn CreateImeiOrEsn() { return new ImeiOrEsn();}
            public static SupplServiceUsed CreateSupplServiceUsed() { return new SupplServiceUsed();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class ServiceCentreUsage : Asn1SequenceObject
    {

        public ScuBasicInformation basicInformation
        {
            get { return m_children[ClassDef.m_children["basicInformation"].m_index] as ScuBasicInformation; }
        }
        public ScuBasicInformation Create_basicInformation()
        {
            return CreateChild("basicInformation") as ScuBasicInformation;
        }

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public ServingNetwork servingNetwork
        {
            get { return m_children[ClassDef.m_children["servingNetwork"].m_index] as ServingNetwork; }
        }
        public ServingNetwork Create_servingNetwork()
        {
            return CreateChild("servingNetwork") as ServingNetwork;
        }

        public RecEntityCode recEntityCode
        {
            get { return m_children[ClassDef.m_children["recEntityCode"].m_index] as RecEntityCode; }
        }
        public RecEntityCode Create_recEntityCode()
        {
            return CreateChild("recEntityCode") as RecEntityCode;
        }

        public ChargeInformation chargeInformation
        {
            get { return m_children[ClassDef.m_children["chargeInformation"].m_index] as ChargeInformation; }
        }
        public ChargeInformation Create_chargeInformation()
        {
            return CreateChild("chargeInformation") as ChargeInformation;
        }

        public ScuChargeType scuChargeType
        {
            get { return m_children[ClassDef.m_children["scuChargeType"].m_index] as ScuChargeType; }
        }
        public ScuChargeType Create_scuChargeType()
        {
            return CreateChild("scuChargeType") as ScuChargeType;
        }

        public ScuTimeStamps scuTimeStamps
        {
            get { return m_children[ClassDef.m_children["scuTimeStamps"].m_index] as ScuTimeStamps; }
        }
        public ScuTimeStamps Create_scuTimeStamps()
        {
            return CreateChild("scuTimeStamps") as ScuTimeStamps;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x4C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x4C);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ServiceCentreUsageClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ServiceCentreUsage()
        {
            m_children = new Asn1Object[8];
        }
        public class ServiceCentreUsageClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ServiceCentreUsageClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("basicInformation", 0, CreateScuBasicInformation, true, null);
                m_posChildren.Add(0x5F813F, ch);
                m_children.Add("basicInformation", ch);

                ch = new OptionalNamedChild("rapFileSequenceNumber", 1, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("servingNetwork", 2, CreateServingNetwork, true, null);
                m_posChildren.Add(0x5F8143, ch);
                m_children.Add("servingNetwork", ch);

                ch = new OptionalNamedChild("recEntityCode", 3, CreateRecEntityCode, true, null);
                m_posChildren.Add(0x5F8138, ch);
                m_children.Add("recEntityCode", ch);

                ch = new OptionalNamedChild("chargeInformation", 4, CreateChargeInformation, true, null);
                m_posChildren.Add(0x5F45, ch);
                m_children.Add("chargeInformation", ch);

                ch = new OptionalNamedChild("scuChargeType", 5, CreateScuChargeType, true, null);
                m_posChildren.Add(0x5F8140, ch);
                m_children.Add("scuChargeType", ch);

                ch = new OptionalNamedChild("scuTimeStamps", 6, CreateScuTimeStamps, true, null);
                m_posChildren.Add(0x5F8141, ch);
                m_children.Add("scuTimeStamps", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 7, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static ScuBasicInformation CreateScuBasicInformation() { return new ScuBasicInformation();}
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static ServingNetwork CreateServingNetwork() { return new ServingNetwork();}
            public static RecEntityCode CreateRecEntityCode() { return new RecEntityCode();}
            public static ChargeInformation CreateChargeInformation() { return new ChargeInformation();}
            public static ScuChargeType CreateScuChargeType() { return new ScuChargeType();}
            public static ScuTimeStamps CreateScuTimeStamps() { return new ScuTimeStamps();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class GprsCall : Asn1SequenceObject
    {

        public GprsBasicCallInformation gprsBasicCallInformation
        {
            get { return m_children[ClassDef.m_children["gprsBasicCallInformation"].m_index] as GprsBasicCallInformation; }
        }
        public GprsBasicCallInformation Create_gprsBasicCallInformation()
        {
            return CreateChild("gprsBasicCallInformation") as GprsBasicCallInformation;
        }

        public GprsLocationInformation gprsLocationInformation
        {
            get { return m_children[ClassDef.m_children["gprsLocationInformation"].m_index] as GprsLocationInformation; }
        }
        public GprsLocationInformation Create_gprsLocationInformation()
        {
            return CreateChild("gprsLocationInformation") as GprsLocationInformation;
        }

        public ImeiOrEsn equipmentIdentifier
        {
            get { return m_children[ClassDef.m_children["equipmentIdentifier"].m_index] as ImeiOrEsn; }
        }
        public ImeiOrEsn Create_equipmentIdentifier()
        {
            return CreateChild("equipmentIdentifier") as ImeiOrEsn;
        }

        public GprsServiceUsed gprsServiceUsed
        {
            get { return m_children[ClassDef.m_children["gprsServiceUsed"].m_index] as GprsServiceUsed; }
        }
        public GprsServiceUsed Create_gprsServiceUsed()
        {
            return CreateChild("gprsServiceUsed") as GprsServiceUsed;
        }

        public CamelServiceUsed camelServiceUsed
        {
            get { return m_children[ClassDef.m_children["camelServiceUsed"].m_index] as CamelServiceUsed; }
        }
        public CamelServiceUsed Create_camelServiceUsed()
        {
            return CreateChild("camelServiceUsed") as CamelServiceUsed;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x4E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x4E);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GprsCallClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GprsCall()
        {
            m_children = new Asn1Object[6];
        }
        public class GprsCallClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GprsCallClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("gprsBasicCallInformation", 0, CreateGprsBasicCallInformation, true, null);
                m_posChildren.Add(0x5F72, ch);
                m_children.Add("gprsBasicCallInformation", ch);

                ch = new OptionalNamedChild("gprsLocationInformation", 1, CreateGprsLocationInformation, true, null);
                m_posChildren.Add(0x5F75, ch);
                m_children.Add("gprsLocationInformation", ch);

                ch = new OptionalNamedChild("equipmentIdentifier", 2, CreateImeiOrEsn, true, null);
                m_posChildren.Add(0x5F832D, ch);
                m_children.Add("equipmentIdentifier", ch);

                ch = new OptionalNamedChild("gprsServiceUsed", 3, CreateGprsServiceUsed, true, null);
                m_posChildren.Add(0x5F79, ch);
                m_children.Add("gprsServiceUsed", ch);

                ch = new OptionalNamedChild("camelServiceUsed", 4, CreateCamelServiceUsed, true, null);
                m_posChildren.Add(0x5F39, ch);
                m_children.Add("camelServiceUsed", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 5, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static GprsBasicCallInformation CreateGprsBasicCallInformation() { return new GprsBasicCallInformation();}
            public static GprsLocationInformation CreateGprsLocationInformation() { return new GprsLocationInformation();}
            public static ImeiOrEsn CreateImeiOrEsn() { return new ImeiOrEsn();}
            public static GprsServiceUsed CreateGprsServiceUsed() { return new GprsServiceUsed();}
            public static CamelServiceUsed CreateCamelServiceUsed() { return new CamelServiceUsed();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class ContentTransaction : Asn1SequenceObject
    {

        public ContentTransactionBasicInfo contentTransactionBasicInfo
        {
            get { return m_children[ClassDef.m_children["contentTransactionBasicInfo"].m_index] as ContentTransactionBasicInfo; }
        }
        public ContentTransactionBasicInfo Create_contentTransactionBasicInfo()
        {
            return CreateChild("contentTransactionBasicInfo") as ContentTransactionBasicInfo;
        }

        public ChargedPartyInformation chargedPartyInformation
        {
            get { return m_children[ClassDef.m_children["chargedPartyInformation"].m_index] as ChargedPartyInformation; }
        }
        public ChargedPartyInformation Create_chargedPartyInformation()
        {
            return CreateChild("chargedPartyInformation") as ChargedPartyInformation;
        }

        public ServingPartiesInformation servingPartiesInformation
        {
            get { return m_children[ClassDef.m_children["servingPartiesInformation"].m_index] as ServingPartiesInformation; }
        }
        public ServingPartiesInformation Create_servingPartiesInformation()
        {
            return CreateChild("servingPartiesInformation") as ServingPartiesInformation;
        }

        public ContentServiceUsedList contentServiceUsed
        {
            get { return m_children[ClassDef.m_children["contentServiceUsed"].m_index] as ContentServiceUsedList; }
        }
        public ContentServiceUsedList Create_contentServiceUsed()
        {
            return CreateChild("contentServiceUsed") as ContentServiceUsedList;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x51);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x51);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ContentTransactionClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ContentTransaction()
        {
            m_children = new Asn1Object[5];
        }
        public class ContentTransactionClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ContentTransactionClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("contentTransactionBasicInfo", 0, CreateContentTransactionBasicInfo, true, null);
                m_posChildren.Add(0x5F8230, ch);
                m_children.Add("contentTransactionBasicInfo", ch);

                ch = new OptionalNamedChild("chargedPartyInformation", 1, CreateChargedPartyInformation, true, null);
                m_posChildren.Add(0x5F8244, ch);
                m_children.Add("chargedPartyInformation", ch);

                ch = new OptionalNamedChild("servingPartiesInformation", 2, CreateServingPartiesInformation, true, null);
                m_posChildren.Add(0x5F824F, ch);
                m_children.Add("servingPartiesInformation", ch);

                ch = new OptionalNamedChild("contentServiceUsed", 3, CreateContentServiceUsedList, true, null);
                m_posChildren.Add(0x5F821D, ch);
                m_children.Add("contentServiceUsed", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 4, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static ContentTransactionBasicInfo CreateContentTransactionBasicInfo() { return new ContentTransactionBasicInfo();}
            public static ChargedPartyInformation CreateChargedPartyInformation() { return new ChargedPartyInformation();}
            public static ServingPartiesInformation CreateServingPartiesInformation() { return new ServingPartiesInformation();}
            public static ContentServiceUsedList CreateContentServiceUsedList() { return new ContentServiceUsedList();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class LocationService : Asn1SequenceObject
    {

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public RecEntityCode recEntityCode
        {
            get { return m_children[ClassDef.m_children["recEntityCode"].m_index] as RecEntityCode; }
        }
        public RecEntityCode Create_recEntityCode()
        {
            return CreateChild("recEntityCode") as RecEntityCode;
        }

        public CallReference callReference
        {
            get { return m_children[ClassDef.m_children["callReference"].m_index] as CallReference; }
        }
        public CallReference Create_callReference()
        {
            return CreateChild("callReference") as CallReference;
        }

        public TrackingCustomerInformation trackingCustomerInformation
        {
            get { return m_children[ClassDef.m_children["trackingCustomerInformation"].m_index] as TrackingCustomerInformation; }
        }
        public TrackingCustomerInformation Create_trackingCustomerInformation()
        {
            return CreateChild("trackingCustomerInformation") as TrackingCustomerInformation;
        }

        public LCSSPInformation lCSSPInformation
        {
            get { return m_children[ClassDef.m_children["lCSSPInformation"].m_index] as LCSSPInformation; }
        }
        public LCSSPInformation Create_lCSSPInformation()
        {
            return CreateChild("lCSSPInformation") as LCSSPInformation;
        }

        public TrackedCustomerInformation trackedCustomerInformation
        {
            get { return m_children[ClassDef.m_children["trackedCustomerInformation"].m_index] as TrackedCustomerInformation; }
        }
        public TrackedCustomerInformation Create_trackedCustomerInformation()
        {
            return CreateChild("trackedCustomerInformation") as TrackedCustomerInformation;
        }

        public LocationServiceUsage locationServiceUsage
        {
            get { return m_children[ClassDef.m_children["locationServiceUsage"].m_index] as LocationServiceUsage; }
        }
        public LocationServiceUsage Create_locationServiceUsage()
        {
            return CreateChild("locationServiceUsage") as LocationServiceUsage;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8229);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8229);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new LocationServiceClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public LocationService()
        {
            m_children = new Asn1Object[8];
        }
        public class LocationServiceClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public LocationServiceClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("rapFileSequenceNumber", 0, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("recEntityCode", 1, CreateRecEntityCode, true, null);
                m_posChildren.Add(0x5F8138, ch);
                m_children.Add("recEntityCode", ch);

                ch = new OptionalNamedChild("callReference", 2, CreateCallReference, true, null);
                m_posChildren.Add(0x5F2D, ch);
                m_children.Add("callReference", ch);

                ch = new OptionalNamedChild("trackingCustomerInformation", 3, CreateTrackingCustomerInformation, true, null);
                m_posChildren.Add(0x5F822A, ch);
                m_children.Add("trackingCustomerInformation", ch);

                ch = new OptionalNamedChild("lCSSPInformation", 4, CreateLCSSPInformation, true, null);
                m_posChildren.Add(0x5F8275, ch);
                m_children.Add("lCSSPInformation", ch);

                ch = new OptionalNamedChild("trackedCustomerInformation", 5, CreateTrackedCustomerInformation, true, null);
                m_posChildren.Add(0x5F826F, ch);
                m_children.Add("trackedCustomerInformation", ch);

                ch = new OptionalNamedChild("locationServiceUsage", 6, CreateLocationServiceUsage, true, null);
                m_posChildren.Add(0x5F827E, ch);
                m_children.Add("locationServiceUsage", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 7, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static RecEntityCode CreateRecEntityCode() { return new RecEntityCode();}
            public static CallReference CreateCallReference() { return new CallReference();}
            public static TrackingCustomerInformation CreateTrackingCustomerInformation() { return new TrackingCustomerInformation();}
            public static LCSSPInformation CreateLCSSPInformation() { return new LCSSPInformation();}
            public static TrackedCustomerInformation CreateTrackedCustomerInformation() { return new TrackedCustomerInformation();}
            public static LocationServiceUsage CreateLocationServiceUsage() { return new LocationServiceUsage();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class AuditControlInfo : Asn1SequenceObject
    {

        public EarliestCallTimeStamp earliestCallTimeStamp
        {
            get { return m_children[ClassDef.m_children["earliestCallTimeStamp"].m_index] as EarliestCallTimeStamp; }
        }
        public EarliestCallTimeStamp Create_earliestCallTimeStamp()
        {
            return CreateChild("earliestCallTimeStamp") as EarliestCallTimeStamp;
        }

        public LatestCallTimeStamp latestCallTimeStamp
        {
            get { return m_children[ClassDef.m_children["latestCallTimeStamp"].m_index] as LatestCallTimeStamp; }
        }
        public LatestCallTimeStamp Create_latestCallTimeStamp()
        {
            return CreateChild("latestCallTimeStamp") as LatestCallTimeStamp;
        }

        public TotalCharge totalCharge
        {
            get { return m_children[ClassDef.m_children["totalCharge"].m_index] as TotalCharge; }
        }
        public TotalCharge Create_totalCharge()
        {
            return CreateChild("totalCharge") as TotalCharge;
        }

        public TotalChargeRefund totalChargeRefund
        {
            get { return m_children[ClassDef.m_children["totalChargeRefund"].m_index] as TotalChargeRefund; }
        }
        public TotalChargeRefund Create_totalChargeRefund()
        {
            return CreateChild("totalChargeRefund") as TotalChargeRefund;
        }

        public TotalTaxRefund totalTaxRefund
        {
            get { return m_children[ClassDef.m_children["totalTaxRefund"].m_index] as TotalTaxRefund; }
        }
        public TotalTaxRefund Create_totalTaxRefund()
        {
            return CreateChild("totalTaxRefund") as TotalTaxRefund;
        }

        public TotalTaxValue totalTaxValue
        {
            get { return m_children[ClassDef.m_children["totalTaxValue"].m_index] as TotalTaxValue; }
        }
        public TotalTaxValue Create_totalTaxValue()
        {
            return CreateChild("totalTaxValue") as TotalTaxValue;
        }

        public TotalDiscountValue totalDiscountValue
        {
            get { return m_children[ClassDef.m_children["totalDiscountValue"].m_index] as TotalDiscountValue; }
        }
        public TotalDiscountValue Create_totalDiscountValue()
        {
            return CreateChild("totalDiscountValue") as TotalDiscountValue;
        }

        public TotalDiscountRefund totalDiscountRefund
        {
            get { return m_children[ClassDef.m_children["totalDiscountRefund"].m_index] as TotalDiscountRefund; }
        }
        public TotalDiscountRefund Create_totalDiscountRefund()
        {
            return CreateChild("totalDiscountRefund") as TotalDiscountRefund;
        }

        public TotalAdvisedChargeValueList totalAdvisedChargeValueList
        {
            get { return m_children[ClassDef.m_children["totalAdvisedChargeValueList"].m_index] as TotalAdvisedChargeValueList; }
        }
        public TotalAdvisedChargeValueList Create_totalAdvisedChargeValueList()
        {
            return CreateChild("totalAdvisedChargeValueList") as TotalAdvisedChargeValueList;
        }

        public CallEventDetailsCount callEventDetailsCount
        {
            get { return m_children[ClassDef.m_children["callEventDetailsCount"].m_index] as CallEventDetailsCount; }
        }
        public CallEventDetailsCount Create_callEventDetailsCount()
        {
            return CreateChild("callEventDetailsCount") as CallEventDetailsCount;
        }

        public OperatorSpecInfoList operatorSpecInformation
        {
            get { return m_children[ClassDef.m_children["operatorSpecInformation"].m_index] as OperatorSpecInfoList; }
        }
        public OperatorSpecInfoList Create_operatorSpecInformation()
        {
            return CreateChild("operatorSpecInformation") as OperatorSpecInfoList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x4F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x4F);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new AuditControlInfoClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public AuditControlInfo()
        {
            m_children = new Asn1Object[11];
        }
        public class AuditControlInfoClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public AuditControlInfoClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("earliestCallTimeStamp", 0, CreateEarliestCallTimeStamp, true, null);
                m_posChildren.Add(0x5F65, ch);
                m_children.Add("earliestCallTimeStamp", ch);

                ch = new OptionalNamedChild("latestCallTimeStamp", 1, CreateLatestCallTimeStamp, true, null);
                m_posChildren.Add(0x5F8105, ch);
                m_children.Add("latestCallTimeStamp", ch);

                ch = new OptionalNamedChild("totalCharge", 2, CreateTotalCharge, true, null);
                m_posChildren.Add(0x5F831F, ch);
                m_children.Add("totalCharge", ch);

                ch = new OptionalNamedChild("totalChargeRefund", 3, CreateTotalChargeRefund, true, null);
                m_posChildren.Add(0x5F8263, ch);
                m_children.Add("totalChargeRefund", ch);

                ch = new OptionalNamedChild("totalTaxRefund", 4, CreateTotalTaxRefund, true, null);
                m_posChildren.Add(0x5F8261, ch);
                m_children.Add("totalTaxRefund", ch);

                ch = new OptionalNamedChild("totalTaxValue", 5, CreateTotalTaxValue, true, null);
                m_posChildren.Add(0x5F8162, ch);
                m_children.Add("totalTaxValue", ch);

                ch = new OptionalNamedChild("totalDiscountValue", 6, CreateTotalDiscountValue, true, null);
                m_posChildren.Add(0x5F8161, ch);
                m_children.Add("totalDiscountValue", ch);

                ch = new OptionalNamedChild("totalDiscountRefund", 7, CreateTotalDiscountRefund, true, null);
                m_posChildren.Add(0x5F8262, ch);
                m_children.Add("totalDiscountRefund", ch);

                ch = new OptionalNamedChild("totalAdvisedChargeValueList", 8, CreateTotalAdvisedChargeValueList, true, null);
                m_posChildren.Add(0x5F8269, ch);
                m_children.Add("totalAdvisedChargeValueList", ch);

                ch = new OptionalNamedChild("callEventDetailsCount", 9, CreateCallEventDetailsCount, true, null);
                m_posChildren.Add(0x5F2B, ch);
                m_children.Add("callEventDetailsCount", ch);

                ch = new OptionalNamedChild("operatorSpecInformation", 10, CreateOperatorSpecInfoList, true, null);
                m_posChildren.Add(0x5F8122, ch);
                m_children.Add("operatorSpecInformation", ch);

            }
            public static EarliestCallTimeStamp CreateEarliestCallTimeStamp() { return new EarliestCallTimeStamp();}
            public static LatestCallTimeStamp CreateLatestCallTimeStamp() { return new LatestCallTimeStamp();}
            public static TotalCharge CreateTotalCharge() { return new TotalCharge();}
            public static TotalChargeRefund CreateTotalChargeRefund() { return new TotalChargeRefund();}
            public static TotalTaxRefund CreateTotalTaxRefund() { return new TotalTaxRefund();}
            public static TotalTaxValue CreateTotalTaxValue() { return new TotalTaxValue();}
            public static TotalDiscountValue CreateTotalDiscountValue() { return new TotalDiscountValue();}
            public static TotalDiscountRefund CreateTotalDiscountRefund() { return new TotalDiscountRefund();}
            public static TotalAdvisedChargeValueList CreateTotalAdvisedChargeValueList() { return new TotalAdvisedChargeValueList();}
            public static CallEventDetailsCount CreateCallEventDetailsCount() { return new CallEventDetailsCount();}
            public static OperatorSpecInfoList CreateOperatorSpecInfoList() { return new OperatorSpecInfoList();}
        }
    }

    public partial class AccessPointNameNI : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8205);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8205);
        }
    }

    public partial class AccessPointNameOI : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8206);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8206);
        }
    }

    public partial class ActualDeliveryTimeStamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F822E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F822E);
        }
    }

    public partial class AddressStringDigits : BCDString
    {
    }

    public partial class AdvisedCharge : Charge
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F825D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F825D);
        }
    }

    public partial class AdvisedChargeCurrency : Currency
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F825C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F825C);
        }
    }

    public partial class AdvisedChargeInformation : Asn1SequenceObject
    {

        public PaidIndicator paidIndicator
        {
            get { return m_children[ClassDef.m_children["paidIndicator"].m_index] as PaidIndicator; }
        }
        public PaidIndicator Create_paidIndicator()
        {
            return CreateChild("paidIndicator") as PaidIndicator;
        }

        public PaymentMethod paymentMethod
        {
            get { return m_children[ClassDef.m_children["paymentMethod"].m_index] as PaymentMethod; }
        }
        public PaymentMethod Create_paymentMethod()
        {
            return CreateChild("paymentMethod") as PaymentMethod;
        }

        public AdvisedChargeCurrency advisedChargeCurrency
        {
            get { return m_children[ClassDef.m_children["advisedChargeCurrency"].m_index] as AdvisedChargeCurrency; }
        }
        public AdvisedChargeCurrency Create_advisedChargeCurrency()
        {
            return CreateChild("advisedChargeCurrency") as AdvisedChargeCurrency;
        }

        public AdvisedCharge advisedCharge
        {
            get { return m_children[ClassDef.m_children["advisedCharge"].m_index] as AdvisedCharge; }
        }
        public AdvisedCharge Create_advisedCharge()
        {
            return CreateChild("advisedCharge") as AdvisedCharge;
        }

        public Commission commission
        {
            get { return m_children[ClassDef.m_children["commission"].m_index] as Commission; }
        }
        public Commission Create_commission()
        {
            return CreateChild("commission") as Commission;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F825F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F825F);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new AdvisedChargeInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public AdvisedChargeInformation()
        {
            m_children = new Asn1Object[5];
        }
        public class AdvisedChargeInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public AdvisedChargeInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("paidIndicator", 0, CreatePaidIndicator, true, null);
                m_posChildren.Add(0x5F825A, ch);
                m_children.Add("paidIndicator", ch);

                ch = new OptionalNamedChild("paymentMethod", 1, CreatePaymentMethod, true, null);
                m_posChildren.Add(0x5F825B, ch);
                m_children.Add("paymentMethod", ch);

                ch = new OptionalNamedChild("advisedChargeCurrency", 2, CreateAdvisedChargeCurrency, true, null);
                m_posChildren.Add(0x5F825C, ch);
                m_children.Add("advisedChargeCurrency", ch);

                ch = new OptionalNamedChild("advisedCharge", 3, CreateAdvisedCharge, true, null);
                m_posChildren.Add(0x5F825D, ch);
                m_children.Add("advisedCharge", ch);

                ch = new OptionalNamedChild("commission", 4, CreateCommission, true, null);
                m_posChildren.Add(0x5F825E, ch);
                m_children.Add("commission", ch);

            }
            public static PaidIndicator CreatePaidIndicator() { return new PaidIndicator();}
            public static PaymentMethod CreatePaymentMethod() { return new PaymentMethod();}
            public static AdvisedChargeCurrency CreateAdvisedChargeCurrency() { return new AdvisedChargeCurrency();}
            public static AdvisedCharge CreateAdvisedCharge() { return new AdvisedCharge();}
            public static Commission CreateCommission() { return new Commission();}
        }
    }

    public partial class AgeOfLocation : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F830C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F830C);
        }
    }

    public partial class BasicService : Asn1SequenceObject
    {

        public BasicServiceCode serviceCode
        {
            get { return m_children[ClassDef.m_children["serviceCode"].m_index] as BasicServiceCode; }
        }
        public BasicServiceCode Create_serviceCode()
        {
            return CreateChild("serviceCode") as BasicServiceCode;
        }

        public TransparencyIndicator transparencyIndicator
        {
            get { return m_children[ClassDef.m_children["transparencyIndicator"].m_index] as TransparencyIndicator; }
        }
        public TransparencyIndicator Create_transparencyIndicator()
        {
            return CreateChild("transparencyIndicator") as TransparencyIndicator;
        }

        public Fnur fnur
        {
            get { return m_children[ClassDef.m_children["fnur"].m_index] as Fnur; }
        }
        public Fnur Create_fnur()
        {
            return CreateChild("fnur") as Fnur;
        }

        public UserProtocolIndicator userProtocolIndicator
        {
            get { return m_children[ClassDef.m_children["userProtocolIndicator"].m_index] as UserProtocolIndicator; }
        }
        public UserProtocolIndicator Create_userProtocolIndicator()
        {
            return CreateChild("userProtocolIndicator") as UserProtocolIndicator;
        }

        public GuaranteedBitRate guaranteedBitRate
        {
            get { return m_children[ClassDef.m_children["guaranteedBitRate"].m_index] as GuaranteedBitRate; }
        }
        public GuaranteedBitRate Create_guaranteedBitRate()
        {
            return CreateChild("guaranteedBitRate") as GuaranteedBitRate;
        }

        public MaximumBitRate maximumBitRate
        {
            get { return m_children[ClassDef.m_children["maximumBitRate"].m_index] as MaximumBitRate; }
        }
        public MaximumBitRate Create_maximumBitRate()
        {
            return CreateChild("maximumBitRate") as MaximumBitRate;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F24);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F24);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new BasicServiceClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public BasicService()
        {
            m_children = new Asn1Object[6];
        }
        public class BasicServiceClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public BasicServiceClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("serviceCode", 0, CreateBasicServiceCode, true, null);
                m_posChildren.Add(0x5F832A, ch);
                m_children.Add("serviceCode", ch);

                ch = new OptionalNamedChild("transparencyIndicator", 1, CreateTransparencyIndicator, true, null);
                m_posChildren.Add(0x5F8164, ch);
                m_children.Add("transparencyIndicator", ch);

                ch = new OptionalNamedChild("fnur", 2, CreateFnur, true, null);
                m_posChildren.Add(0x5F6F, ch);
                m_children.Add("fnur", ch);

                ch = new OptionalNamedChild("userProtocolIndicator", 3, CreateUserProtocolIndicator, true, null);
                m_posChildren.Add(0x5F8218, ch);
                m_children.Add("userProtocolIndicator", ch);

                ch = new OptionalNamedChild("guaranteedBitRate", 4, CreateGuaranteedBitRate, true, null);
                m_posChildren.Add(0x5F8324, ch);
                m_children.Add("guaranteedBitRate", ch);

                ch = new OptionalNamedChild("maximumBitRate", 5, CreateMaximumBitRate, true, null);
                m_posChildren.Add(0x5F8325, ch);
                m_children.Add("maximumBitRate", ch);

            }
            public static BasicServiceCode CreateBasicServiceCode() { return new BasicServiceCode();}
            public static TransparencyIndicator CreateTransparencyIndicator() { return new TransparencyIndicator();}
            public static Fnur CreateFnur() { return new Fnur();}
            public static UserProtocolIndicator CreateUserProtocolIndicator() { return new UserProtocolIndicator();}
            public static GuaranteedBitRate CreateGuaranteedBitRate() { return new GuaranteedBitRate();}
            public static MaximumBitRate CreateMaximumBitRate() { return new MaximumBitRate();}
        }
    }

    public partial class BasicServiceCode : Asn1ChoiceObject
    {

        public TeleServiceCode teleServiceCode
        {
            get { return m_children[ClassDef.m_children["teleServiceCode"].m_index] as TeleServiceCode; }
        }
        public TeleServiceCode Create_teleServiceCode()
        {
            return CreateChild("teleServiceCode") as TeleServiceCode;
        }

        public BearerServiceCode bearerServiceCode
        {
            get { return m_children[ClassDef.m_children["bearerServiceCode"].m_index] as BearerServiceCode; }
        }
        public BearerServiceCode Create_bearerServiceCode()
        {
            return CreateChild("bearerServiceCode") as BearerServiceCode;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F832A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F832A);
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new BasicServiceCodeClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public BasicServiceCode()
        {
            m_children = new Asn1Object[2];
        }
        public class BasicServiceCodeClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public BasicServiceCodeClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("teleServiceCode", 0, CreateTeleServiceCode);
                m_posChildren.Add(0x5F815A, ch);
                m_children.Add("teleServiceCode", ch);
                ch = new NamedChild("bearerServiceCode", 1, CreateBearerServiceCode);
                m_posChildren.Add(0x5F28, ch);
                m_children.Add("bearerServiceCode", ch);
            }
            public static TeleServiceCode CreateTeleServiceCode() { return new TeleServiceCode();}
            public static BearerServiceCode CreateBearerServiceCode() { return new BearerServiceCode();}
        }
    }

    public partial class BasicServiceCodeList : Asn1SequenceOfObject<BasicServiceCode>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F25);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F25);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F832A } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<BasicServiceCode> CreateEmptyChild { get { return delegate() { return new BasicServiceCode (); }; } }
    }

    public partial class BasicServiceUsed : Asn1SequenceObject
    {

        public BasicService basicService
        {
            get { return m_children[ClassDef.m_children["basicService"].m_index] as BasicService; }
        }
        public BasicService Create_basicService()
        {
            return CreateChild("basicService") as BasicService;
        }

        public ChargingTimeStamp chargingTimeStamp
        {
            get { return m_children[ClassDef.m_children["chargingTimeStamp"].m_index] as ChargingTimeStamp; }
        }
        public ChargingTimeStamp Create_chargingTimeStamp()
        {
            return CreateChild("chargingTimeStamp") as ChargingTimeStamp;
        }

        public ChargeInformationList chargeInformationList
        {
            get { return m_children[ClassDef.m_children["chargeInformationList"].m_index] as ChargeInformationList; }
        }
        public ChargeInformationList Create_chargeInformationList()
        {
            return CreateChild("chargeInformationList") as ChargeInformationList;
        }

        public HSCSDIndicator hSCSDIndicator
        {
            get { return m_children[ClassDef.m_children["hSCSDIndicator"].m_index] as HSCSDIndicator; }
        }
        public HSCSDIndicator Create_hSCSDIndicator()
        {
            return CreateChild("hSCSDIndicator") as HSCSDIndicator;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F27);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F27);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new BasicServiceUsedClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public BasicServiceUsed()
        {
            m_children = new Asn1Object[4];
        }
        public class BasicServiceUsedClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public BasicServiceUsedClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("basicService", 0, CreateBasicService, true, null);
                m_posChildren.Add(0x5F24, ch);
                m_children.Add("basicService", ch);

                ch = new OptionalNamedChild("chargingTimeStamp", 1, CreateChargingTimeStamp, true, null);
                m_posChildren.Add(0x5F4A, ch);
                m_children.Add("chargingTimeStamp", ch);

                ch = new OptionalNamedChild("chargeInformationList", 2, CreateChargeInformationList, true, null);
                m_posChildren.Add(0x5F46, ch);
                m_children.Add("chargeInformationList", ch);

                ch = new OptionalNamedChild("hSCSDIndicator", 3, CreateHSCSDIndicator, true, null);
                m_posChildren.Add(0x5F8328, ch);
                m_children.Add("hSCSDIndicator", ch);

            }
            public static BasicService CreateBasicService() { return new BasicService();}
            public static ChargingTimeStamp CreateChargingTimeStamp() { return new ChargingTimeStamp();}
            public static ChargeInformationList CreateChargeInformationList() { return new ChargeInformationList();}
            public static HSCSDIndicator CreateHSCSDIndicator() { return new HSCSDIndicator();}
        }
    }

    public partial class BasicServiceUsedList : Asn1SequenceOfObject<BasicServiceUsed>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F26);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F26);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F27 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<BasicServiceUsed> CreateEmptyChild { get { return delegate() { return new BasicServiceUsed (); }; } }
    }

    public partial class BearerServiceCode : HexString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F28);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F28);
        }
    }

    public partial class CalledNumber : AddressStringDigits
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8317);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8317);
        }
    }

    public partial class CalledPlace : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F2A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F2A);
        }
    }

    public partial class CalledRegion : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F2E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F2E);
        }
    }

    public partial class CallEventDetailsCount : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F2B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F2B);
        }
    }

    public partial class CallEventStartTimeStamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F2C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F2C);
        }
    }

    public partial class CallingNumber : AddressStringDigits
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8315);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8315);
        }
    }

    public partial class CallOriginator : Asn1SequenceObject
    {

        public CallingNumber callingNumber
        {
            get { return m_children[ClassDef.m_children["callingNumber"].m_index] as CallingNumber; }
        }
        public CallingNumber Create_callingNumber()
        {
            return CreateChild("callingNumber") as CallingNumber;
        }

        public ClirIndicator clirIndicator
        {
            get { return m_children[ClassDef.m_children["clirIndicator"].m_index] as ClirIndicator; }
        }
        public ClirIndicator Create_clirIndicator()
        {
            return CreateChild("clirIndicator") as ClirIndicator;
        }

        public SMSOriginator sMSOriginator
        {
            get { return m_children[ClassDef.m_children["sMSOriginator"].m_index] as SMSOriginator; }
        }
        public SMSOriginator Create_sMSOriginator()
        {
            return CreateChild("sMSOriginator") as SMSOriginator;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F29);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F29);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new CallOriginatorClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public CallOriginator()
        {
            m_children = new Asn1Object[3];
        }
        public class CallOriginatorClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public CallOriginatorClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("callingNumber", 0, CreateCallingNumber, true, null);
                m_posChildren.Add(0x5F8315, ch);
                m_children.Add("callingNumber", ch);

                ch = new OptionalNamedChild("clirIndicator", 1, CreateClirIndicator, true, null);
                m_posChildren.Add(0x5F4B, ch);
                m_children.Add("clirIndicator", ch);

                ch = new OptionalNamedChild("sMSOriginator", 2, CreateSMSOriginator, true, null);
                m_posChildren.Add(0x5F8329, ch);
                m_children.Add("sMSOriginator", ch);

            }
            public static CallingNumber CreateCallingNumber() { return new CallingNumber();}
            public static ClirIndicator CreateClirIndicator() { return new ClirIndicator();}
            public static SMSOriginator CreateSMSOriginator() { return new SMSOriginator();}
        }
    }

    public partial class CallReference : Asn1OctetStringObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F2D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F2D);
        }
    }

    public partial class CallTypeGroup : Asn1SequenceObject
    {

        public CallTypeLevel1 callTypeLevel1
        {
            get { return m_children[ClassDef.m_children["callTypeLevel1"].m_index] as CallTypeLevel1; }
        }
        public CallTypeLevel1 Create_callTypeLevel1()
        {
            return CreateChild("callTypeLevel1") as CallTypeLevel1;
        }

        public CallTypeLevel2 callTypeLevel2
        {
            get { return m_children[ClassDef.m_children["callTypeLevel2"].m_index] as CallTypeLevel2; }
        }
        public CallTypeLevel2 Create_callTypeLevel2()
        {
            return CreateChild("callTypeLevel2") as CallTypeLevel2;
        }

        public CallTypeLevel3 callTypeLevel3
        {
            get { return m_children[ClassDef.m_children["callTypeLevel3"].m_index] as CallTypeLevel3; }
        }
        public CallTypeLevel3 Create_callTypeLevel3()
        {
            return CreateChild("callTypeLevel3") as CallTypeLevel3;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8202);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8202);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new CallTypeGroupClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public CallTypeGroup()
        {
            m_children = new Asn1Object[3];
        }
        public class CallTypeGroupClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public CallTypeGroupClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("callTypeLevel1", 0, CreateCallTypeLevel1, true, null);
                m_posChildren.Add(0x5F8203, ch);
                m_children.Add("callTypeLevel1", ch);

                ch = new OptionalNamedChild("callTypeLevel2", 1, CreateCallTypeLevel2, true, null);
                m_posChildren.Add(0x5F817F, ch);
                m_children.Add("callTypeLevel2", ch);

                ch = new OptionalNamedChild("callTypeLevel3", 2, CreateCallTypeLevel3, true, null);
                m_posChildren.Add(0x5F8200, ch);
                m_children.Add("callTypeLevel3", ch);

            }
            public static CallTypeLevel1 CreateCallTypeLevel1() { return new CallTypeLevel1();}
            public static CallTypeLevel2 CreateCallTypeLevel2() { return new CallTypeLevel2();}
            public static CallTypeLevel3 CreateCallTypeLevel3() { return new CallTypeLevel3();}
        }
    }

    public partial class CallTypeLevel1 : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8203);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8203);
        }
    }

    public partial class CallTypeLevel2 : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F817F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F817F);
        }
    }

    public partial class CallTypeLevel3 : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8200);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8200);
        }
    }

    public partial class CamelDestinationNumber : AddressStringDigits
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8314);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8314);
        }
    }

    public partial class CamelInvocationFee : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8326);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8326);
        }
    }

    public partial class CamelServiceKey : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F37);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F37);
        }
    }

    public partial class CamelServiceLevel : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F38);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F38);
        }
    }

    public partial class CamelServiceUsed : Asn1SequenceObject
    {

        public CamelServiceLevel camelServiceLevel
        {
            get { return m_children[ClassDef.m_children["camelServiceLevel"].m_index] as CamelServiceLevel; }
        }
        public CamelServiceLevel Create_camelServiceLevel()
        {
            return CreateChild("camelServiceLevel") as CamelServiceLevel;
        }

        public CamelServiceKey camelServiceKey
        {
            get { return m_children[ClassDef.m_children["camelServiceKey"].m_index] as CamelServiceKey; }
        }
        public CamelServiceKey Create_camelServiceKey()
        {
            return CreateChild("camelServiceKey") as CamelServiceKey;
        }

        public DefaultCallHandlingIndicator defaultCallHandling
        {
            get { return m_children[ClassDef.m_children["defaultCallHandling"].m_index] as DefaultCallHandlingIndicator; }
        }
        public DefaultCallHandlingIndicator Create_defaultCallHandling()
        {
            return CreateChild("defaultCallHandling") as DefaultCallHandlingIndicator;
        }

        public ExchangeRateCode exchangeRateCode
        {
            get { return m_children[ClassDef.m_children["exchangeRateCode"].m_index] as ExchangeRateCode; }
        }
        public ExchangeRateCode Create_exchangeRateCode()
        {
            return CreateChild("exchangeRateCode") as ExchangeRateCode;
        }

        public TaxInformationList taxInformation
        {
            get { return m_children[ClassDef.m_children["taxInformation"].m_index] as TaxInformationList; }
        }
        public TaxInformationList Create_taxInformation()
        {
            return CreateChild("taxInformation") as TaxInformationList;
        }

        public DiscountInformation discountInformation
        {
            get { return m_children[ClassDef.m_children["discountInformation"].m_index] as DiscountInformation; }
        }
        public DiscountInformation Create_discountInformation()
        {
            return CreateChild("discountInformation") as DiscountInformation;
        }

        public CamelInvocationFee camelInvocationFee
        {
            get { return m_children[ClassDef.m_children["camelInvocationFee"].m_index] as CamelInvocationFee; }
        }
        public CamelInvocationFee Create_camelInvocationFee()
        {
            return CreateChild("camelInvocationFee") as CamelInvocationFee;
        }

        public ThreeGcamelDestination threeGcamelDestination
        {
            get { return m_children[ClassDef.m_children["threeGcamelDestination"].m_index] as ThreeGcamelDestination; }
        }
        public ThreeGcamelDestination Create_threeGcamelDestination()
        {
            return CreateChild("threeGcamelDestination") as ThreeGcamelDestination;
        }

        public CseInformation cseInformation
        {
            get { return m_children[ClassDef.m_children["cseInformation"].m_index] as CseInformation; }
        }
        public CseInformation Create_cseInformation()
        {
            return CreateChild("cseInformation") as CseInformation;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F39);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F39);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new CamelServiceUsedClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public CamelServiceUsed()
        {
            m_children = new Asn1Object[9];
        }
        public class CamelServiceUsedClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public CamelServiceUsedClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("camelServiceLevel", 0, CreateCamelServiceLevel, true, null);
                m_posChildren.Add(0x5F38, ch);
                m_children.Add("camelServiceLevel", ch);

                ch = new OptionalNamedChild("camelServiceKey", 1, CreateCamelServiceKey, true, null);
                m_posChildren.Add(0x5F37, ch);
                m_children.Add("camelServiceKey", ch);

                ch = new OptionalNamedChild("defaultCallHandling", 2, CreateDefaultCallHandlingIndicator, true, null);
                m_posChildren.Add(0x5F57, ch);
                m_children.Add("defaultCallHandling", ch);

                ch = new OptionalNamedChild("exchangeRateCode", 3, CreateExchangeRateCode, true, null);
                m_posChildren.Add(0x5F69, ch);
                m_children.Add("exchangeRateCode", ch);

                ch = new OptionalNamedChild("taxInformation", 4, CreateTaxInformationList, true, null);
                m_posChildren.Add(0x5F8156, ch);
                m_children.Add("taxInformation", ch);

                ch = new OptionalNamedChild("discountInformation", 5, CreateDiscountInformation, true, null);
                m_posChildren.Add(0x5F60, ch);
                m_children.Add("discountInformation", ch);

                ch = new OptionalNamedChild("camelInvocationFee", 6, CreateCamelInvocationFee, true, null);
                m_posChildren.Add(0x5F8326, ch);
                m_children.Add("camelInvocationFee", ch);

                ch = new OptionalNamedChild("threeGcamelDestination", 7, CreateThreeGcamelDestination, true, null);
                m_posChildren.Add(0x5F832F, ch);
                m_children.Add("threeGcamelDestination", ch);

                ch = new OptionalNamedChild("cseInformation", 8, CreateCseInformation, true, null);
                m_posChildren.Add(0x5F4F, ch);
                m_children.Add("cseInformation", ch);

            }
            public static CamelServiceLevel CreateCamelServiceLevel() { return new CamelServiceLevel();}
            public static CamelServiceKey CreateCamelServiceKey() { return new CamelServiceKey();}
            public static DefaultCallHandlingIndicator CreateDefaultCallHandlingIndicator() { return new DefaultCallHandlingIndicator();}
            public static ExchangeRateCode CreateExchangeRateCode() { return new ExchangeRateCode();}
            public static TaxInformationList CreateTaxInformationList() { return new TaxInformationList();}
            public static DiscountInformation CreateDiscountInformation() { return new DiscountInformation();}
            public static CamelInvocationFee CreateCamelInvocationFee() { return new CamelInvocationFee();}
            public static ThreeGcamelDestination CreateThreeGcamelDestination() { return new ThreeGcamelDestination();}
            public static CseInformation CreateCseInformation() { return new CseInformation();}
        }
    }

    public partial class CauseForTerm : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F3A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F3A);
        }
    }

    public partial class CellId : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F3B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F3B);
        }
    }

    public partial class Charge : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F3E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F3E);
        }
    }

    public partial class ChargeableSubscriber : Asn1ChoiceObject
    {

        public SimChargeableSubscriber simChargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["simChargeableSubscriber"].m_index] as SimChargeableSubscriber; }
        }
        public SimChargeableSubscriber Create_simChargeableSubscriber()
        {
            return CreateChild("simChargeableSubscriber") as SimChargeableSubscriber;
        }

        public MinChargeableSubscriber minChargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["minChargeableSubscriber"].m_index] as MinChargeableSubscriber; }
        }
        public MinChargeableSubscriber Create_minChargeableSubscriber()
        {
            return CreateChild("minChargeableSubscriber") as MinChargeableSubscriber;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F832B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F832B);
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new ChargeableSubscriberClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ChargeableSubscriber()
        {
            m_children = new Asn1Object[2];
        }
        public class ChargeableSubscriberClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public ChargeableSubscriberClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("simChargeableSubscriber", 0, CreateSimChargeableSubscriber);
                m_posChildren.Add(0x5F8147, ch);
                m_children.Add("simChargeableSubscriber", ch);
                ch = new NamedChild("minChargeableSubscriber", 1, CreateMinChargeableSubscriber);
                m_posChildren.Add(0x5F817E, ch);
                m_children.Add("minChargeableSubscriber", ch);
            }
            public static SimChargeableSubscriber CreateSimChargeableSubscriber() { return new SimChargeableSubscriber();}
            public static MinChargeableSubscriber CreateMinChargeableSubscriber() { return new MinChargeableSubscriber();}
        }
    }

    public partial class ChargeableUnits : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F41);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F41);
        }
    }

    public partial class ChargeDetail : Asn1SequenceObject
    {

        public ChargeType chargeType
        {
            get { return m_children[ClassDef.m_children["chargeType"].m_index] as ChargeType; }
        }
        public ChargeType Create_chargeType()
        {
            return CreateChild("chargeType") as ChargeType;
        }

        public Charge charge
        {
            get { return m_children[ClassDef.m_children["charge"].m_index] as Charge; }
        }
        public Charge Create_charge()
        {
            return CreateChild("charge") as Charge;
        }

        public ChargeableUnits chargeableUnits
        {
            get { return m_children[ClassDef.m_children["chargeableUnits"].m_index] as ChargeableUnits; }
        }
        public ChargeableUnits Create_chargeableUnits()
        {
            return CreateChild("chargeableUnits") as ChargeableUnits;
        }

        public ChargedUnits chargedUnits
        {
            get { return m_children[ClassDef.m_children["chargedUnits"].m_index] as ChargedUnits; }
        }
        public ChargedUnits Create_chargedUnits()
        {
            return CreateChild("chargedUnits") as ChargedUnits;
        }

        public ChargeDetailTimeStamp chargeDetailTimeStamp
        {
            get { return m_children[ClassDef.m_children["chargeDetailTimeStamp"].m_index] as ChargeDetailTimeStamp; }
        }
        public ChargeDetailTimeStamp Create_chargeDetailTimeStamp()
        {
            return CreateChild("chargeDetailTimeStamp") as ChargeDetailTimeStamp;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F3F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F3F);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ChargeDetailClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ChargeDetail()
        {
            m_children = new Asn1Object[5];
        }
        public class ChargeDetailClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ChargeDetailClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargeType", 0, CreateChargeType, true, null);
                m_posChildren.Add(0x5F47, ch);
                m_children.Add("chargeType", ch);

                ch = new OptionalNamedChild("charge", 1, CreateCharge, true, null);
                m_posChildren.Add(0x5F3E, ch);
                m_children.Add("charge", ch);

                ch = new OptionalNamedChild("chargeableUnits", 2, CreateChargeableUnits, true, null);
                m_posChildren.Add(0x5F41, ch);
                m_children.Add("chargeableUnits", ch);

                ch = new OptionalNamedChild("chargedUnits", 3, CreateChargedUnits, true, null);
                m_posChildren.Add(0x5F44, ch);
                m_children.Add("chargedUnits", ch);

                ch = new OptionalNamedChild("chargeDetailTimeStamp", 4, CreateChargeDetailTimeStamp, true, null);
                m_posChildren.Add(0x5F831A, ch);
                m_children.Add("chargeDetailTimeStamp", ch);

            }
            public static ChargeType CreateChargeType() { return new ChargeType();}
            public static Charge CreateCharge() { return new Charge();}
            public static ChargeableUnits CreateChargeableUnits() { return new ChargeableUnits();}
            public static ChargedUnits CreateChargedUnits() { return new ChargedUnits();}
            public static ChargeDetailTimeStamp CreateChargeDetailTimeStamp() { return new ChargeDetailTimeStamp();}
        }
    }

    public partial class ChargeDetailList : Asn1SequenceOfObject<ChargeDetail>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F40);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F40);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F3F } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<ChargeDetail> CreateEmptyChild { get { return delegate() { return new ChargeDetail (); }; } }
    }

    public partial class ChargeDetailTimeStamp : ChargingTimeStamp
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F831A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F831A);
        }
    }

    public partial class ChargedItem : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F42);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F42);
        }
    }

    public partial class ChargedPartyEquipment : Asn1SequenceObject
    {

        public EquipmentIdType equipmentIdType
        {
            get { return m_children[ClassDef.m_children["equipmentIdType"].m_index] as EquipmentIdType; }
        }
        public EquipmentIdType Create_equipmentIdType()
        {
            return CreateChild("equipmentIdType") as EquipmentIdType;
        }

        public EquipmentId equipmentId
        {
            get { return m_children[ClassDef.m_children["equipmentId"].m_index] as EquipmentId; }
        }
        public EquipmentId Create_equipmentId()
        {
            return CreateChild("equipmentId") as EquipmentId;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8243);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8243);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ChargedPartyEquipmentClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ChargedPartyEquipment()
        {
            m_children = new Asn1Object[2];
        }
        public class ChargedPartyEquipmentClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ChargedPartyEquipmentClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("equipmentIdType", 0, CreateEquipmentIdType, true, null);
                m_posChildren.Add(0x5F8242, ch);
                m_children.Add("equipmentIdType", ch);

                ch = new OptionalNamedChild("equipmentId", 1, CreateEquipmentId, true, null);
                m_posChildren.Add(0x5F8222, ch);
                m_children.Add("equipmentId", ch);

            }
            public static EquipmentIdType CreateEquipmentIdType() { return new EquipmentIdType();}
            public static EquipmentId CreateEquipmentId() { return new EquipmentId();}
        }
    }

    public partial class ChargedPartyHomeIdentification : Asn1SequenceObject
    {

        public HomeIdType homeIdType
        {
            get { return m_children[ClassDef.m_children["homeIdType"].m_index] as HomeIdType; }
        }
        public HomeIdType Create_homeIdType()
        {
            return CreateChild("homeIdType") as HomeIdType;
        }

        public HomeIdentifier homeIdentifier
        {
            get { return m_children[ClassDef.m_children["homeIdentifier"].m_index] as HomeIdentifier; }
        }
        public HomeIdentifier Create_homeIdentifier()
        {
            return CreateChild("homeIdentifier") as HomeIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8239);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8239);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ChargedPartyHomeIdentificationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ChargedPartyHomeIdentification()
        {
            m_children = new Asn1Object[2];
        }
        public class ChargedPartyHomeIdentificationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ChargedPartyHomeIdentificationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("homeIdType", 0, CreateHomeIdType, true, null);
                m_posChildren.Add(0x5F8237, ch);
                m_children.Add("homeIdType", ch);

                ch = new OptionalNamedChild("homeIdentifier", 1, CreateHomeIdentifier, true, null);
                m_posChildren.Add(0x5F8220, ch);
                m_children.Add("homeIdentifier", ch);

            }
            public static HomeIdType CreateHomeIdType() { return new HomeIdType();}
            public static HomeIdentifier CreateHomeIdentifier() { return new HomeIdentifier();}
        }
    }

    public partial class ChargedPartyHomeIdList : Asn1SequenceOfObject<ChargedPartyHomeIdentification>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F823A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F823A);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8239 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<ChargedPartyHomeIdentification> CreateEmptyChild { get { return delegate() { return new ChargedPartyHomeIdentification (); }; } }
    }

    public partial class ChargedPartyIdentification : Asn1SequenceObject
    {

        public ChargedPartyIdType chargedPartyIdType
        {
            get { return m_children[ClassDef.m_children["chargedPartyIdType"].m_index] as ChargedPartyIdType; }
        }
        public ChargedPartyIdType Create_chargedPartyIdType()
        {
            return CreateChild("chargedPartyIdType") as ChargedPartyIdType;
        }

        public ChargedPartyIdentifier chargedPartyIdentifier
        {
            get { return m_children[ClassDef.m_children["chargedPartyIdentifier"].m_index] as ChargedPartyIdentifier; }
        }
        public ChargedPartyIdentifier Create_chargedPartyIdentifier()
        {
            return CreateChild("chargedPartyIdentifier") as ChargedPartyIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8235);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8235);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ChargedPartyIdentificationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ChargedPartyIdentification()
        {
            m_children = new Asn1Object[2];
        }
        public class ChargedPartyIdentificationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ChargedPartyIdentificationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargedPartyIdType", 0, CreateChargedPartyIdType, true, null);
                m_posChildren.Add(0x5F8231, ch);
                m_children.Add("chargedPartyIdType", ch);

                ch = new OptionalNamedChild("chargedPartyIdentifier", 1, CreateChargedPartyIdentifier, true, null);
                m_posChildren.Add(0x5F821F, ch);
                m_children.Add("chargedPartyIdentifier", ch);

            }
            public static ChargedPartyIdType CreateChargedPartyIdType() { return new ChargedPartyIdType();}
            public static ChargedPartyIdentifier CreateChargedPartyIdentifier() { return new ChargedPartyIdentifier();}
        }
    }

    public partial class ChargedPartyIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F821F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F821F);
        }
    }

    public partial class ChargedPartyIdList : Asn1SequenceOfObject<ChargedPartyIdentification>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8236);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8236);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8235 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<ChargedPartyIdentification> CreateEmptyChild { get { return delegate() { return new ChargedPartyIdentification (); }; } }
    }

    public partial class ChargedPartyIdType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8231);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8231);
        }
    }

    public partial class ChargedPartyInformation : Asn1SequenceObject
    {

        public ChargedPartyIdList chargedPartyIdList
        {
            get { return m_children[ClassDef.m_children["chargedPartyIdList"].m_index] as ChargedPartyIdList; }
        }
        public ChargedPartyIdList Create_chargedPartyIdList()
        {
            return CreateChild("chargedPartyIdList") as ChargedPartyIdList;
        }

        public ChargedPartyHomeIdList chargedPartyHomeIdList
        {
            get { return m_children[ClassDef.m_children["chargedPartyHomeIdList"].m_index] as ChargedPartyHomeIdList; }
        }
        public ChargedPartyHomeIdList Create_chargedPartyHomeIdList()
        {
            return CreateChild("chargedPartyHomeIdList") as ChargedPartyHomeIdList;
        }

        public ChargedPartyLocationList chargedPartyLocationList
        {
            get { return m_children[ClassDef.m_children["chargedPartyLocationList"].m_index] as ChargedPartyLocationList; }
        }
        public ChargedPartyLocationList Create_chargedPartyLocationList()
        {
            return CreateChild("chargedPartyLocationList") as ChargedPartyLocationList;
        }

        public ChargedPartyEquipment chargedPartyEquipment
        {
            get { return m_children[ClassDef.m_children["chargedPartyEquipment"].m_index] as ChargedPartyEquipment; }
        }
        public ChargedPartyEquipment Create_chargedPartyEquipment()
        {
            return CreateChild("chargedPartyEquipment") as ChargedPartyEquipment;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8244);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8244);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ChargedPartyInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ChargedPartyInformation()
        {
            m_children = new Asn1Object[4];
        }
        public class ChargedPartyInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ChargedPartyInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargedPartyIdList", 0, CreateChargedPartyIdList, true, null);
                m_posChildren.Add(0x5F8236, ch);
                m_children.Add("chargedPartyIdList", ch);

                ch = new OptionalNamedChild("chargedPartyHomeIdList", 1, CreateChargedPartyHomeIdList, true, null);
                m_posChildren.Add(0x5F823A, ch);
                m_children.Add("chargedPartyHomeIdList", ch);

                ch = new OptionalNamedChild("chargedPartyLocationList", 2, CreateChargedPartyLocationList, true, null);
                m_posChildren.Add(0x5F8241, ch);
                m_children.Add("chargedPartyLocationList", ch);

                ch = new OptionalNamedChild("chargedPartyEquipment", 3, CreateChargedPartyEquipment, true, null);
                m_posChildren.Add(0x5F8243, ch);
                m_children.Add("chargedPartyEquipment", ch);

            }
            public static ChargedPartyIdList CreateChargedPartyIdList() { return new ChargedPartyIdList();}
            public static ChargedPartyHomeIdList CreateChargedPartyHomeIdList() { return new ChargedPartyHomeIdList();}
            public static ChargedPartyLocationList CreateChargedPartyLocationList() { return new ChargedPartyLocationList();}
            public static ChargedPartyEquipment CreateChargedPartyEquipment() { return new ChargedPartyEquipment();}
        }
    }

    public partial class ChargedPartyLocation : Asn1SequenceObject
    {

        public LocationIdType locationIdType
        {
            get { return m_children[ClassDef.m_children["locationIdType"].m_index] as LocationIdType; }
        }
        public LocationIdType Create_locationIdType()
        {
            return CreateChild("locationIdType") as LocationIdType;
        }

        public LocationIdentifier locationIdentifier
        {
            get { return m_children[ClassDef.m_children["locationIdentifier"].m_index] as LocationIdentifier; }
        }
        public LocationIdentifier Create_locationIdentifier()
        {
            return CreateChild("locationIdentifier") as LocationIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8240);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8240);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ChargedPartyLocationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ChargedPartyLocation()
        {
            m_children = new Asn1Object[2];
        }
        public class ChargedPartyLocationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ChargedPartyLocationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("locationIdType", 0, CreateLocationIdType, true, null);
                m_posChildren.Add(0x5F823B, ch);
                m_children.Add("locationIdType", ch);

                ch = new OptionalNamedChild("locationIdentifier", 1, CreateLocationIdentifier, true, null);
                m_posChildren.Add(0x5F8221, ch);
                m_children.Add("locationIdentifier", ch);

            }
            public static LocationIdType CreateLocationIdType() { return new LocationIdType();}
            public static LocationIdentifier CreateLocationIdentifier() { return new LocationIdentifier();}
        }
    }

    public partial class ChargedPartyLocationList : Asn1SequenceOfObject<ChargedPartyLocation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8241);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8241);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8240 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<ChargedPartyLocation> CreateEmptyChild { get { return delegate() { return new ChargedPartyLocation (); }; } }
    }

    public partial class ChargedPartyStatus : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F43);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F43);
        }
    }

    public partial class ChargedUnits : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F44);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F44);
        }
    }

    public partial class ChargeInformation : Asn1SequenceObject
    {

        public ChargedItem chargedItem
        {
            get { return m_children[ClassDef.m_children["chargedItem"].m_index] as ChargedItem; }
        }
        public ChargedItem Create_chargedItem()
        {
            return CreateChild("chargedItem") as ChargedItem;
        }

        public ExchangeRateCode exchangeRateCode
        {
            get { return m_children[ClassDef.m_children["exchangeRateCode"].m_index] as ExchangeRateCode; }
        }
        public ExchangeRateCode Create_exchangeRateCode()
        {
            return CreateChild("exchangeRateCode") as ExchangeRateCode;
        }

        public CallTypeGroup callTypeGroup
        {
            get { return m_children[ClassDef.m_children["callTypeGroup"].m_index] as CallTypeGroup; }
        }
        public CallTypeGroup Create_callTypeGroup()
        {
            return CreateChild("callTypeGroup") as CallTypeGroup;
        }

        public ChargeDetailList chargeDetailList
        {
            get { return m_children[ClassDef.m_children["chargeDetailList"].m_index] as ChargeDetailList; }
        }
        public ChargeDetailList Create_chargeDetailList()
        {
            return CreateChild("chargeDetailList") as ChargeDetailList;
        }

        public TaxInformationList taxInformation
        {
            get { return m_children[ClassDef.m_children["taxInformation"].m_index] as TaxInformationList; }
        }
        public TaxInformationList Create_taxInformation()
        {
            return CreateChild("taxInformation") as TaxInformationList;
        }

        public DiscountInformation discountInformation
        {
            get { return m_children[ClassDef.m_children["discountInformation"].m_index] as DiscountInformation; }
        }
        public DiscountInformation Create_discountInformation()
        {
            return CreateChild("discountInformation") as DiscountInformation;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F45);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F45);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ChargeInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ChargeInformation()
        {
            m_children = new Asn1Object[6];
        }
        public class ChargeInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ChargeInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargedItem", 0, CreateChargedItem, true, null);
                m_posChildren.Add(0x5F42, ch);
                m_children.Add("chargedItem", ch);

                ch = new OptionalNamedChild("exchangeRateCode", 1, CreateExchangeRateCode, true, null);
                m_posChildren.Add(0x5F69, ch);
                m_children.Add("exchangeRateCode", ch);

                ch = new OptionalNamedChild("callTypeGroup", 2, CreateCallTypeGroup, true, null);
                m_posChildren.Add(0x5F8202, ch);
                m_children.Add("callTypeGroup", ch);

                ch = new OptionalNamedChild("chargeDetailList", 3, CreateChargeDetailList, true, null);
                m_posChildren.Add(0x5F40, ch);
                m_children.Add("chargeDetailList", ch);

                ch = new OptionalNamedChild("taxInformation", 4, CreateTaxInformationList, true, null);
                m_posChildren.Add(0x5F8156, ch);
                m_children.Add("taxInformation", ch);

                ch = new OptionalNamedChild("discountInformation", 5, CreateDiscountInformation, true, null);
                m_posChildren.Add(0x5F60, ch);
                m_children.Add("discountInformation", ch);

            }
            public static ChargedItem CreateChargedItem() { return new ChargedItem();}
            public static ExchangeRateCode CreateExchangeRateCode() { return new ExchangeRateCode();}
            public static CallTypeGroup CreateCallTypeGroup() { return new CallTypeGroup();}
            public static ChargeDetailList CreateChargeDetailList() { return new ChargeDetailList();}
            public static TaxInformationList CreateTaxInformationList() { return new TaxInformationList();}
            public static DiscountInformation CreateDiscountInformation() { return new DiscountInformation();}
        }
    }

    public partial class ChargeInformationList : Asn1SequenceOfObject<ChargeInformation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F46);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F46);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F45 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<ChargeInformation> CreateEmptyChild { get { return delegate() { return new ChargeInformation (); }; } }
    }

    public partial class ChargeRefundIndicator : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8258);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8258);
        }
    }

    public partial class ChargeType : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F47);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F47);
        }
    }

    public partial class ChargingId : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F48);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F48);
        }
    }

    public partial class ChargingPoint : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F49);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F49);
        }
    }

    public partial class ChargingTimeStamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F4A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F4A);
        }
    }

    public partial class ClirIndicator : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F4B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F4B);
        }
    }

    public partial class Commission : Charge
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F825E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F825E);
        }
    }

    public partial class CompletionTimeStamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F4C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F4C);
        }
    }

    public partial class ContentChargingPoint : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8259);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8259);
        }
    }

    public partial class ContentProvider : Asn1SequenceObject
    {

        public ContentProviderIdType contentProviderIdType
        {
            get { return m_children[ClassDef.m_children["contentProviderIdType"].m_index] as ContentProviderIdType; }
        }
        public ContentProviderIdType Create_contentProviderIdType()
        {
            return CreateChild("contentProviderIdType") as ContentProviderIdType;
        }

        public ContentProviderIdentifier contentProviderIdentifier
        {
            get { return m_children[ClassDef.m_children["contentProviderIdentifier"].m_index] as ContentProviderIdentifier; }
        }
        public ContentProviderIdentifier Create_contentProviderIdentifier()
        {
            return CreateChild("contentProviderIdentifier") as ContentProviderIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8247);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8247);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ContentProviderClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ContentProvider()
        {
            m_children = new Asn1Object[2];
        }
        public class ContentProviderClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ContentProviderClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("contentProviderIdType", 0, CreateContentProviderIdType, true, null);
                m_posChildren.Add(0x5F8223, ch);
                m_children.Add("contentProviderIdType", ch);

                ch = new OptionalNamedChild("contentProviderIdentifier", 1, CreateContentProviderIdentifier, true, null);
                m_posChildren.Add(0x5F8224, ch);
                m_children.Add("contentProviderIdentifier", ch);

            }
            public static ContentProviderIdType CreateContentProviderIdType() { return new ContentProviderIdType();}
            public static ContentProviderIdentifier CreateContentProviderIdentifier() { return new ContentProviderIdentifier();}
        }
    }

    public partial class ContentProviderIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8224);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8224);
        }
    }

    public partial class ContentProviderIdList : Asn1SequenceOfObject<ContentProvider>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8248);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8248);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8247 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<ContentProvider> CreateEmptyChild { get { return delegate() { return new ContentProvider (); }; } }
    }

    public partial class ContentProviderIdType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8223);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8223);
        }
    }

    public partial class ContentProviderName : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F824E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F824E);
        }
    }

    public partial class ContentServiceUsed : Asn1SequenceObject
    {

        public ContentTransactionCode contentTransactionCode
        {
            get { return m_children[ClassDef.m_children["contentTransactionCode"].m_index] as ContentTransactionCode; }
        }
        public ContentTransactionCode Create_contentTransactionCode()
        {
            return CreateChild("contentTransactionCode") as ContentTransactionCode;
        }

        public ContentTransactionType contentTransactionType
        {
            get { return m_children[ClassDef.m_children["contentTransactionType"].m_index] as ContentTransactionType; }
        }
        public ContentTransactionType Create_contentTransactionType()
        {
            return CreateChild("contentTransactionType") as ContentTransactionType;
        }

        public ObjectType objectType
        {
            get { return m_children[ClassDef.m_children["objectType"].m_index] as ObjectType; }
        }
        public ObjectType Create_objectType()
        {
            return CreateChild("objectType") as ObjectType;
        }

        public TransactionDescriptionSupp transactionDescriptionSupp
        {
            get { return m_children[ClassDef.m_children["transactionDescriptionSupp"].m_index] as TransactionDescriptionSupp; }
        }
        public TransactionDescriptionSupp Create_transactionDescriptionSupp()
        {
            return CreateChild("transactionDescriptionSupp") as TransactionDescriptionSupp;
        }

        public TransactionShortDescription transactionShortDescription
        {
            get { return m_children[ClassDef.m_children["transactionShortDescription"].m_index] as TransactionShortDescription; }
        }
        public TransactionShortDescription Create_transactionShortDescription()
        {
            return CreateChild("transactionShortDescription") as TransactionShortDescription;
        }

        public TransactionDetailDescription transactionDetailDescription
        {
            get { return m_children[ClassDef.m_children["transactionDetailDescription"].m_index] as TransactionDetailDescription; }
        }
        public TransactionDetailDescription Create_transactionDetailDescription()
        {
            return CreateChild("transactionDetailDescription") as TransactionDetailDescription;
        }

        public TransactionIdentifier transactionIdentifier
        {
            get { return m_children[ClassDef.m_children["transactionIdentifier"].m_index] as TransactionIdentifier; }
        }
        public TransactionIdentifier Create_transactionIdentifier()
        {
            return CreateChild("transactionIdentifier") as TransactionIdentifier;
        }

        public TransactionAuthCode transactionAuthCode
        {
            get { return m_children[ClassDef.m_children["transactionAuthCode"].m_index] as TransactionAuthCode; }
        }
        public TransactionAuthCode Create_transactionAuthCode()
        {
            return CreateChild("transactionAuthCode") as TransactionAuthCode;
        }

        public DataVolumeIncoming dataVolumeIncoming
        {
            get { return m_children[ClassDef.m_children["dataVolumeIncoming"].m_index] as DataVolumeIncoming; }
        }
        public DataVolumeIncoming Create_dataVolumeIncoming()
        {
            return CreateChild("dataVolumeIncoming") as DataVolumeIncoming;
        }

        public DataVolumeOutgoing dataVolumeOutgoing
        {
            get { return m_children[ClassDef.m_children["dataVolumeOutgoing"].m_index] as DataVolumeOutgoing; }
        }
        public DataVolumeOutgoing Create_dataVolumeOutgoing()
        {
            return CreateChild("dataVolumeOutgoing") as DataVolumeOutgoing;
        }

        public TotalDataVolume totalDataVolume
        {
            get { return m_children[ClassDef.m_children["totalDataVolume"].m_index] as TotalDataVolume; }
        }
        public TotalDataVolume Create_totalDataVolume()
        {
            return CreateChild("totalDataVolume") as TotalDataVolume;
        }

        public ChargeRefundIndicator chargeRefundIndicator
        {
            get { return m_children[ClassDef.m_children["chargeRefundIndicator"].m_index] as ChargeRefundIndicator; }
        }
        public ChargeRefundIndicator Create_chargeRefundIndicator()
        {
            return CreateChild("chargeRefundIndicator") as ChargeRefundIndicator;
        }

        public ContentChargingPoint contentChargingPoint
        {
            get { return m_children[ClassDef.m_children["contentChargingPoint"].m_index] as ContentChargingPoint; }
        }
        public ContentChargingPoint Create_contentChargingPoint()
        {
            return CreateChild("contentChargingPoint") as ContentChargingPoint;
        }

        public ChargeInformationList chargeInformationList
        {
            get { return m_children[ClassDef.m_children["chargeInformationList"].m_index] as ChargeInformationList; }
        }
        public ChargeInformationList Create_chargeInformationList()
        {
            return CreateChild("chargeInformationList") as ChargeInformationList;
        }

        public AdvisedChargeInformation advisedChargeInformation
        {
            get { return m_children[ClassDef.m_children["advisedChargeInformation"].m_index] as AdvisedChargeInformation; }
        }
        public AdvisedChargeInformation Create_advisedChargeInformation()
        {
            return CreateChild("advisedChargeInformation") as AdvisedChargeInformation;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8260);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8260);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ContentServiceUsedClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ContentServiceUsed()
        {
            m_children = new Asn1Object[15];
        }
        public class ContentServiceUsedClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ContentServiceUsedClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("contentTransactionCode", 0, CreateContentTransactionCode, true, null);
                m_posChildren.Add(0x5F8250, ch);
                m_children.Add("contentTransactionCode", ch);

                ch = new OptionalNamedChild("contentTransactionType", 1, CreateContentTransactionType, true, null);
                m_posChildren.Add(0x5F8251, ch);
                m_children.Add("contentTransactionType", ch);

                ch = new OptionalNamedChild("objectType", 2, CreateObjectType, true, null);
                m_posChildren.Add(0x5F8219, ch);
                m_children.Add("objectType", ch);

                ch = new OptionalNamedChild("transactionDescriptionSupp", 3, CreateTransactionDescriptionSupp, true, null);
                m_posChildren.Add(0x5F8252, ch);
                m_children.Add("transactionDescriptionSupp", ch);

                ch = new OptionalNamedChild("transactionShortDescription", 4, CreateTransactionShortDescription, true, null);
                m_posChildren.Add(0x5F8254, ch);
                m_children.Add("transactionShortDescription", ch);

                ch = new OptionalNamedChild("transactionDetailDescription", 5, CreateTransactionDetailDescription, true, null);
                m_posChildren.Add(0x5F8253, ch);
                m_children.Add("transactionDetailDescription", ch);

                ch = new OptionalNamedChild("transactionIdentifier", 6, CreateTransactionIdentifier, true, null);
                m_posChildren.Add(0x5F8255, ch);
                m_children.Add("transactionIdentifier", ch);

                ch = new OptionalNamedChild("transactionAuthCode", 7, CreateTransactionAuthCode, true, null);
                m_posChildren.Add(0x5F8256, ch);
                m_children.Add("transactionAuthCode", ch);

                ch = new OptionalNamedChild("dataVolumeIncoming", 8, CreateDataVolumeIncoming, true, null);
                m_posChildren.Add(0x5F817A, ch);
                m_children.Add("dataVolumeIncoming", ch);

                ch = new OptionalNamedChild("dataVolumeOutgoing", 9, CreateDataVolumeOutgoing, true, null);
                m_posChildren.Add(0x5F817B, ch);
                m_children.Add("dataVolumeOutgoing", ch);

                ch = new OptionalNamedChild("totalDataVolume", 10, CreateTotalDataVolume, true, null);
                m_posChildren.Add(0x5F8257, ch);
                m_children.Add("totalDataVolume", ch);

                ch = new OptionalNamedChild("chargeRefundIndicator", 11, CreateChargeRefundIndicator, true, null);
                m_posChildren.Add(0x5F8258, ch);
                m_children.Add("chargeRefundIndicator", ch);

                ch = new OptionalNamedChild("contentChargingPoint", 12, CreateContentChargingPoint, true, null);
                m_posChildren.Add(0x5F8259, ch);
                m_children.Add("contentChargingPoint", ch);

                ch = new OptionalNamedChild("chargeInformationList", 13, CreateChargeInformationList, true, null);
                m_posChildren.Add(0x5F46, ch);
                m_children.Add("chargeInformationList", ch);

                ch = new OptionalNamedChild("advisedChargeInformation", 14, CreateAdvisedChargeInformation, true, null);
                m_posChildren.Add(0x5F825F, ch);
                m_children.Add("advisedChargeInformation", ch);

            }
            public static ContentTransactionCode CreateContentTransactionCode() { return new ContentTransactionCode();}
            public static ContentTransactionType CreateContentTransactionType() { return new ContentTransactionType();}
            public static ObjectType CreateObjectType() { return new ObjectType();}
            public static TransactionDescriptionSupp CreateTransactionDescriptionSupp() { return new TransactionDescriptionSupp();}
            public static TransactionShortDescription CreateTransactionShortDescription() { return new TransactionShortDescription();}
            public static TransactionDetailDescription CreateTransactionDetailDescription() { return new TransactionDetailDescription();}
            public static TransactionIdentifier CreateTransactionIdentifier() { return new TransactionIdentifier();}
            public static TransactionAuthCode CreateTransactionAuthCode() { return new TransactionAuthCode();}
            public static DataVolumeIncoming CreateDataVolumeIncoming() { return new DataVolumeIncoming();}
            public static DataVolumeOutgoing CreateDataVolumeOutgoing() { return new DataVolumeOutgoing();}
            public static TotalDataVolume CreateTotalDataVolume() { return new TotalDataVolume();}
            public static ChargeRefundIndicator CreateChargeRefundIndicator() { return new ChargeRefundIndicator();}
            public static ContentChargingPoint CreateContentChargingPoint() { return new ContentChargingPoint();}
            public static ChargeInformationList CreateChargeInformationList() { return new ChargeInformationList();}
            public static AdvisedChargeInformation CreateAdvisedChargeInformation() { return new AdvisedChargeInformation();}
        }
    }

    public partial class ContentServiceUsedList : Asn1SequenceOfObject<ContentServiceUsed>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F821D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F821D);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8260 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<ContentServiceUsed> CreateEmptyChild { get { return delegate() { return new ContentServiceUsed (); }; } }
    }

    public partial class ContentTransactionBasicInfo : Asn1SequenceObject
    {

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public OrderPlacedTimeStamp orderPlacedTimeStamp
        {
            get { return m_children[ClassDef.m_children["orderPlacedTimeStamp"].m_index] as OrderPlacedTimeStamp; }
        }
        public OrderPlacedTimeStamp Create_orderPlacedTimeStamp()
        {
            return CreateChild("orderPlacedTimeStamp") as OrderPlacedTimeStamp;
        }

        public RequestedDeliveryTimeStamp requestedDeliveryTimeStamp
        {
            get { return m_children[ClassDef.m_children["requestedDeliveryTimeStamp"].m_index] as RequestedDeliveryTimeStamp; }
        }
        public RequestedDeliveryTimeStamp Create_requestedDeliveryTimeStamp()
        {
            return CreateChild("requestedDeliveryTimeStamp") as RequestedDeliveryTimeStamp;
        }

        public ActualDeliveryTimeStamp actualDeliveryTimeStamp
        {
            get { return m_children[ClassDef.m_children["actualDeliveryTimeStamp"].m_index] as ActualDeliveryTimeStamp; }
        }
        public ActualDeliveryTimeStamp Create_actualDeliveryTimeStamp()
        {
            return CreateChild("actualDeliveryTimeStamp") as ActualDeliveryTimeStamp;
        }

        public TotalTransactionDuration totalTransactionDuration
        {
            get { return m_children[ClassDef.m_children["totalTransactionDuration"].m_index] as TotalTransactionDuration; }
        }
        public TotalTransactionDuration Create_totalTransactionDuration()
        {
            return CreateChild("totalTransactionDuration") as TotalTransactionDuration;
        }

        public TransactionStatus transactionStatus
        {
            get { return m_children[ClassDef.m_children["transactionStatus"].m_index] as TransactionStatus; }
        }
        public TransactionStatus Create_transactionStatus()
        {
            return CreateChild("transactionStatus") as TransactionStatus;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8230);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8230);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ContentTransactionBasicInfoClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ContentTransactionBasicInfo()
        {
            m_children = new Asn1Object[6];
        }
        public class ContentTransactionBasicInfoClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ContentTransactionBasicInfoClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("rapFileSequenceNumber", 0, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("orderPlacedTimeStamp", 1, CreateOrderPlacedTimeStamp, true, null);
                m_posChildren.Add(0x5F822C, ch);
                m_children.Add("orderPlacedTimeStamp", ch);

                ch = new OptionalNamedChild("requestedDeliveryTimeStamp", 2, CreateRequestedDeliveryTimeStamp, true, null);
                m_posChildren.Add(0x5F822D, ch);
                m_children.Add("requestedDeliveryTimeStamp", ch);

                ch = new OptionalNamedChild("actualDeliveryTimeStamp", 3, CreateActualDeliveryTimeStamp, true, null);
                m_posChildren.Add(0x5F822E, ch);
                m_children.Add("actualDeliveryTimeStamp", ch);

                ch = new OptionalNamedChild("totalTransactionDuration", 4, CreateTotalTransactionDuration, true, null);
                m_posChildren.Add(0x5F8320, ch);
                m_children.Add("totalTransactionDuration", ch);

                ch = new OptionalNamedChild("transactionStatus", 5, CreateTransactionStatus, true, null);
                m_posChildren.Add(0x5F822F, ch);
                m_children.Add("transactionStatus", ch);

            }
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static OrderPlacedTimeStamp CreateOrderPlacedTimeStamp() { return new OrderPlacedTimeStamp();}
            public static RequestedDeliveryTimeStamp CreateRequestedDeliveryTimeStamp() { return new RequestedDeliveryTimeStamp();}
            public static ActualDeliveryTimeStamp CreateActualDeliveryTimeStamp() { return new ActualDeliveryTimeStamp();}
            public static TotalTransactionDuration CreateTotalTransactionDuration() { return new TotalTransactionDuration();}
            public static TransactionStatus CreateTransactionStatus() { return new TransactionStatus();}
        }
    }

    public partial class ContentTransactionCode : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8250);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8250);
        }
    }

    public partial class ContentTransactionType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8251);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8251);
        }
    }

    public partial class CseInformation : Asn1OctetStringObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F4F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F4F);
        }
    }

    public partial class CurrencyConversion : Asn1SequenceObject
    {

        public ExchangeRateCode exchangeRateCode
        {
            get { return m_children[ClassDef.m_children["exchangeRateCode"].m_index] as ExchangeRateCode; }
        }
        public ExchangeRateCode Create_exchangeRateCode()
        {
            return CreateChild("exchangeRateCode") as ExchangeRateCode;
        }

        public NumberOfDecimalPlaces numberOfDecimalPlaces
        {
            get { return m_children[ClassDef.m_children["numberOfDecimalPlaces"].m_index] as NumberOfDecimalPlaces; }
        }
        public NumberOfDecimalPlaces Create_numberOfDecimalPlaces()
        {
            return CreateChild("numberOfDecimalPlaces") as NumberOfDecimalPlaces;
        }

        public ExchangeRate exchangeRate
        {
            get { return m_children[ClassDef.m_children["exchangeRate"].m_index] as ExchangeRate; }
        }
        public ExchangeRate Create_exchangeRate()
        {
            return CreateChild("exchangeRate") as ExchangeRate;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F6A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F6A);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new CurrencyConversionClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public CurrencyConversion()
        {
            m_children = new Asn1Object[3];
        }
        public class CurrencyConversionClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public CurrencyConversionClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("exchangeRateCode", 0, CreateExchangeRateCode, true, null);
                m_posChildren.Add(0x5F69, ch);
                m_children.Add("exchangeRateCode", ch);

                ch = new OptionalNamedChild("numberOfDecimalPlaces", 1, CreateNumberOfDecimalPlaces, true, null);
                m_posChildren.Add(0x5F811F, ch);
                m_children.Add("numberOfDecimalPlaces", ch);

                ch = new OptionalNamedChild("exchangeRate", 2, CreateExchangeRate, true, null);
                m_posChildren.Add(0x5F68, ch);
                m_children.Add("exchangeRate", ch);

            }
            public static ExchangeRateCode CreateExchangeRateCode() { return new ExchangeRateCode();}
            public static NumberOfDecimalPlaces CreateNumberOfDecimalPlaces() { return new NumberOfDecimalPlaces();}
            public static ExchangeRate CreateExchangeRate() { return new ExchangeRate();}
        }
    }

    public partial class CurrencyConversionList : Asn1SequenceOfObject<CurrencyConversion>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F50);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F50);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F6A } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<CurrencyConversion> CreateEmptyChild { get { return delegate() { return new CurrencyConversion (); }; } }
    }

    public partial class CustomerIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F826C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F826C);
        }
    }

    public partial class CustomerIdType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F826B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F826B);
        }
    }

    public partial class DataVolume : Asn1IntegerObject
    {
    }

    public partial class DataVolumeIncoming : DataVolume
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F817A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F817A);
        }
    }

    public partial class DataVolumeOutgoing : DataVolume
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F817B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F817B);
        }
    }

    public partial class DateTime : Asn1SequenceObject
    {

        public LocalTimeStamp localTimeStamp
        {
            get { return m_children[ClassDef.m_children["localTimeStamp"].m_index] as LocalTimeStamp; }
        }
        public LocalTimeStamp Create_localTimeStamp()
        {
            return CreateChild("localTimeStamp") as LocalTimeStamp;
        }

        public UtcTimeOffsetCode utcTimeOffsetCode
        {
            get { return m_children[ClassDef.m_children["utcTimeOffsetCode"].m_index] as UtcTimeOffsetCode; }
        }
        public UtcTimeOffsetCode Create_utcTimeOffsetCode()
        {
            return CreateChild("utcTimeOffsetCode") as UtcTimeOffsetCode;
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new DateTimeClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public DateTime()
        {
            m_children = new Asn1Object[2];
        }
        public class DateTimeClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public DateTimeClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("localTimeStamp", 0, CreateLocalTimeStamp, true, null);
                m_posChildren.Add(0x50, ch);
                m_children.Add("localTimeStamp", ch);

                ch = new OptionalNamedChild("utcTimeOffsetCode", 1, CreateUtcTimeOffsetCode, true, null);
                m_posChildren.Add(0x5F8168, ch);
                m_children.Add("utcTimeOffsetCode", ch);

            }
            public static LocalTimeStamp CreateLocalTimeStamp() { return new LocalTimeStamp();}
            public static UtcTimeOffsetCode CreateUtcTimeOffsetCode() { return new UtcTimeOffsetCode();}
        }
    }

    public partial class DateTimeLong : Asn1SequenceObject
    {

        public LocalTimeStamp localTimeStamp
        {
            get { return m_children[ClassDef.m_children["localTimeStamp"].m_index] as LocalTimeStamp; }
        }
        public LocalTimeStamp Create_localTimeStamp()
        {
            return CreateChild("localTimeStamp") as LocalTimeStamp;
        }

        public UtcTimeOffset utcTimeOffset
        {
            get { return m_children[ClassDef.m_children["utcTimeOffset"].m_index] as UtcTimeOffset; }
        }
        public UtcTimeOffset Create_utcTimeOffset()
        {
            return CreateChild("utcTimeOffset") as UtcTimeOffset;
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new DateTimeLongClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public DateTimeLong()
        {
            m_children = new Asn1Object[2];
        }
        public class DateTimeLongClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public DateTimeLongClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("localTimeStamp", 0, CreateLocalTimeStamp, true, null);
                m_posChildren.Add(0x50, ch);
                m_children.Add("localTimeStamp", ch);

                ch = new OptionalNamedChild("utcTimeOffset", 1, CreateUtcTimeOffset, true, null);
                m_posChildren.Add(0x5F8167, ch);
                m_children.Add("utcTimeOffset", ch);

            }
            public static LocalTimeStamp CreateLocalTimeStamp() { return new LocalTimeStamp();}
            public static UtcTimeOffset CreateUtcTimeOffset() { return new UtcTimeOffset();}
        }
    }

    public partial class DefaultCallHandlingIndicator : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F57);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F57);
        }
    }

    public partial class DepositTimeStamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F58);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F58);
        }
    }

    public partial class Destination : Asn1SequenceObject
    {

        public CalledNumber calledNumber
        {
            get { return m_children[ClassDef.m_children["calledNumber"].m_index] as CalledNumber; }
        }
        public CalledNumber Create_calledNumber()
        {
            return CreateChild("calledNumber") as CalledNumber;
        }

        public DialledDigits dialledDigits
        {
            get { return m_children[ClassDef.m_children["dialledDigits"].m_index] as DialledDigits; }
        }
        public DialledDigits Create_dialledDigits()
        {
            return CreateChild("dialledDigits") as DialledDigits;
        }

        public CalledPlace calledPlace
        {
            get { return m_children[ClassDef.m_children["calledPlace"].m_index] as CalledPlace; }
        }
        public CalledPlace Create_calledPlace()
        {
            return CreateChild("calledPlace") as CalledPlace;
        }

        public CalledRegion calledRegion
        {
            get { return m_children[ClassDef.m_children["calledRegion"].m_index] as CalledRegion; }
        }
        public CalledRegion Create_calledRegion()
        {
            return CreateChild("calledRegion") as CalledRegion;
        }

        public SMSDestinationNumber sMSDestinationNumber
        {
            get { return m_children[ClassDef.m_children["sMSDestinationNumber"].m_index] as SMSDestinationNumber; }
        }
        public SMSDestinationNumber Create_sMSDestinationNumber()
        {
            return CreateChild("sMSDestinationNumber") as SMSDestinationNumber;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F59);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F59);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new DestinationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Destination()
        {
            m_children = new Asn1Object[5];
        }
        public class DestinationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public DestinationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("calledNumber", 0, CreateCalledNumber, true, null);
                m_posChildren.Add(0x5F8317, ch);
                m_children.Add("calledNumber", ch);

                ch = new OptionalNamedChild("dialledDigits", 1, CreateDialledDigits, true, null);
                m_posChildren.Add(0x5F8217, ch);
                m_children.Add("dialledDigits", ch);

                ch = new OptionalNamedChild("calledPlace", 2, CreateCalledPlace, true, null);
                m_posChildren.Add(0x5F2A, ch);
                m_children.Add("calledPlace", ch);

                ch = new OptionalNamedChild("calledRegion", 3, CreateCalledRegion, true, null);
                m_posChildren.Add(0x5F2E, ch);
                m_children.Add("calledRegion", ch);

                ch = new OptionalNamedChild("sMSDestinationNumber", 4, CreateSMSDestinationNumber, true, null);
                m_posChildren.Add(0x5F8323, ch);
                m_children.Add("sMSDestinationNumber", ch);

            }
            public static CalledNumber CreateCalledNumber() { return new CalledNumber();}
            public static DialledDigits CreateDialledDigits() { return new DialledDigits();}
            public static CalledPlace CreateCalledPlace() { return new CalledPlace();}
            public static CalledRegion CreateCalledRegion() { return new CalledRegion();}
            public static SMSDestinationNumber CreateSMSDestinationNumber() { return new SMSDestinationNumber();}
        }
    }

    public partial class DestinationNetwork : NetworkId
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F5A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F5A);
        }
    }

    public partial class DialledDigits : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8217);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8217);
        }
    }

    public partial class Discount : DiscountValue
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F831C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F831C);
        }
    }

    public partial class DiscountableAmount : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8327);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8327);
        }
    }

    public partial class DiscountApplied : Asn1ChoiceObject
    {

        public FixedDiscountValue fixedDiscountValue
        {
            get { return m_children[ClassDef.m_children["fixedDiscountValue"].m_index] as FixedDiscountValue; }
        }
        public FixedDiscountValue Create_fixedDiscountValue()
        {
            return CreateChild("fixedDiscountValue") as FixedDiscountValue;
        }

        public DiscountRate discountRate
        {
            get { return m_children[ClassDef.m_children["discountRate"].m_index] as DiscountRate; }
        }
        public DiscountRate Create_discountRate()
        {
            return CreateChild("discountRate") as DiscountRate;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F832C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F832C);
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new DiscountAppliedClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public DiscountApplied()
        {
            m_children = new Asn1Object[2];
        }
        public class DiscountAppliedClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public DiscountAppliedClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("fixedDiscountValue", 0, CreateFixedDiscountValue);
                m_posChildren.Add(0x5F831B, ch);
                m_children.Add("fixedDiscountValue", ch);
                ch = new NamedChild("discountRate", 1, CreateDiscountRate);
                m_posChildren.Add(0x5F5C, ch);
                m_children.Add("discountRate", ch);
            }
            public static FixedDiscountValue CreateFixedDiscountValue() { return new FixedDiscountValue();}
            public static DiscountRate CreateDiscountRate() { return new DiscountRate();}
        }
    }

    public partial class DiscountCode : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F5B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F5B);
        }
    }

    public partial class DiscountInformation : Asn1SequenceObject
    {

        public DiscountCode discountCode
        {
            get { return m_children[ClassDef.m_children["discountCode"].m_index] as DiscountCode; }
        }
        public DiscountCode Create_discountCode()
        {
            return CreateChild("discountCode") as DiscountCode;
        }

        public Discount discount
        {
            get { return m_children[ClassDef.m_children["discount"].m_index] as Discount; }
        }
        public Discount Create_discount()
        {
            return CreateChild("discount") as Discount;
        }

        public DiscountableAmount discountableAmount
        {
            get { return m_children[ClassDef.m_children["discountableAmount"].m_index] as DiscountableAmount; }
        }
        public DiscountableAmount Create_discountableAmount()
        {
            return CreateChild("discountableAmount") as DiscountableAmount;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F60);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F60);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new DiscountInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public DiscountInformation()
        {
            m_children = new Asn1Object[3];
        }
        public class DiscountInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public DiscountInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("discountCode", 0, CreateDiscountCode, true, null);
                m_posChildren.Add(0x5F5B, ch);
                m_children.Add("discountCode", ch);

                ch = new OptionalNamedChild("discount", 1, CreateDiscount, true, null);
                m_posChildren.Add(0x5F831C, ch);
                m_children.Add("discount", ch);

                ch = new OptionalNamedChild("discountableAmount", 2, CreateDiscountableAmount, true, null);
                m_posChildren.Add(0x5F8327, ch);
                m_children.Add("discountableAmount", ch);

            }
            public static DiscountCode CreateDiscountCode() { return new DiscountCode();}
            public static Discount CreateDiscount() { return new Discount();}
            public static DiscountableAmount CreateDiscountableAmount() { return new DiscountableAmount();}
        }
    }

    public partial class Discounting : Asn1SequenceObject
    {

        public DiscountCode discountCode
        {
            get { return m_children[ClassDef.m_children["discountCode"].m_index] as DiscountCode; }
        }
        public DiscountCode Create_discountCode()
        {
            return CreateChild("discountCode") as DiscountCode;
        }

        public DiscountApplied discountApplied
        {
            get { return m_children[ClassDef.m_children["discountApplied"].m_index] as DiscountApplied; }
        }
        public DiscountApplied Create_discountApplied()
        {
            return CreateChild("discountApplied") as DiscountApplied;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F5E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F5E);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new DiscountingClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Discounting()
        {
            m_children = new Asn1Object[2];
        }
        public class DiscountingClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public DiscountingClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("discountCode", 0, CreateDiscountCode, true, null);
                m_posChildren.Add(0x5F5B, ch);
                m_children.Add("discountCode", ch);

                ch = new OptionalNamedChild("discountApplied", 1, CreateDiscountApplied, true, null);
                m_posChildren.Add(0x5F832C, ch);
                m_children.Add("discountApplied", ch);

            }
            public static DiscountCode CreateDiscountCode() { return new DiscountCode();}
            public static DiscountApplied CreateDiscountApplied() { return new DiscountApplied();}
        }
    }

    public partial class DiscountingList : Asn1SequenceOfObject<Discounting>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F5F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F5F);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F5E } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<Discounting> CreateEmptyChild { get { return delegate() { return new Discounting (); }; } }
    }

    public partial class DiscountRate : PercentageRate
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F5C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F5C);
        }
    }

    public partial class DiscountValue : AbsoluteAmount
    {
    }

    public partial class DistanceChargeBandCode : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F62);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F62);
        }
    }

    public partial class EarliestCallTimeStamp : DateTimeLong
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F65);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F65);
        }
    }

    public partial class EquipmentId : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8222);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8222);
        }
    }

    public partial class EquipmentIdType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8242);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8242);
        }
    }

    public partial class Esn : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F67);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F67);
        }
    }

    public partial class ExchangeRate : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F68);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F68);
        }
    }

    public partial class ExchangeRateCode : Code
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F69);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F69);
        }
    }

    public partial class FileAvailableTimeStamp : DateTimeLong
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F6B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F6B);
        }
    }

    public partial class FileCreationTimeStamp : DateTimeLong
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F6C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F6C);
        }
    }

    public partial class FileSequenceNumber : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F6D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F6D);
        }
    }

    public partial class FileTypeIndicator : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F6E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F6E);
        }
    }

    public partial class FixedDiscountValue : DiscountValue
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F831B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F831B);
        }
    }

    public partial class Fnur : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F6F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F6F);
        }
    }

    public partial class GeographicalLocation : Asn1SequenceObject
    {

        public ServingNetwork servingNetwork
        {
            get { return m_children[ClassDef.m_children["servingNetwork"].m_index] as ServingNetwork; }
        }
        public ServingNetwork Create_servingNetwork()
        {
            return CreateChild("servingNetwork") as ServingNetwork;
        }

        public ServingBid servingBid
        {
            get { return m_children[ClassDef.m_children["servingBid"].m_index] as ServingBid; }
        }
        public ServingBid Create_servingBid()
        {
            return CreateChild("servingBid") as ServingBid;
        }

        public ServingLocationDescription servingLocationDescription
        {
            get { return m_children[ClassDef.m_children["servingLocationDescription"].m_index] as ServingLocationDescription; }
        }
        public ServingLocationDescription Create_servingLocationDescription()
        {
            return CreateChild("servingLocationDescription") as ServingLocationDescription;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F71);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F71);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GeographicalLocationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GeographicalLocation()
        {
            m_children = new Asn1Object[3];
        }
        public class GeographicalLocationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GeographicalLocationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("servingNetwork", 0, CreateServingNetwork, true, null);
                m_posChildren.Add(0x5F8143, ch);
                m_children.Add("servingNetwork", ch);

                ch = new OptionalNamedChild("servingBid", 1, CreateServingBid, true, null);
                m_posChildren.Add(0x5F8146, ch);
                m_children.Add("servingBid", ch);

                ch = new OptionalNamedChild("servingLocationDescription", 2, CreateServingLocationDescription, true, null);
                m_posChildren.Add(0x5F831E, ch);
                m_children.Add("servingLocationDescription", ch);

            }
            public static ServingNetwork CreateServingNetwork() { return new ServingNetwork();}
            public static ServingBid CreateServingBid() { return new ServingBid();}
            public static ServingLocationDescription CreateServingLocationDescription() { return new ServingLocationDescription();}
        }
    }

    public partial class GprsBasicCallInformation : Asn1SequenceObject
    {

        public GprsChargeableSubscriber gprsChargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["gprsChargeableSubscriber"].m_index] as GprsChargeableSubscriber; }
        }
        public GprsChargeableSubscriber Create_gprsChargeableSubscriber()
        {
            return CreateChild("gprsChargeableSubscriber") as GprsChargeableSubscriber;
        }

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public GprsDestination gprsDestination
        {
            get { return m_children[ClassDef.m_children["gprsDestination"].m_index] as GprsDestination; }
        }
        public GprsDestination Create_gprsDestination()
        {
            return CreateChild("gprsDestination") as GprsDestination;
        }

        public CallEventStartTimeStamp callEventStartTimeStamp
        {
            get { return m_children[ClassDef.m_children["callEventStartTimeStamp"].m_index] as CallEventStartTimeStamp; }
        }
        public CallEventStartTimeStamp Create_callEventStartTimeStamp()
        {
            return CreateChild("callEventStartTimeStamp") as CallEventStartTimeStamp;
        }

        public TotalCallEventDuration totalCallEventDuration
        {
            get { return m_children[ClassDef.m_children["totalCallEventDuration"].m_index] as TotalCallEventDuration; }
        }
        public TotalCallEventDuration Create_totalCallEventDuration()
        {
            return CreateChild("totalCallEventDuration") as TotalCallEventDuration;
        }

        public CauseForTerm causeForTerm
        {
            get { return m_children[ClassDef.m_children["causeForTerm"].m_index] as CauseForTerm; }
        }
        public CauseForTerm Create_causeForTerm()
        {
            return CreateChild("causeForTerm") as CauseForTerm;
        }

        public PartialTypeIndicator partialTypeIndicator
        {
            get { return m_children[ClassDef.m_children["partialTypeIndicator"].m_index] as PartialTypeIndicator; }
        }
        public PartialTypeIndicator Create_partialTypeIndicator()
        {
            return CreateChild("partialTypeIndicator") as PartialTypeIndicator;
        }

        public PDPContextStartTimestamp pDPContextStartTimestamp
        {
            get { return m_children[ClassDef.m_children["pDPContextStartTimestamp"].m_index] as PDPContextStartTimestamp; }
        }
        public PDPContextStartTimestamp Create_pDPContextStartTimestamp()
        {
            return CreateChild("pDPContextStartTimestamp") as PDPContextStartTimestamp;
        }

        public NetworkInitPDPContext networkInitPDPContext
        {
            get { return m_children[ClassDef.m_children["networkInitPDPContext"].m_index] as NetworkInitPDPContext; }
        }
        public NetworkInitPDPContext Create_networkInitPDPContext()
        {
            return CreateChild("networkInitPDPContext") as NetworkInitPDPContext;
        }

        public ChargingId chargingId
        {
            get { return m_children[ClassDef.m_children["chargingId"].m_index] as ChargingId; }
        }
        public ChargingId Create_chargingId()
        {
            return CreateChild("chargingId") as ChargingId;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F72);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F72);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GprsBasicCallInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GprsBasicCallInformation()
        {
            m_children = new Asn1Object[10];
        }
        public class GprsBasicCallInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GprsBasicCallInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("gprsChargeableSubscriber", 0, CreateGprsChargeableSubscriber, true, null);
                m_posChildren.Add(0x5F73, ch);
                m_children.Add("gprsChargeableSubscriber", ch);

                ch = new OptionalNamedChild("rapFileSequenceNumber", 1, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("gprsDestination", 2, CreateGprsDestination, true, null);
                m_posChildren.Add(0x5F74, ch);
                m_children.Add("gprsDestination", ch);

                ch = new OptionalNamedChild("callEventStartTimeStamp", 3, CreateCallEventStartTimeStamp, true, null);
                m_posChildren.Add(0x5F2C, ch);
                m_children.Add("callEventStartTimeStamp", ch);

                ch = new OptionalNamedChild("totalCallEventDuration", 4, CreateTotalCallEventDuration, true, null);
                m_posChildren.Add(0x5F815F, ch);
                m_children.Add("totalCallEventDuration", ch);

                ch = new OptionalNamedChild("causeForTerm", 5, CreateCauseForTerm, true, null);
                m_posChildren.Add(0x5F3A, ch);
                m_children.Add("causeForTerm", ch);

                ch = new OptionalNamedChild("partialTypeIndicator", 6, CreatePartialTypeIndicator, true, null);
                m_posChildren.Add(0x5F8126, ch);
                m_children.Add("partialTypeIndicator", ch);

                ch = new OptionalNamedChild("pDPContextStartTimestamp", 7, CreatePDPContextStartTimestamp, true, null);
                m_posChildren.Add(0x5F8204, ch);
                m_children.Add("pDPContextStartTimestamp", ch);

                ch = new OptionalNamedChild("networkInitPDPContext", 8, CreateNetworkInitPDPContext, true, null);
                m_posChildren.Add(0x5F8175, ch);
                m_children.Add("networkInitPDPContext", ch);

                ch = new OptionalNamedChild("chargingId", 9, CreateChargingId, true, null);
                m_posChildren.Add(0x5F48, ch);
                m_children.Add("chargingId", ch);

            }
            public static GprsChargeableSubscriber CreateGprsChargeableSubscriber() { return new GprsChargeableSubscriber();}
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static GprsDestination CreateGprsDestination() { return new GprsDestination();}
            public static CallEventStartTimeStamp CreateCallEventStartTimeStamp() { return new CallEventStartTimeStamp();}
            public static TotalCallEventDuration CreateTotalCallEventDuration() { return new TotalCallEventDuration();}
            public static CauseForTerm CreateCauseForTerm() { return new CauseForTerm();}
            public static PartialTypeIndicator CreatePartialTypeIndicator() { return new PartialTypeIndicator();}
            public static PDPContextStartTimestamp CreatePDPContextStartTimestamp() { return new PDPContextStartTimestamp();}
            public static NetworkInitPDPContext CreateNetworkInitPDPContext() { return new NetworkInitPDPContext();}
            public static ChargingId CreateChargingId() { return new ChargingId();}
        }
    }

    public partial class GprsChargeableSubscriber : Asn1SequenceObject
    {

        public ChargeableSubscriber chargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["chargeableSubscriber"].m_index] as ChargeableSubscriber; }
        }
        public ChargeableSubscriber Create_chargeableSubscriber()
        {
            return CreateChild("chargeableSubscriber") as ChargeableSubscriber;
        }

        public PdpAddress pdpAddress
        {
            get { return m_children[ClassDef.m_children["pdpAddress"].m_index] as PdpAddress; }
        }
        public PdpAddress Create_pdpAddress()
        {
            return CreateChild("pdpAddress") as PdpAddress;
        }

        public NetworkAccessIdentifier networkAccessIdentifier
        {
            get { return m_children[ClassDef.m_children["networkAccessIdentifier"].m_index] as NetworkAccessIdentifier; }
        }
        public NetworkAccessIdentifier Create_networkAccessIdentifier()
        {
            return CreateChild("networkAccessIdentifier") as NetworkAccessIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F73);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F73);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GprsChargeableSubscriberClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GprsChargeableSubscriber()
        {
            m_children = new Asn1Object[3];
        }
        public class GprsChargeableSubscriberClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GprsChargeableSubscriberClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargeableSubscriber", 0, CreateChargeableSubscriber, true, null);
                m_posChildren.Add(0x5F832B, ch);
                m_children.Add("chargeableSubscriber", ch);

                ch = new OptionalNamedChild("pdpAddress", 1, CreatePdpAddress, true, null);
                m_posChildren.Add(0x5F8127, ch);
                m_children.Add("pdpAddress", ch);

                ch = new OptionalNamedChild("networkAccessIdentifier", 2, CreateNetworkAccessIdentifier, true, null);
                m_posChildren.Add(0x5F8321, ch);
                m_children.Add("networkAccessIdentifier", ch);

            }
            public static ChargeableSubscriber CreateChargeableSubscriber() { return new ChargeableSubscriber();}
            public static PdpAddress CreatePdpAddress() { return new PdpAddress();}
            public static NetworkAccessIdentifier CreateNetworkAccessIdentifier() { return new NetworkAccessIdentifier();}
        }
    }

    public partial class GprsDestination : Asn1SequenceObject
    {

        public AccessPointNameNI accessPointNameNI
        {
            get { return m_children[ClassDef.m_children["accessPointNameNI"].m_index] as AccessPointNameNI; }
        }
        public AccessPointNameNI Create_accessPointNameNI()
        {
            return CreateChild("accessPointNameNI") as AccessPointNameNI;
        }

        public AccessPointNameOI accessPointNameOI
        {
            get { return m_children[ClassDef.m_children["accessPointNameOI"].m_index] as AccessPointNameOI; }
        }
        public AccessPointNameOI Create_accessPointNameOI()
        {
            return CreateChild("accessPointNameOI") as AccessPointNameOI;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F74);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F74);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GprsDestinationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GprsDestination()
        {
            m_children = new Asn1Object[2];
        }
        public class GprsDestinationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GprsDestinationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("accessPointNameNI", 0, CreateAccessPointNameNI, true, null);
                m_posChildren.Add(0x5F8205, ch);
                m_children.Add("accessPointNameNI", ch);

                ch = new OptionalNamedChild("accessPointNameOI", 1, CreateAccessPointNameOI, true, null);
                m_posChildren.Add(0x5F8206, ch);
                m_children.Add("accessPointNameOI", ch);

            }
            public static AccessPointNameNI CreateAccessPointNameNI() { return new AccessPointNameNI();}
            public static AccessPointNameOI CreateAccessPointNameOI() { return new AccessPointNameOI();}
        }
    }

    public partial class GprsLocationInformation : Asn1SequenceObject
    {

        public GprsNetworkLocation gprsNetworkLocation
        {
            get { return m_children[ClassDef.m_children["gprsNetworkLocation"].m_index] as GprsNetworkLocation; }
        }
        public GprsNetworkLocation Create_gprsNetworkLocation()
        {
            return CreateChild("gprsNetworkLocation") as GprsNetworkLocation;
        }

        public HomeLocationInformation homeLocationInformation
        {
            get { return m_children[ClassDef.m_children["homeLocationInformation"].m_index] as HomeLocationInformation; }
        }
        public HomeLocationInformation Create_homeLocationInformation()
        {
            return CreateChild("homeLocationInformation") as HomeLocationInformation;
        }

        public GeographicalLocation geographicalLocation
        {
            get { return m_children[ClassDef.m_children["geographicalLocation"].m_index] as GeographicalLocation; }
        }
        public GeographicalLocation Create_geographicalLocation()
        {
            return CreateChild("geographicalLocation") as GeographicalLocation;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F75);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F75);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GprsLocationInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GprsLocationInformation()
        {
            m_children = new Asn1Object[3];
        }
        public class GprsLocationInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GprsLocationInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("gprsNetworkLocation", 0, CreateGprsNetworkLocation, true, null);
                m_posChildren.Add(0x5F76, ch);
                m_children.Add("gprsNetworkLocation", ch);

                ch = new OptionalNamedChild("homeLocationInformation", 1, CreateHomeLocationInformation, true, null);
                m_posChildren.Add(0x5F7B, ch);
                m_children.Add("homeLocationInformation", ch);

                ch = new OptionalNamedChild("geographicalLocation", 2, CreateGeographicalLocation, true, null);
                m_posChildren.Add(0x5F71, ch);
                m_children.Add("geographicalLocation", ch);

            }
            public static GprsNetworkLocation CreateGprsNetworkLocation() { return new GprsNetworkLocation();}
            public static HomeLocationInformation CreateHomeLocationInformation() { return new HomeLocationInformation();}
            public static GeographicalLocation CreateGeographicalLocation() { return new GeographicalLocation();}
        }
    }

    public partial class GprsNetworkLocation : Asn1SequenceObject
    {

        public RecEntityCodeList recEntity
        {
            get { return m_children[ClassDef.m_children["recEntity"].m_index] as RecEntityCodeList; }
        }
        public RecEntityCodeList Create_recEntity()
        {
            return CreateChild("recEntity") as RecEntityCodeList;
        }

        public LocationArea locationArea
        {
            get { return m_children[ClassDef.m_children["locationArea"].m_index] as LocationArea; }
        }
        public LocationArea Create_locationArea()
        {
            return CreateChild("locationArea") as LocationArea;
        }

        public CellId cellId
        {
            get { return m_children[ClassDef.m_children["cellId"].m_index] as CellId; }
        }
        public CellId Create_cellId()
        {
            return CreateChild("cellId") as CellId;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F76);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F76);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GprsNetworkLocationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GprsNetworkLocation()
        {
            m_children = new Asn1Object[3];
        }
        public class GprsNetworkLocationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GprsNetworkLocationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("recEntity", 0, CreateRecEntityCodeList, true, null);
                m_posChildren.Add(0x5F8139, ch);
                m_children.Add("recEntity", ch);

                ch = new OptionalNamedChild("locationArea", 1, CreateLocationArea, true, null);
                m_posChildren.Add(0x5F8108, ch);
                m_children.Add("locationArea", ch);

                ch = new OptionalNamedChild("cellId", 2, CreateCellId, true, null);
                m_posChildren.Add(0x5F3B, ch);
                m_children.Add("cellId", ch);

            }
            public static RecEntityCodeList CreateRecEntityCodeList() { return new RecEntityCodeList();}
            public static LocationArea CreateLocationArea() { return new LocationArea();}
            public static CellId CreateCellId() { return new CellId();}
        }
    }

    public partial class GprsServiceUsed : Asn1SequenceObject
    {

        public IMSSignallingContext iMSSignallingContext
        {
            get { return m_children[ClassDef.m_children["iMSSignallingContext"].m_index] as IMSSignallingContext; }
        }
        public IMSSignallingContext Create_iMSSignallingContext()
        {
            return CreateChild("iMSSignallingContext") as IMSSignallingContext;
        }

        public DataVolumeIncoming dataVolumeIncoming
        {
            get { return m_children[ClassDef.m_children["dataVolumeIncoming"].m_index] as DataVolumeIncoming; }
        }
        public DataVolumeIncoming Create_dataVolumeIncoming()
        {
            return CreateChild("dataVolumeIncoming") as DataVolumeIncoming;
        }

        public DataVolumeOutgoing dataVolumeOutgoing
        {
            get { return m_children[ClassDef.m_children["dataVolumeOutgoing"].m_index] as DataVolumeOutgoing; }
        }
        public DataVolumeOutgoing Create_dataVolumeOutgoing()
        {
            return CreateChild("dataVolumeOutgoing") as DataVolumeOutgoing;
        }

        public ChargeInformationList chargeInformationList
        {
            get { return m_children[ClassDef.m_children["chargeInformationList"].m_index] as ChargeInformationList; }
        }
        public ChargeInformationList Create_chargeInformationList()
        {
            return CreateChild("chargeInformationList") as ChargeInformationList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F79);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F79);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GprsServiceUsedClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GprsServiceUsed()
        {
            m_children = new Asn1Object[4];
        }
        public class GprsServiceUsedClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GprsServiceUsedClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("iMSSignallingContext", 0, CreateIMSSignallingContext, true, null);
                m_posChildren.Add(0x5F8322, ch);
                m_children.Add("iMSSignallingContext", ch);

                ch = new OptionalNamedChild("dataVolumeIncoming", 1, CreateDataVolumeIncoming, true, null);
                m_posChildren.Add(0x5F817A, ch);
                m_children.Add("dataVolumeIncoming", ch);

                ch = new OptionalNamedChild("dataVolumeOutgoing", 2, CreateDataVolumeOutgoing, true, null);
                m_posChildren.Add(0x5F817B, ch);
                m_children.Add("dataVolumeOutgoing", ch);

                ch = new OptionalNamedChild("chargeInformationList", 3, CreateChargeInformationList, true, null);
                m_posChildren.Add(0x5F46, ch);
                m_children.Add("chargeInformationList", ch);

            }
            public static IMSSignallingContext CreateIMSSignallingContext() { return new IMSSignallingContext();}
            public static DataVolumeIncoming CreateDataVolumeIncoming() { return new DataVolumeIncoming();}
            public static DataVolumeOutgoing CreateDataVolumeOutgoing() { return new DataVolumeOutgoing();}
            public static ChargeInformationList CreateChargeInformationList() { return new ChargeInformationList();}
        }
    }

    public partial class GsmChargeableSubscriber : Asn1SequenceObject
    {

        public Imsi imsi
        {
            get { return m_children[ClassDef.m_children["imsi"].m_index] as Imsi; }
        }
        public Imsi Create_imsi()
        {
            return CreateChild("imsi") as Imsi;
        }

        public Msisdn msisdn
        {
            get { return m_children[ClassDef.m_children["msisdn"].m_index] as Msisdn; }
        }
        public Msisdn Create_msisdn()
        {
            return CreateChild("msisdn") as Msisdn;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F821E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F821E);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GsmChargeableSubscriberClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public GsmChargeableSubscriber()
        {
            m_children = new Asn1Object[2];
        }
        public class GsmChargeableSubscriberClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GsmChargeableSubscriberClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("imsi", 0, CreateImsi, true, null);
                m_posChildren.Add(0x5F8101, ch);
                m_children.Add("imsi", ch);

                ch = new OptionalNamedChild("msisdn", 1, CreateMsisdn, true, null);
                m_posChildren.Add(0x5F8118, ch);
                m_children.Add("msisdn", ch);

            }
            public static Imsi CreateImsi() { return new Imsi();}
            public static Msisdn CreateMsisdn() { return new Msisdn();}
        }
    }

    public partial class GuaranteedBitRate : Asn1OctetStringObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8324);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8324);
        }
    }

    public partial class HomeBid : Bid
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F7A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F7A);
        }
    }

    public partial class HomeIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8220);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8220);
        }
    }

    public partial class HomeIdType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8237);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8237);
        }
    }

    public partial class HomeLocationDescription : LocationDescription
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F831D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F831D);
        }
    }

    public partial class HomeLocationInformation : Asn1SequenceObject
    {

        public HomeBid homeBid
        {
            get { return m_children[ClassDef.m_children["homeBid"].m_index] as HomeBid; }
        }
        public HomeBid Create_homeBid()
        {
            return CreateChild("homeBid") as HomeBid;
        }

        public HomeLocationDescription homeLocationDescription
        {
            get { return m_children[ClassDef.m_children["homeLocationDescription"].m_index] as HomeLocationDescription; }
        }
        public HomeLocationDescription Create_homeLocationDescription()
        {
            return CreateChild("homeLocationDescription") as HomeLocationDescription;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F7B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F7B);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new HomeLocationInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public HomeLocationInformation()
        {
            m_children = new Asn1Object[2];
        }
        public class HomeLocationInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public HomeLocationInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("homeBid", 0, CreateHomeBid, true, null);
                m_posChildren.Add(0x5F7A, ch);
                m_children.Add("homeBid", ch);

                ch = new OptionalNamedChild("homeLocationDescription", 1, CreateHomeLocationDescription, true, null);
                m_posChildren.Add(0x5F831D, ch);
                m_children.Add("homeLocationDescription", ch);

            }
            public static HomeBid CreateHomeBid() { return new HomeBid();}
            public static HomeLocationDescription CreateHomeLocationDescription() { return new HomeLocationDescription();}
        }
    }

    public partial class HorizontalAccuracyDelivered : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8308);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8308);
        }
    }

    public partial class HorizontalAccuracyRequested : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8301);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8301);
        }
    }

    public partial class HSCSDIndicator : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8328);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8328);
        }
    }

    public partial class Imei : BCDString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8100);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8100);
        }
    }

    public partial class ImeiOrEsn : Asn1ChoiceObject
    {

        public Imei imei
        {
            get { return m_children[ClassDef.m_children["imei"].m_index] as Imei; }
        }
        public Imei Create_imei()
        {
            return CreateChild("imei") as Imei;
        }

        public Esn esn
        {
            get { return m_children[ClassDef.m_children["esn"].m_index] as Esn; }
        }
        public Esn Create_esn()
        {
            return CreateChild("esn") as Esn;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F832D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F832D);
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new ImeiOrEsnClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ImeiOrEsn()
        {
            m_children = new Asn1Object[2];
        }
        public class ImeiOrEsnClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public ImeiOrEsnClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("imei", 0, CreateImei);
                m_posChildren.Add(0x5F8100, ch);
                m_children.Add("imei", ch);
                ch = new NamedChild("esn", 1, CreateEsn);
                m_posChildren.Add(0x5F67, ch);
                m_children.Add("esn", ch);
            }
            public static Imei CreateImei() { return new Imei();}
            public static Esn CreateEsn() { return new Esn();}
        }
    }

    public partial class Imsi : BCDString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8101);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8101);
        }
    }

    public partial class IMSSignallingContext : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8322);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8322);
        }
    }

    public partial class InternetServiceProvider : Asn1SequenceObject
    {

        public IspIdType ispIdType
        {
            get { return m_children[ClassDef.m_children["ispIdType"].m_index] as IspIdType; }
        }
        public IspIdType Create_ispIdType()
        {
            return CreateChild("ispIdType") as IspIdType;
        }

        public IspIdentifier ispIdentifier
        {
            get { return m_children[ClassDef.m_children["ispIdentifier"].m_index] as IspIdentifier; }
        }
        public IspIdentifier Create_ispIdentifier()
        {
            return CreateChild("ispIdentifier") as IspIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8249);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8249);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new InternetServiceProviderClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public InternetServiceProvider()
        {
            m_children = new Asn1Object[2];
        }
        public class InternetServiceProviderClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public InternetServiceProviderClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("ispIdType", 0, CreateIspIdType, true, null);
                m_posChildren.Add(0x5F8225, ch);
                m_children.Add("ispIdType", ch);

                ch = new OptionalNamedChild("ispIdentifier", 1, CreateIspIdentifier, true, null);
                m_posChildren.Add(0x5F8226, ch);
                m_children.Add("ispIdentifier", ch);

            }
            public static IspIdType CreateIspIdType() { return new IspIdType();}
            public static IspIdentifier CreateIspIdentifier() { return new IspIdentifier();}
        }
    }

    public partial class InternetServiceProviderIdList : Asn1SequenceOfObject<InternetServiceProvider>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F824A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F824A);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8249 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<InternetServiceProvider> CreateEmptyChild { get { return delegate() { return new InternetServiceProvider (); }; } }
    }

    public partial class IspIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8226);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8226);
        }
    }

    public partial class IspIdType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8225);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8225);
        }
    }

    public partial class ISPList : Asn1SequenceOfObject<InternetServiceProvider>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F827A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F827A);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8249 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<InternetServiceProvider> CreateEmptyChild { get { return delegate() { return new InternetServiceProvider (); }; } }
    }

    public partial class NetworkIdType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F824B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F824B);
        }
    }

    public partial class NetworkIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8227);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8227);
        }
    }

    public partial class Network : Asn1SequenceObject
    {

        public NetworkIdType networkIdType
        {
            get { return m_children[ClassDef.m_children["networkIdType"].m_index] as NetworkIdType; }
        }
        public NetworkIdType Create_networkIdType()
        {
            return CreateChild("networkIdType") as NetworkIdType;
        }

        public NetworkIdentifier networkIdentifier
        {
            get { return m_children[ClassDef.m_children["networkIdentifier"].m_index] as NetworkIdentifier; }
        }
        public NetworkIdentifier Create_networkIdentifier()
        {
            return CreateChild("networkIdentifier") as NetworkIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F824C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F824C);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new NetworkClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Network()
        {
            m_children = new Asn1Object[2];
        }
        public class NetworkClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public NetworkClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("networkIdType", 0, CreateNetworkIdType, true, null);
                m_posChildren.Add(0x5F824B, ch);
                m_children.Add("networkIdType", ch);

                ch = new OptionalNamedChild("networkIdentifier", 1, CreateNetworkIdentifier, true, null);
                m_posChildren.Add(0x5F8227, ch);
                m_children.Add("networkIdentifier", ch);

            }
            public static NetworkIdType CreateNetworkIdType() { return new NetworkIdType();}
            public static NetworkIdentifier CreateNetworkIdentifier() { return new NetworkIdentifier();}
        }
    }

    public partial class NetworkList : Asn1SequenceOfObject<Network>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F824D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F824D);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F824C } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<Network> CreateEmptyChild { get { return delegate() { return new Network (); }; } }
    }

    public partial class LatestCallTimeStamp : DateTimeLong
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8105);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8105);
        }
    }

    public partial class LCSQosDelivered : Asn1SequenceObject
    {

        public LCSTransactionStatus lCSTransactionStatus
        {
            get { return m_children[ClassDef.m_children["lCSTransactionStatus"].m_index] as LCSTransactionStatus; }
        }
        public LCSTransactionStatus Create_lCSTransactionStatus()
        {
            return CreateChild("lCSTransactionStatus") as LCSTransactionStatus;
        }

        public HorizontalAccuracyDelivered horizontalAccuracyDelivered
        {
            get { return m_children[ClassDef.m_children["horizontalAccuracyDelivered"].m_index] as HorizontalAccuracyDelivered; }
        }
        public HorizontalAccuracyDelivered Create_horizontalAccuracyDelivered()
        {
            return CreateChild("horizontalAccuracyDelivered") as HorizontalAccuracyDelivered;
        }

        public VerticalAccuracyDelivered verticalAccuracyDelivered
        {
            get { return m_children[ClassDef.m_children["verticalAccuracyDelivered"].m_index] as VerticalAccuracyDelivered; }
        }
        public VerticalAccuracyDelivered Create_verticalAccuracyDelivered()
        {
            return CreateChild("verticalAccuracyDelivered") as VerticalAccuracyDelivered;
        }

        public ResponseTime responseTime
        {
            get { return m_children[ClassDef.m_children["responseTime"].m_index] as ResponseTime; }
        }
        public ResponseTime Create_responseTime()
        {
            return CreateChild("responseTime") as ResponseTime;
        }

        public PositioningMethod positioningMethod
        {
            get { return m_children[ClassDef.m_children["positioningMethod"].m_index] as PositioningMethod; }
        }
        public PositioningMethod Create_positioningMethod()
        {
            return CreateChild("positioningMethod") as PositioningMethod;
        }

        public TrackingPeriod trackingPeriod
        {
            get { return m_children[ClassDef.m_children["trackingPeriod"].m_index] as TrackingPeriod; }
        }
        public TrackingPeriod Create_trackingPeriod()
        {
            return CreateChild("trackingPeriod") as TrackingPeriod;
        }

        public TrackingFrequency trackingFrequency
        {
            get { return m_children[ClassDef.m_children["trackingFrequency"].m_index] as TrackingFrequency; }
        }
        public TrackingFrequency Create_trackingFrequency()
        {
            return CreateChild("trackingFrequency") as TrackingFrequency;
        }

        public AgeOfLocation ageOfLocation
        {
            get { return m_children[ClassDef.m_children["ageOfLocation"].m_index] as AgeOfLocation; }
        }
        public AgeOfLocation Create_ageOfLocation()
        {
            return CreateChild("ageOfLocation") as AgeOfLocation;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8306);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8306);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new LCSQosDeliveredClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public LCSQosDelivered()
        {
            m_children = new Asn1Object[8];
        }
        public class LCSQosDeliveredClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public LCSQosDeliveredClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("lCSTransactionStatus", 0, CreateLCSTransactionStatus, true, null);
                m_posChildren.Add(0x5F8307, ch);
                m_children.Add("lCSTransactionStatus", ch);

                ch = new OptionalNamedChild("horizontalAccuracyDelivered", 1, CreateHorizontalAccuracyDelivered, true, null);
                m_posChildren.Add(0x5F8308, ch);
                m_children.Add("horizontalAccuracyDelivered", ch);

                ch = new OptionalNamedChild("verticalAccuracyDelivered", 2, CreateVerticalAccuracyDelivered, true, null);
                m_posChildren.Add(0x5F8309, ch);
                m_children.Add("verticalAccuracyDelivered", ch);

                ch = new OptionalNamedChild("responseTime", 3, CreateResponseTime, true, null);
                m_posChildren.Add(0x5F830A, ch);
                m_children.Add("responseTime", ch);

                ch = new OptionalNamedChild("positioningMethod", 4, CreatePositioningMethod, true, null);
                m_posChildren.Add(0x5F830B, ch);
                m_children.Add("positioningMethod", ch);

                ch = new OptionalNamedChild("trackingPeriod", 5, CreateTrackingPeriod, true, null);
                m_posChildren.Add(0x5F8304, ch);
                m_children.Add("trackingPeriod", ch);

                ch = new OptionalNamedChild("trackingFrequency", 6, CreateTrackingFrequency, true, null);
                m_posChildren.Add(0x5F8305, ch);
                m_children.Add("trackingFrequency", ch);

                ch = new OptionalNamedChild("ageOfLocation", 7, CreateAgeOfLocation, true, null);
                m_posChildren.Add(0x5F830C, ch);
                m_children.Add("ageOfLocation", ch);

            }
            public static LCSTransactionStatus CreateLCSTransactionStatus() { return new LCSTransactionStatus();}
            public static HorizontalAccuracyDelivered CreateHorizontalAccuracyDelivered() { return new HorizontalAccuracyDelivered();}
            public static VerticalAccuracyDelivered CreateVerticalAccuracyDelivered() { return new VerticalAccuracyDelivered();}
            public static ResponseTime CreateResponseTime() { return new ResponseTime();}
            public static PositioningMethod CreatePositioningMethod() { return new PositioningMethod();}
            public static TrackingPeriod CreateTrackingPeriod() { return new TrackingPeriod();}
            public static TrackingFrequency CreateTrackingFrequency() { return new TrackingFrequency();}
            public static AgeOfLocation CreateAgeOfLocation() { return new AgeOfLocation();}
        }
    }

    public partial class LCSQosRequested : Asn1SequenceObject
    {

        public LCSRequestTimestamp lCSRequestTimestamp
        {
            get { return m_children[ClassDef.m_children["lCSRequestTimestamp"].m_index] as LCSRequestTimestamp; }
        }
        public LCSRequestTimestamp Create_lCSRequestTimestamp()
        {
            return CreateChild("lCSRequestTimestamp") as LCSRequestTimestamp;
        }

        public HorizontalAccuracyRequested horizontalAccuracyRequested
        {
            get { return m_children[ClassDef.m_children["horizontalAccuracyRequested"].m_index] as HorizontalAccuracyRequested; }
        }
        public HorizontalAccuracyRequested Create_horizontalAccuracyRequested()
        {
            return CreateChild("horizontalAccuracyRequested") as HorizontalAccuracyRequested;
        }

        public VerticalAccuracyRequested verticalAccuracyRequested
        {
            get { return m_children[ClassDef.m_children["verticalAccuracyRequested"].m_index] as VerticalAccuracyRequested; }
        }
        public VerticalAccuracyRequested Create_verticalAccuracyRequested()
        {
            return CreateChild("verticalAccuracyRequested") as VerticalAccuracyRequested;
        }

        public ResponseTimeCategory responseTimeCategory
        {
            get { return m_children[ClassDef.m_children["responseTimeCategory"].m_index] as ResponseTimeCategory; }
        }
        public ResponseTimeCategory Create_responseTimeCategory()
        {
            return CreateChild("responseTimeCategory") as ResponseTimeCategory;
        }

        public TrackingPeriod trackingPeriod
        {
            get { return m_children[ClassDef.m_children["trackingPeriod"].m_index] as TrackingPeriod; }
        }
        public TrackingPeriod Create_trackingPeriod()
        {
            return CreateChild("trackingPeriod") as TrackingPeriod;
        }

        public TrackingFrequency trackingFrequency
        {
            get { return m_children[ClassDef.m_children["trackingFrequency"].m_index] as TrackingFrequency; }
        }
        public TrackingFrequency Create_trackingFrequency()
        {
            return CreateChild("trackingFrequency") as TrackingFrequency;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F827F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F827F);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new LCSQosRequestedClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public LCSQosRequested()
        {
            m_children = new Asn1Object[6];
        }
        public class LCSQosRequestedClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public LCSQosRequestedClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("lCSRequestTimestamp", 0, CreateLCSRequestTimestamp, true, null);
                m_posChildren.Add(0x5F8300, ch);
                m_children.Add("lCSRequestTimestamp", ch);

                ch = new OptionalNamedChild("horizontalAccuracyRequested", 1, CreateHorizontalAccuracyRequested, true, null);
                m_posChildren.Add(0x5F8301, ch);
                m_children.Add("horizontalAccuracyRequested", ch);

                ch = new OptionalNamedChild("verticalAccuracyRequested", 2, CreateVerticalAccuracyRequested, true, null);
                m_posChildren.Add(0x5F8302, ch);
                m_children.Add("verticalAccuracyRequested", ch);

                ch = new OptionalNamedChild("responseTimeCategory", 3, CreateResponseTimeCategory, true, null);
                m_posChildren.Add(0x5F8303, ch);
                m_children.Add("responseTimeCategory", ch);

                ch = new OptionalNamedChild("trackingPeriod", 4, CreateTrackingPeriod, true, null);
                m_posChildren.Add(0x5F8304, ch);
                m_children.Add("trackingPeriod", ch);

                ch = new OptionalNamedChild("trackingFrequency", 5, CreateTrackingFrequency, true, null);
                m_posChildren.Add(0x5F8305, ch);
                m_children.Add("trackingFrequency", ch);

            }
            public static LCSRequestTimestamp CreateLCSRequestTimestamp() { return new LCSRequestTimestamp();}
            public static HorizontalAccuracyRequested CreateHorizontalAccuracyRequested() { return new HorizontalAccuracyRequested();}
            public static VerticalAccuracyRequested CreateVerticalAccuracyRequested() { return new VerticalAccuracyRequested();}
            public static ResponseTimeCategory CreateResponseTimeCategory() { return new ResponseTimeCategory();}
            public static TrackingPeriod CreateTrackingPeriod() { return new TrackingPeriod();}
            public static TrackingFrequency CreateTrackingFrequency() { return new TrackingFrequency();}
        }
    }

    public partial class LCSRequestTimestamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8300);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8300);
        }
    }

    public partial class LCSSPIdentification : Asn1SequenceObject
    {

        public ContentProviderIdType contentProviderIdType
        {
            get { return m_children[ClassDef.m_children["contentProviderIdType"].m_index] as ContentProviderIdType; }
        }
        public ContentProviderIdType Create_contentProviderIdType()
        {
            return CreateChild("contentProviderIdType") as ContentProviderIdType;
        }

        public ContentProviderIdentifier contentProviderIdentifier
        {
            get { return m_children[ClassDef.m_children["contentProviderIdentifier"].m_index] as ContentProviderIdentifier; }
        }
        public ContentProviderIdentifier Create_contentProviderIdentifier()
        {
            return CreateChild("contentProviderIdentifier") as ContentProviderIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8277);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8277);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new LCSSPIdentificationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public LCSSPIdentification()
        {
            m_children = new Asn1Object[2];
        }
        public class LCSSPIdentificationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public LCSSPIdentificationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("contentProviderIdType", 0, CreateContentProviderIdType, true, null);
                m_posChildren.Add(0x5F8223, ch);
                m_children.Add("contentProviderIdType", ch);

                ch = new OptionalNamedChild("contentProviderIdentifier", 1, CreateContentProviderIdentifier, true, null);
                m_posChildren.Add(0x5F8224, ch);
                m_children.Add("contentProviderIdentifier", ch);

            }
            public static ContentProviderIdType CreateContentProviderIdType() { return new ContentProviderIdType();}
            public static ContentProviderIdentifier CreateContentProviderIdentifier() { return new ContentProviderIdentifier();}
        }
    }

    public partial class LCSSPIdentificationList : Asn1SequenceOfObject<LCSSPIdentification>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8276);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8276);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8277 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<LCSSPIdentification> CreateEmptyChild { get { return delegate() { return new LCSSPIdentification (); }; } }
    }

    public partial class LCSSPInformation : Asn1SequenceObject
    {

        public LCSSPIdentificationList lCSSPIdentificationList
        {
            get { return m_children[ClassDef.m_children["lCSSPIdentificationList"].m_index] as LCSSPIdentificationList; }
        }
        public LCSSPIdentificationList Create_lCSSPIdentificationList()
        {
            return CreateChild("lCSSPIdentificationList") as LCSSPIdentificationList;
        }

        public ISPList iSPList
        {
            get { return m_children[ClassDef.m_children["iSPList"].m_index] as ISPList; }
        }
        public ISPList Create_iSPList()
        {
            return CreateChild("iSPList") as ISPList;
        }

        public NetworkList networkList
        {
            get { return m_children[ClassDef.m_children["networkList"].m_index] as NetworkList; }
        }
        public NetworkList Create_networkList()
        {
            return CreateChild("networkList") as NetworkList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8275);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8275);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new LCSSPInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public LCSSPInformation()
        {
            m_children = new Asn1Object[3];
        }
        public class LCSSPInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public LCSSPInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("lCSSPIdentificationList", 0, CreateLCSSPIdentificationList, true, null);
                m_posChildren.Add(0x5F8276, ch);
                m_children.Add("lCSSPIdentificationList", ch);

                ch = new OptionalNamedChild("iSPList", 1, CreateISPList, true, null);
                m_posChildren.Add(0x5F827A, ch);
                m_children.Add("iSPList", ch);

                ch = new OptionalNamedChild("networkList", 2, CreateNetworkList, true, null);
                m_posChildren.Add(0x5F824D, ch);
                m_children.Add("networkList", ch);

            }
            public static LCSSPIdentificationList CreateLCSSPIdentificationList() { return new LCSSPIdentificationList();}
            public static ISPList CreateISPList() { return new ISPList();}
            public static NetworkList CreateNetworkList() { return new NetworkList();}
        }
    }

    public partial class LCSTransactionStatus : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8307);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8307);
        }
    }

    public partial class LocalCurrency : Currency
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8107);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8107);
        }
    }

    public partial class LocalTimeStamp : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x50);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x50);
        }
    }

    public partial class LocationArea : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8108);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8108);
        }
    }

    public partial class LocationDescription : AsciiString
    {
    }

    public partial class LocationIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8221);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8221);
        }
    }

    public partial class LocationIdType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F823B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F823B);
        }
    }

    public partial class LocationInformation : Asn1SequenceObject
    {

        public NetworkLocation networkLocation
        {
            get { return m_children[ClassDef.m_children["networkLocation"].m_index] as NetworkLocation; }
        }
        public NetworkLocation Create_networkLocation()
        {
            return CreateChild("networkLocation") as NetworkLocation;
        }

        public HomeLocationInformation homeLocationInformation
        {
            get { return m_children[ClassDef.m_children["homeLocationInformation"].m_index] as HomeLocationInformation; }
        }
        public HomeLocationInformation Create_homeLocationInformation()
        {
            return CreateChild("homeLocationInformation") as HomeLocationInformation;
        }

        public GeographicalLocation geographicalLocation
        {
            get { return m_children[ClassDef.m_children["geographicalLocation"].m_index] as GeographicalLocation; }
        }
        public GeographicalLocation Create_geographicalLocation()
        {
            return CreateChild("geographicalLocation") as GeographicalLocation;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F810A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F810A);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new LocationInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public LocationInformation()
        {
            m_children = new Asn1Object[3];
        }
        public class LocationInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public LocationInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("networkLocation", 0, CreateNetworkLocation, true, null);
                m_posChildren.Add(0x5F811C, ch);
                m_children.Add("networkLocation", ch);

                ch = new OptionalNamedChild("homeLocationInformation", 1, CreateHomeLocationInformation, true, null);
                m_posChildren.Add(0x5F7B, ch);
                m_children.Add("homeLocationInformation", ch);

                ch = new OptionalNamedChild("geographicalLocation", 2, CreateGeographicalLocation, true, null);
                m_posChildren.Add(0x5F71, ch);
                m_children.Add("geographicalLocation", ch);

            }
            public static NetworkLocation CreateNetworkLocation() { return new NetworkLocation();}
            public static HomeLocationInformation CreateHomeLocationInformation() { return new HomeLocationInformation();}
            public static GeographicalLocation CreateGeographicalLocation() { return new GeographicalLocation();}
        }
    }

    public partial class LocationServiceUsage : Asn1SequenceObject
    {

        public LCSQosRequested lCSQosRequested
        {
            get { return m_children[ClassDef.m_children["lCSQosRequested"].m_index] as LCSQosRequested; }
        }
        public LCSQosRequested Create_lCSQosRequested()
        {
            return CreateChild("lCSQosRequested") as LCSQosRequested;
        }

        public LCSQosDelivered lCSQosDelivered
        {
            get { return m_children[ClassDef.m_children["lCSQosDelivered"].m_index] as LCSQosDelivered; }
        }
        public LCSQosDelivered Create_lCSQosDelivered()
        {
            return CreateChild("lCSQosDelivered") as LCSQosDelivered;
        }

        public ChargingTimeStamp chargingTimeStamp
        {
            get { return m_children[ClassDef.m_children["chargingTimeStamp"].m_index] as ChargingTimeStamp; }
        }
        public ChargingTimeStamp Create_chargingTimeStamp()
        {
            return CreateChild("chargingTimeStamp") as ChargingTimeStamp;
        }

        public ChargeInformationList chargeInformationList
        {
            get { return m_children[ClassDef.m_children["chargeInformationList"].m_index] as ChargeInformationList; }
        }
        public ChargeInformationList Create_chargeInformationList()
        {
            return CreateChild("chargeInformationList") as ChargeInformationList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F827E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F827E);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new LocationServiceUsageClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public LocationServiceUsage()
        {
            m_children = new Asn1Object[4];
        }
        public class LocationServiceUsageClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public LocationServiceUsageClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("lCSQosRequested", 0, CreateLCSQosRequested, true, null);
                m_posChildren.Add(0x5F827F, ch);
                m_children.Add("lCSQosRequested", ch);

                ch = new OptionalNamedChild("lCSQosDelivered", 1, CreateLCSQosDelivered, true, null);
                m_posChildren.Add(0x5F8306, ch);
                m_children.Add("lCSQosDelivered", ch);

                ch = new OptionalNamedChild("chargingTimeStamp", 2, CreateChargingTimeStamp, true, null);
                m_posChildren.Add(0x5F4A, ch);
                m_children.Add("chargingTimeStamp", ch);

                ch = new OptionalNamedChild("chargeInformationList", 3, CreateChargeInformationList, true, null);
                m_posChildren.Add(0x5F46, ch);
                m_children.Add("chargeInformationList", ch);

            }
            public static LCSQosRequested CreateLCSQosRequested() { return new LCSQosRequested();}
            public static LCSQosDelivered CreateLCSQosDelivered() { return new LCSQosDelivered();}
            public static ChargingTimeStamp CreateChargingTimeStamp() { return new ChargingTimeStamp();}
            public static ChargeInformationList CreateChargeInformationList() { return new ChargeInformationList();}
        }
    }

    public partial class MaximumBitRate : Asn1OctetStringObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8325);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8325);
        }
    }

    public partial class Mdn : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F817D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F817D);
        }
    }

    public partial class MessageDescription : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F810E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F810E);
        }
    }

    public partial class MessageDescriptionCode : Code
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F810D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F810D);
        }
    }

    public partial class MessageDescriptionInformation : Asn1SequenceObject
    {

        public MessageDescriptionCode messageDescriptionCode
        {
            get { return m_children[ClassDef.m_children["messageDescriptionCode"].m_index] as MessageDescriptionCode; }
        }
        public MessageDescriptionCode Create_messageDescriptionCode()
        {
            return CreateChild("messageDescriptionCode") as MessageDescriptionCode;
        }

        public MessageDescription messageDescription
        {
            get { return m_children[ClassDef.m_children["messageDescription"].m_index] as MessageDescription; }
        }
        public MessageDescription Create_messageDescription()
        {
            return CreateChild("messageDescription") as MessageDescription;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F810F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F810F);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new MessageDescriptionInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public MessageDescriptionInformation()
        {
            m_children = new Asn1Object[2];
        }
        public class MessageDescriptionInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public MessageDescriptionInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("messageDescriptionCode", 0, CreateMessageDescriptionCode, true, null);
                m_posChildren.Add(0x5F810D, ch);
                m_children.Add("messageDescriptionCode", ch);

                ch = new OptionalNamedChild("messageDescription", 1, CreateMessageDescription, true, null);
                m_posChildren.Add(0x5F810E, ch);
                m_children.Add("messageDescription", ch);

            }
            public static MessageDescriptionCode CreateMessageDescriptionCode() { return new MessageDescriptionCode();}
            public static MessageDescription CreateMessageDescription() { return new MessageDescription();}
        }
    }

    public partial class MessageStatus : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8110);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8110);
        }
    }

    public partial class MessageType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8111);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8111);
        }
    }

    public partial class Min : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8112);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8112);
        }
    }

    public partial class MinChargeableSubscriber : Asn1SequenceObject
    {

        public Min min
        {
            get { return m_children[ClassDef.m_children["min"].m_index] as Min; }
        }
        public Min Create_min()
        {
            return CreateChild("min") as Min;
        }

        public Mdn mdn
        {
            get { return m_children[ClassDef.m_children["mdn"].m_index] as Mdn; }
        }
        public Mdn Create_mdn()
        {
            return CreateChild("mdn") as Mdn;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F817E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F817E);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new MinChargeableSubscriberClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public MinChargeableSubscriber()
        {
            m_children = new Asn1Object[2];
        }
        public class MinChargeableSubscriberClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public MinChargeableSubscriberClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("min", 0, CreateMin, true, null);
                m_posChildren.Add(0x5F8112, ch);
                m_children.Add("min", ch);

                ch = new OptionalNamedChild("mdn", 1, CreateMdn, true, null);
                m_posChildren.Add(0x5F817D, ch);
                m_children.Add("mdn", ch);

            }
            public static Min CreateMin() { return new Min();}
            public static Mdn CreateMdn() { return new Mdn();}
        }
    }

    public partial class MoBasicCallInformation : Asn1SequenceObject
    {

        public ChargeableSubscriber chargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["chargeableSubscriber"].m_index] as ChargeableSubscriber; }
        }
        public ChargeableSubscriber Create_chargeableSubscriber()
        {
            return CreateChild("chargeableSubscriber") as ChargeableSubscriber;
        }

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public Destination destination
        {
            get { return m_children[ClassDef.m_children["destination"].m_index] as Destination; }
        }
        public Destination Create_destination()
        {
            return CreateChild("destination") as Destination;
        }

        public DestinationNetwork destinationNetwork
        {
            get { return m_children[ClassDef.m_children["destinationNetwork"].m_index] as DestinationNetwork; }
        }
        public DestinationNetwork Create_destinationNetwork()
        {
            return CreateChild("destinationNetwork") as DestinationNetwork;
        }

        public CallEventStartTimeStamp callEventStartTimeStamp
        {
            get { return m_children[ClassDef.m_children["callEventStartTimeStamp"].m_index] as CallEventStartTimeStamp; }
        }
        public CallEventStartTimeStamp Create_callEventStartTimeStamp()
        {
            return CreateChild("callEventStartTimeStamp") as CallEventStartTimeStamp;
        }

        public TotalCallEventDuration totalCallEventDuration
        {
            get { return m_children[ClassDef.m_children["totalCallEventDuration"].m_index] as TotalCallEventDuration; }
        }
        public TotalCallEventDuration Create_totalCallEventDuration()
        {
            return CreateChild("totalCallEventDuration") as TotalCallEventDuration;
        }

        public SimToolkitIndicator simToolkitIndicator
        {
            get { return m_children[ClassDef.m_children["simToolkitIndicator"].m_index] as SimToolkitIndicator; }
        }
        public SimToolkitIndicator Create_simToolkitIndicator()
        {
            return CreateChild("simToolkitIndicator") as SimToolkitIndicator;
        }

        public CauseForTerm causeForTerm
        {
            get { return m_children[ClassDef.m_children["causeForTerm"].m_index] as CauseForTerm; }
        }
        public CauseForTerm Create_causeForTerm()
        {
            return CreateChild("causeForTerm") as CauseForTerm;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8113);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8113);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new MoBasicCallInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public MoBasicCallInformation()
        {
            m_children = new Asn1Object[8];
        }
        public class MoBasicCallInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public MoBasicCallInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargeableSubscriber", 0, CreateChargeableSubscriber, true, null);
                m_posChildren.Add(0x5F832B, ch);
                m_children.Add("chargeableSubscriber", ch);

                ch = new OptionalNamedChild("rapFileSequenceNumber", 1, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("destination", 2, CreateDestination, true, null);
                m_posChildren.Add(0x5F59, ch);
                m_children.Add("destination", ch);

                ch = new OptionalNamedChild("destinationNetwork", 3, CreateDestinationNetwork, true, null);
                m_posChildren.Add(0x5F5A, ch);
                m_children.Add("destinationNetwork", ch);

                ch = new OptionalNamedChild("callEventStartTimeStamp", 4, CreateCallEventStartTimeStamp, true, null);
                m_posChildren.Add(0x5F2C, ch);
                m_children.Add("callEventStartTimeStamp", ch);

                ch = new OptionalNamedChild("totalCallEventDuration", 5, CreateTotalCallEventDuration, true, null);
                m_posChildren.Add(0x5F815F, ch);
                m_children.Add("totalCallEventDuration", ch);

                ch = new OptionalNamedChild("simToolkitIndicator", 6, CreateSimToolkitIndicator, true, null);
                m_posChildren.Add(0x5F8148, ch);
                m_children.Add("simToolkitIndicator", ch);

                ch = new OptionalNamedChild("causeForTerm", 7, CreateCauseForTerm, true, null);
                m_posChildren.Add(0x5F3A, ch);
                m_children.Add("causeForTerm", ch);

            }
            public static ChargeableSubscriber CreateChargeableSubscriber() { return new ChargeableSubscriber();}
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static Destination CreateDestination() { return new Destination();}
            public static DestinationNetwork CreateDestinationNetwork() { return new DestinationNetwork();}
            public static CallEventStartTimeStamp CreateCallEventStartTimeStamp() { return new CallEventStartTimeStamp();}
            public static TotalCallEventDuration CreateTotalCallEventDuration() { return new TotalCallEventDuration();}
            public static SimToolkitIndicator CreateSimToolkitIndicator() { return new SimToolkitIndicator();}
            public static CauseForTerm CreateCauseForTerm() { return new CauseForTerm();}
        }
    }

    public partial class Msisdn : BCDString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8118);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8118);
        }
    }

    public partial class MtBasicCallInformation : Asn1SequenceObject
    {

        public ChargeableSubscriber chargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["chargeableSubscriber"].m_index] as ChargeableSubscriber; }
        }
        public ChargeableSubscriber Create_chargeableSubscriber()
        {
            return CreateChild("chargeableSubscriber") as ChargeableSubscriber;
        }

        public RapFileSequenceNumber rapFileSequenceNumber
        {
            get { return m_children[ClassDef.m_children["rapFileSequenceNumber"].m_index] as RapFileSequenceNumber; }
        }
        public RapFileSequenceNumber Create_rapFileSequenceNumber()
        {
            return CreateChild("rapFileSequenceNumber") as RapFileSequenceNumber;
        }

        public CallOriginator callOriginator
        {
            get { return m_children[ClassDef.m_children["callOriginator"].m_index] as CallOriginator; }
        }
        public CallOriginator Create_callOriginator()
        {
            return CreateChild("callOriginator") as CallOriginator;
        }

        public OriginatingNetwork originatingNetwork
        {
            get { return m_children[ClassDef.m_children["originatingNetwork"].m_index] as OriginatingNetwork; }
        }
        public OriginatingNetwork Create_originatingNetwork()
        {
            return CreateChild("originatingNetwork") as OriginatingNetwork;
        }

        public CallEventStartTimeStamp callEventStartTimeStamp
        {
            get { return m_children[ClassDef.m_children["callEventStartTimeStamp"].m_index] as CallEventStartTimeStamp; }
        }
        public CallEventStartTimeStamp Create_callEventStartTimeStamp()
        {
            return CreateChild("callEventStartTimeStamp") as CallEventStartTimeStamp;
        }

        public TotalCallEventDuration totalCallEventDuration
        {
            get { return m_children[ClassDef.m_children["totalCallEventDuration"].m_index] as TotalCallEventDuration; }
        }
        public TotalCallEventDuration Create_totalCallEventDuration()
        {
            return CreateChild("totalCallEventDuration") as TotalCallEventDuration;
        }

        public SimToolkitIndicator simToolkitIndicator
        {
            get { return m_children[ClassDef.m_children["simToolkitIndicator"].m_index] as SimToolkitIndicator; }
        }
        public SimToolkitIndicator Create_simToolkitIndicator()
        {
            return CreateChild("simToolkitIndicator") as SimToolkitIndicator;
        }

        public CauseForTerm causeForTerm
        {
            get { return m_children[ClassDef.m_children["causeForTerm"].m_index] as CauseForTerm; }
        }
        public CauseForTerm Create_causeForTerm()
        {
            return CreateChild("causeForTerm") as CauseForTerm;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8119);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8119);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new MtBasicCallInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public MtBasicCallInformation()
        {
            m_children = new Asn1Object[8];
        }
        public class MtBasicCallInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public MtBasicCallInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargeableSubscriber", 0, CreateChargeableSubscriber, true, null);
                m_posChildren.Add(0x5F832B, ch);
                m_children.Add("chargeableSubscriber", ch);

                ch = new OptionalNamedChild("rapFileSequenceNumber", 1, CreateRapFileSequenceNumber, true, null);
                m_posChildren.Add(0x5F8135, ch);
                m_children.Add("rapFileSequenceNumber", ch);

                ch = new OptionalNamedChild("callOriginator", 2, CreateCallOriginator, true, null);
                m_posChildren.Add(0x5F29, ch);
                m_children.Add("callOriginator", ch);

                ch = new OptionalNamedChild("originatingNetwork", 3, CreateOriginatingNetwork, true, null);
                m_posChildren.Add(0x5F8124, ch);
                m_children.Add("originatingNetwork", ch);

                ch = new OptionalNamedChild("callEventStartTimeStamp", 4, CreateCallEventStartTimeStamp, true, null);
                m_posChildren.Add(0x5F2C, ch);
                m_children.Add("callEventStartTimeStamp", ch);

                ch = new OptionalNamedChild("totalCallEventDuration", 5, CreateTotalCallEventDuration, true, null);
                m_posChildren.Add(0x5F815F, ch);
                m_children.Add("totalCallEventDuration", ch);

                ch = new OptionalNamedChild("simToolkitIndicator", 6, CreateSimToolkitIndicator, true, null);
                m_posChildren.Add(0x5F8148, ch);
                m_children.Add("simToolkitIndicator", ch);

                ch = new OptionalNamedChild("causeForTerm", 7, CreateCauseForTerm, true, null);
                m_posChildren.Add(0x5F3A, ch);
                m_children.Add("causeForTerm", ch);

            }
            public static ChargeableSubscriber CreateChargeableSubscriber() { return new ChargeableSubscriber();}
            public static RapFileSequenceNumber CreateRapFileSequenceNumber() { return new RapFileSequenceNumber();}
            public static CallOriginator CreateCallOriginator() { return new CallOriginator();}
            public static OriginatingNetwork CreateOriginatingNetwork() { return new OriginatingNetwork();}
            public static CallEventStartTimeStamp CreateCallEventStartTimeStamp() { return new CallEventStartTimeStamp();}
            public static TotalCallEventDuration CreateTotalCallEventDuration() { return new TotalCallEventDuration();}
            public static SimToolkitIndicator CreateSimToolkitIndicator() { return new SimToolkitIndicator();}
            public static CauseForTerm CreateCauseForTerm() { return new CauseForTerm();}
        }
    }

    public partial class NetworkAccessIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8321);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8321);
        }
    }

    public partial class NetworkId : AsciiString
    {
    }

    public partial class NetworkInitPDPContext : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8175);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8175);
        }
    }

    public partial class NetworkLocation : Asn1SequenceObject
    {

        public RecEntityCode recEntityCode
        {
            get { return m_children[ClassDef.m_children["recEntityCode"].m_index] as RecEntityCode; }
        }
        public RecEntityCode Create_recEntityCode()
        {
            return CreateChild("recEntityCode") as RecEntityCode;
        }

        public CallReference callReference
        {
            get { return m_children[ClassDef.m_children["callReference"].m_index] as CallReference; }
        }
        public CallReference Create_callReference()
        {
            return CreateChild("callReference") as CallReference;
        }

        public LocationArea locationArea
        {
            get { return m_children[ClassDef.m_children["locationArea"].m_index] as LocationArea; }
        }
        public LocationArea Create_locationArea()
        {
            return CreateChild("locationArea") as LocationArea;
        }

        public CellId cellId
        {
            get { return m_children[ClassDef.m_children["cellId"].m_index] as CellId; }
        }
        public CellId Create_cellId()
        {
            return CreateChild("cellId") as CellId;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F811C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F811C);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new NetworkLocationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public NetworkLocation()
        {
            m_children = new Asn1Object[4];
        }
        public class NetworkLocationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public NetworkLocationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("recEntityCode", 0, CreateRecEntityCode, true, null);
                m_posChildren.Add(0x5F8138, ch);
                m_children.Add("recEntityCode", ch);

                ch = new OptionalNamedChild("callReference", 1, CreateCallReference, true, null);
                m_posChildren.Add(0x5F2D, ch);
                m_children.Add("callReference", ch);

                ch = new OptionalNamedChild("locationArea", 2, CreateLocationArea, true, null);
                m_posChildren.Add(0x5F8108, ch);
                m_children.Add("locationArea", ch);

                ch = new OptionalNamedChild("cellId", 3, CreateCellId, true, null);
                m_posChildren.Add(0x5F3B, ch);
                m_children.Add("cellId", ch);

            }
            public static RecEntityCode CreateRecEntityCode() { return new RecEntityCode();}
            public static CallReference CreateCallReference() { return new CallReference();}
            public static LocationArea CreateLocationArea() { return new LocationArea();}
            public static CellId CreateCellId() { return new CellId();}
        }
    }

    public partial class NonChargedNumber : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8312);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8312);
        }
    }

    public partial class NumberOfDecimalPlaces : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F811F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F811F);
        }
    }

    public partial class ObjectType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8219);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8219);
        }
    }

    public partial class OperatorSpecInfoList : Asn1SequenceOfObject<OperatorSpecInformation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8122);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8122);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8123 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<OperatorSpecInformation> CreateEmptyChild { get { return delegate() { return new OperatorSpecInformation (); }; } }
    }

    public partial class OrderPlacedTimeStamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F822C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F822C);
        }
    }

    public partial class OriginatingNetwork : NetworkId
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8124);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8124);
        }
    }

    public partial class PacketDataProtocolAddress : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8125);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8125);
        }
    }

    public partial class PaidIndicator : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F825A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F825A);
        }
    }

    public partial class PartialTypeIndicator : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8126);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8126);
        }
    }

    public partial class PaymentMethod : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F825B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F825B);
        }
    }

    public partial class PdpAddress : PacketDataProtocolAddress
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8127);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8127);
        }
    }

    public partial class PDPContextStartTimestamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8204);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8204);
        }
    }

    public partial class PlmnId : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8129);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8129);
        }
    }

    public partial class PositioningMethod : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F830B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F830B);
        }
    }

    public partial class PriorityCode : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F812A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F812A);
        }
    }

    public partial class RapFileSequenceNumber : FileSequenceNumber
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8135);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8135);
        }
    }

    public partial class RecEntityCode : Code
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8138);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8138);
        }
    }

    public partial class RecEntityCodeList : Asn1SequenceOfObject<RecEntityCode>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8139);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8139);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8138 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<RecEntityCode> CreateEmptyChild { get { return delegate() { return new RecEntityCode (); }; } }
    }

    public partial class RecEntityId : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8310);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8310);
        }
    }

    public partial class RecEntityInfoList : Asn1SequenceOfObject<RecEntityInformation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F813C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F813C);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8137 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<RecEntityInformation> CreateEmptyChild { get { return delegate() { return new RecEntityInformation (); }; } }
    }

    public partial class RecEntityInformation : Asn1SequenceObject
    {

        public RecEntityCode recEntityCode
        {
            get { return m_children[ClassDef.m_children["recEntityCode"].m_index] as RecEntityCode; }
        }
        public RecEntityCode Create_recEntityCode()
        {
            return CreateChild("recEntityCode") as RecEntityCode;
        }

        public RecEntityType recEntityType
        {
            get { return m_children[ClassDef.m_children["recEntityType"].m_index] as RecEntityType; }
        }
        public RecEntityType Create_recEntityType()
        {
            return CreateChild("recEntityType") as RecEntityType;
        }

        public RecEntityId recEntityId
        {
            get { return m_children[ClassDef.m_children["recEntityId"].m_index] as RecEntityId; }
        }
        public RecEntityId Create_recEntityId()
        {
            return CreateChild("recEntityId") as RecEntityId;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8137);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8137);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new RecEntityInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public RecEntityInformation()
        {
            m_children = new Asn1Object[3];
        }
        public class RecEntityInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public RecEntityInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("recEntityCode", 0, CreateRecEntityCode, true, null);
                m_posChildren.Add(0x5F8138, ch);
                m_children.Add("recEntityCode", ch);

                ch = new OptionalNamedChild("recEntityType", 1, CreateRecEntityType, true, null);
                m_posChildren.Add(0x5F813A, ch);
                m_children.Add("recEntityType", ch);

                ch = new OptionalNamedChild("recEntityId", 2, CreateRecEntityId, true, null);
                m_posChildren.Add(0x5F8310, ch);
                m_children.Add("recEntityId", ch);

            }
            public static RecEntityCode CreateRecEntityCode() { return new RecEntityCode();}
            public static RecEntityType CreateRecEntityType() { return new RecEntityType();}
            public static RecEntityId CreateRecEntityId() { return new RecEntityId();}
        }
    }

    public partial class RecEntityType : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F813A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F813A);
        }
    }

    public partial class Recipient : PlmnId
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8136);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8136);
        }
    }

    public partial class ReleaseVersionNumber : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F813D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F813D);
        }
    }

    public partial class RequestedDeliveryTimeStamp : DateTime
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F822D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F822D);
        }
    }

    public partial class ResponseTime : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F830A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F830A);
        }
    }

    public partial class ResponseTimeCategory : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8303);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8303);
        }
    }

    public partial class ScuBasicInformation : Asn1SequenceObject
    {

        public ScuChargeableSubscriber chargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["chargeableSubscriber"].m_index] as ScuChargeableSubscriber; }
        }
        public ScuChargeableSubscriber Create_chargeableSubscriber()
        {
            return CreateChild("chargeableSubscriber") as ScuChargeableSubscriber;
        }

        public ChargedPartyStatus chargedPartyStatus
        {
            get { return m_children[ClassDef.m_children["chargedPartyStatus"].m_index] as ChargedPartyStatus; }
        }
        public ChargedPartyStatus Create_chargedPartyStatus()
        {
            return CreateChild("chargedPartyStatus") as ChargedPartyStatus;
        }

        public NonChargedNumber nonChargedNumber
        {
            get { return m_children[ClassDef.m_children["nonChargedNumber"].m_index] as NonChargedNumber; }
        }
        public NonChargedNumber Create_nonChargedNumber()
        {
            return CreateChild("nonChargedNumber") as NonChargedNumber;
        }

        public ClirIndicator clirIndicator
        {
            get { return m_children[ClassDef.m_children["clirIndicator"].m_index] as ClirIndicator; }
        }
        public ClirIndicator Create_clirIndicator()
        {
            return CreateChild("clirIndicator") as ClirIndicator;
        }

        public OriginatingNetwork originatingNetwork
        {
            get { return m_children[ClassDef.m_children["originatingNetwork"].m_index] as OriginatingNetwork; }
        }
        public OriginatingNetwork Create_originatingNetwork()
        {
            return CreateChild("originatingNetwork") as OriginatingNetwork;
        }

        public DestinationNetwork destinationNetwork
        {
            get { return m_children[ClassDef.m_children["destinationNetwork"].m_index] as DestinationNetwork; }
        }
        public DestinationNetwork Create_destinationNetwork()
        {
            return CreateChild("destinationNetwork") as DestinationNetwork;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F813F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F813F);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ScuBasicInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ScuBasicInformation()
        {
            m_children = new Asn1Object[6];
        }
        public class ScuBasicInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ScuBasicInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("chargeableSubscriber", 0, CreateScuChargeableSubscriber, true, null);
                m_posChildren.Add(0x5F832E, ch);
                m_children.Add("chargeableSubscriber", ch);

                ch = new OptionalNamedChild("chargedPartyStatus", 1, CreateChargedPartyStatus, true, null);
                m_posChildren.Add(0x5F43, ch);
                m_children.Add("chargedPartyStatus", ch);

                ch = new OptionalNamedChild("nonChargedNumber", 2, CreateNonChargedNumber, true, null);
                m_posChildren.Add(0x5F8312, ch);
                m_children.Add("nonChargedNumber", ch);

                ch = new OptionalNamedChild("clirIndicator", 3, CreateClirIndicator, true, null);
                m_posChildren.Add(0x5F4B, ch);
                m_children.Add("clirIndicator", ch);

                ch = new OptionalNamedChild("originatingNetwork", 4, CreateOriginatingNetwork, true, null);
                m_posChildren.Add(0x5F8124, ch);
                m_children.Add("originatingNetwork", ch);

                ch = new OptionalNamedChild("destinationNetwork", 5, CreateDestinationNetwork, true, null);
                m_posChildren.Add(0x5F5A, ch);
                m_children.Add("destinationNetwork", ch);

            }
            public static ScuChargeableSubscriber CreateScuChargeableSubscriber() { return new ScuChargeableSubscriber();}
            public static ChargedPartyStatus CreateChargedPartyStatus() { return new ChargedPartyStatus();}
            public static NonChargedNumber CreateNonChargedNumber() { return new NonChargedNumber();}
            public static ClirIndicator CreateClirIndicator() { return new ClirIndicator();}
            public static OriginatingNetwork CreateOriginatingNetwork() { return new OriginatingNetwork();}
            public static DestinationNetwork CreateDestinationNetwork() { return new DestinationNetwork();}
        }
    }

    public partial class ScuChargeType : Asn1SequenceObject
    {

        public MessageStatus messageStatus
        {
            get { return m_children[ClassDef.m_children["messageStatus"].m_index] as MessageStatus; }
        }
        public MessageStatus Create_messageStatus()
        {
            return CreateChild("messageStatus") as MessageStatus;
        }

        public PriorityCode priorityCode
        {
            get { return m_children[ClassDef.m_children["priorityCode"].m_index] as PriorityCode; }
        }
        public PriorityCode Create_priorityCode()
        {
            return CreateChild("priorityCode") as PriorityCode;
        }

        public DistanceChargeBandCode distanceChargeBandCode
        {
            get { return m_children[ClassDef.m_children["distanceChargeBandCode"].m_index] as DistanceChargeBandCode; }
        }
        public DistanceChargeBandCode Create_distanceChargeBandCode()
        {
            return CreateChild("distanceChargeBandCode") as DistanceChargeBandCode;
        }

        public MessageType messageType
        {
            get { return m_children[ClassDef.m_children["messageType"].m_index] as MessageType; }
        }
        public MessageType Create_messageType()
        {
            return CreateChild("messageType") as MessageType;
        }

        public MessageDescriptionCode messageDescriptionCode
        {
            get { return m_children[ClassDef.m_children["messageDescriptionCode"].m_index] as MessageDescriptionCode; }
        }
        public MessageDescriptionCode Create_messageDescriptionCode()
        {
            return CreateChild("messageDescriptionCode") as MessageDescriptionCode;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8140);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8140);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ScuChargeTypeClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ScuChargeType()
        {
            m_children = new Asn1Object[5];
        }
        public class ScuChargeTypeClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ScuChargeTypeClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("messageStatus", 0, CreateMessageStatus, true, null);
                m_posChildren.Add(0x5F8110, ch);
                m_children.Add("messageStatus", ch);

                ch = new OptionalNamedChild("priorityCode", 1, CreatePriorityCode, true, null);
                m_posChildren.Add(0x5F812A, ch);
                m_children.Add("priorityCode", ch);

                ch = new OptionalNamedChild("distanceChargeBandCode", 2, CreateDistanceChargeBandCode, true, null);
                m_posChildren.Add(0x5F62, ch);
                m_children.Add("distanceChargeBandCode", ch);

                ch = new OptionalNamedChild("messageType", 3, CreateMessageType, true, null);
                m_posChildren.Add(0x5F8111, ch);
                m_children.Add("messageType", ch);

                ch = new OptionalNamedChild("messageDescriptionCode", 4, CreateMessageDescriptionCode, true, null);
                m_posChildren.Add(0x5F810D, ch);
                m_children.Add("messageDescriptionCode", ch);

            }
            public static MessageStatus CreateMessageStatus() { return new MessageStatus();}
            public static PriorityCode CreatePriorityCode() { return new PriorityCode();}
            public static DistanceChargeBandCode CreateDistanceChargeBandCode() { return new DistanceChargeBandCode();}
            public static MessageType CreateMessageType() { return new MessageType();}
            public static MessageDescriptionCode CreateMessageDescriptionCode() { return new MessageDescriptionCode();}
        }
    }

    public partial class ScuTimeStamps : Asn1SequenceObject
    {

        public DepositTimeStamp depositTimeStamp
        {
            get { return m_children[ClassDef.m_children["depositTimeStamp"].m_index] as DepositTimeStamp; }
        }
        public DepositTimeStamp Create_depositTimeStamp()
        {
            return CreateChild("depositTimeStamp") as DepositTimeStamp;
        }

        public CompletionTimeStamp completionTimeStamp
        {
            get { return m_children[ClassDef.m_children["completionTimeStamp"].m_index] as CompletionTimeStamp; }
        }
        public CompletionTimeStamp Create_completionTimeStamp()
        {
            return CreateChild("completionTimeStamp") as CompletionTimeStamp;
        }

        public ChargingPoint chargingPoint
        {
            get { return m_children[ClassDef.m_children["chargingPoint"].m_index] as ChargingPoint; }
        }
        public ChargingPoint Create_chargingPoint()
        {
            return CreateChild("chargingPoint") as ChargingPoint;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8141);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8141);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ScuTimeStampsClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ScuTimeStamps()
        {
            m_children = new Asn1Object[3];
        }
        public class ScuTimeStampsClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ScuTimeStampsClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("depositTimeStamp", 0, CreateDepositTimeStamp, true, null);
                m_posChildren.Add(0x5F58, ch);
                m_children.Add("depositTimeStamp", ch);

                ch = new OptionalNamedChild("completionTimeStamp", 1, CreateCompletionTimeStamp, true, null);
                m_posChildren.Add(0x5F4C, ch);
                m_children.Add("completionTimeStamp", ch);

                ch = new OptionalNamedChild("chargingPoint", 2, CreateChargingPoint, true, null);
                m_posChildren.Add(0x5F49, ch);
                m_children.Add("chargingPoint", ch);

            }
            public static DepositTimeStamp CreateDepositTimeStamp() { return new DepositTimeStamp();}
            public static CompletionTimeStamp CreateCompletionTimeStamp() { return new CompletionTimeStamp();}
            public static ChargingPoint CreateChargingPoint() { return new ChargingPoint();}
        }
    }

    public partial class ScuChargeableSubscriber : Asn1ChoiceObject
    {

        public GsmChargeableSubscriber gsmChargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["gsmChargeableSubscriber"].m_index] as GsmChargeableSubscriber; }
        }
        public GsmChargeableSubscriber Create_gsmChargeableSubscriber()
        {
            return CreateChild("gsmChargeableSubscriber") as GsmChargeableSubscriber;
        }

        public MinChargeableSubscriber minChargeableSubscriber
        {
            get { return m_children[ClassDef.m_children["minChargeableSubscriber"].m_index] as MinChargeableSubscriber; }
        }
        public MinChargeableSubscriber Create_minChargeableSubscriber()
        {
            return CreateChild("minChargeableSubscriber") as MinChargeableSubscriber;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F832E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F832E);
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new ScuChargeableSubscriberClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ScuChargeableSubscriber()
        {
            m_children = new Asn1Object[2];
        }
        public class ScuChargeableSubscriberClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public ScuChargeableSubscriberClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("gsmChargeableSubscriber", 0, CreateGsmChargeableSubscriber);
                m_posChildren.Add(0x5F821E, ch);
                m_children.Add("gsmChargeableSubscriber", ch);
                ch = new NamedChild("minChargeableSubscriber", 1, CreateMinChargeableSubscriber);
                m_posChildren.Add(0x5F817E, ch);
                m_children.Add("minChargeableSubscriber", ch);
            }
            public static GsmChargeableSubscriber CreateGsmChargeableSubscriber() { return new GsmChargeableSubscriber();}
            public static MinChargeableSubscriber CreateMinChargeableSubscriber() { return new MinChargeableSubscriber();}
        }
    }

    public partial class Sender : PlmnId
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8144);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8144);
        }
    }

    public partial class ServingBid : Bid
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8146);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8146);
        }
    }

    public partial class ServingLocationDescription : LocationDescription
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F831E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F831E);
        }
    }

    public partial class ServingNetwork : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8143);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8143);
        }
    }

    public partial class ServingPartiesInformation : Asn1SequenceObject
    {

        public ContentProviderName contentProviderName
        {
            get { return m_children[ClassDef.m_children["contentProviderName"].m_index] as ContentProviderName; }
        }
        public ContentProviderName Create_contentProviderName()
        {
            return CreateChild("contentProviderName") as ContentProviderName;
        }

        public ContentProviderIdList contentProviderIdList
        {
            get { return m_children[ClassDef.m_children["contentProviderIdList"].m_index] as ContentProviderIdList; }
        }
        public ContentProviderIdList Create_contentProviderIdList()
        {
            return CreateChild("contentProviderIdList") as ContentProviderIdList;
        }

        public InternetServiceProviderIdList internetServiceProviderIdList
        {
            get { return m_children[ClassDef.m_children["internetServiceProviderIdList"].m_index] as InternetServiceProviderIdList; }
        }
        public InternetServiceProviderIdList Create_internetServiceProviderIdList()
        {
            return CreateChild("internetServiceProviderIdList") as InternetServiceProviderIdList;
        }

        public NetworkList networkList
        {
            get { return m_children[ClassDef.m_children["networkList"].m_index] as NetworkList; }
        }
        public NetworkList Create_networkList()
        {
            return CreateChild("networkList") as NetworkList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F824F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F824F);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ServingPartiesInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ServingPartiesInformation()
        {
            m_children = new Asn1Object[4];
        }
        public class ServingPartiesInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ServingPartiesInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("contentProviderName", 0, CreateContentProviderName, true, null);
                m_posChildren.Add(0x5F824E, ch);
                m_children.Add("contentProviderName", ch);

                ch = new OptionalNamedChild("contentProviderIdList", 1, CreateContentProviderIdList, true, null);
                m_posChildren.Add(0x5F8248, ch);
                m_children.Add("contentProviderIdList", ch);

                ch = new OptionalNamedChild("internetServiceProviderIdList", 2, CreateInternetServiceProviderIdList, true, null);
                m_posChildren.Add(0x5F824A, ch);
                m_children.Add("internetServiceProviderIdList", ch);

                ch = new OptionalNamedChild("networkList", 3, CreateNetworkList, true, null);
                m_posChildren.Add(0x5F824D, ch);
                m_children.Add("networkList", ch);

            }
            public static ContentProviderName CreateContentProviderName() { return new ContentProviderName();}
            public static ContentProviderIdList CreateContentProviderIdList() { return new ContentProviderIdList();}
            public static InternetServiceProviderIdList CreateInternetServiceProviderIdList() { return new InternetServiceProviderIdList();}
            public static NetworkList CreateNetworkList() { return new NetworkList();}
        }
    }

    public partial class SimChargeableSubscriber : Asn1SequenceObject
    {

        public Imsi imsi
        {
            get { return m_children[ClassDef.m_children["imsi"].m_index] as Imsi; }
        }
        public Imsi Create_imsi()
        {
            return CreateChild("imsi") as Imsi;
        }

        public Msisdn msisdn
        {
            get { return m_children[ClassDef.m_children["msisdn"].m_index] as Msisdn; }
        }
        public Msisdn Create_msisdn()
        {
            return CreateChild("msisdn") as Msisdn;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8147);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8147);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new SimChargeableSubscriberClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public SimChargeableSubscriber()
        {
            m_children = new Asn1Object[2];
        }
        public class SimChargeableSubscriberClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public SimChargeableSubscriberClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("imsi", 0, CreateImsi, true, null);
                m_posChildren.Add(0x5F8101, ch);
                m_children.Add("imsi", ch);

                ch = new OptionalNamedChild("msisdn", 1, CreateMsisdn, true, null);
                m_posChildren.Add(0x5F8118, ch);
                m_children.Add("msisdn", ch);

            }
            public static Imsi CreateImsi() { return new Imsi();}
            public static Msisdn CreateMsisdn() { return new Msisdn();}
        }
    }

    public partial class SimToolkitIndicator : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8148);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8148);
        }
    }

    public partial class SMSDestinationNumber : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8323);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8323);
        }
    }

    public partial class SMSOriginator : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8329);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8329);
        }
    }

    public partial class SpecificationVersionNumber : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8149);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8149);
        }
    }

    public partial class SsParameters : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F814C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F814C);
        }
    }

    public partial class SupplServiceActionCode : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8150);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8150);
        }
    }

    public partial class SupplServiceCode : HexString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8151);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8151);
        }
    }

    public partial class SupplServiceUsed : Asn1SequenceObject
    {

        public SupplServiceCode supplServiceCode
        {
            get { return m_children[ClassDef.m_children["supplServiceCode"].m_index] as SupplServiceCode; }
        }
        public SupplServiceCode Create_supplServiceCode()
        {
            return CreateChild("supplServiceCode") as SupplServiceCode;
        }

        public SupplServiceActionCode supplServiceActionCode
        {
            get { return m_children[ClassDef.m_children["supplServiceActionCode"].m_index] as SupplServiceActionCode; }
        }
        public SupplServiceActionCode Create_supplServiceActionCode()
        {
            return CreateChild("supplServiceActionCode") as SupplServiceActionCode;
        }

        public SsParameters ssParameters
        {
            get { return m_children[ClassDef.m_children["ssParameters"].m_index] as SsParameters; }
        }
        public SsParameters Create_ssParameters()
        {
            return CreateChild("ssParameters") as SsParameters;
        }

        public ChargingTimeStamp chargingTimeStamp
        {
            get { return m_children[ClassDef.m_children["chargingTimeStamp"].m_index] as ChargingTimeStamp; }
        }
        public ChargingTimeStamp Create_chargingTimeStamp()
        {
            return CreateChild("chargingTimeStamp") as ChargingTimeStamp;
        }

        public ChargeInformation chargeInformation
        {
            get { return m_children[ClassDef.m_children["chargeInformation"].m_index] as ChargeInformation; }
        }
        public ChargeInformation Create_chargeInformation()
        {
            return CreateChild("chargeInformation") as ChargeInformation;
        }

        public BasicServiceCodeList basicServiceCodeList
        {
            get { return m_children[ClassDef.m_children["basicServiceCodeList"].m_index] as BasicServiceCodeList; }
        }
        public BasicServiceCodeList Create_basicServiceCodeList()
        {
            return CreateChild("basicServiceCodeList") as BasicServiceCodeList;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F814E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F814E);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new SupplServiceUsedClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public SupplServiceUsed()
        {
            m_children = new Asn1Object[6];
        }
        public class SupplServiceUsedClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public SupplServiceUsedClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("supplServiceCode", 0, CreateSupplServiceCode, true, null);
                m_posChildren.Add(0x5F8151, ch);
                m_children.Add("supplServiceCode", ch);

                ch = new OptionalNamedChild("supplServiceActionCode", 1, CreateSupplServiceActionCode, true, null);
                m_posChildren.Add(0x5F8150, ch);
                m_children.Add("supplServiceActionCode", ch);

                ch = new OptionalNamedChild("ssParameters", 2, CreateSsParameters, true, null);
                m_posChildren.Add(0x5F814C, ch);
                m_children.Add("ssParameters", ch);

                ch = new OptionalNamedChild("chargingTimeStamp", 3, CreateChargingTimeStamp, true, null);
                m_posChildren.Add(0x5F4A, ch);
                m_children.Add("chargingTimeStamp", ch);

                ch = new OptionalNamedChild("chargeInformation", 4, CreateChargeInformation, true, null);
                m_posChildren.Add(0x5F45, ch);
                m_children.Add("chargeInformation", ch);

                ch = new OptionalNamedChild("basicServiceCodeList", 5, CreateBasicServiceCodeList, true, null);
                m_posChildren.Add(0x5F25, ch);
                m_children.Add("basicServiceCodeList", ch);

            }
            public static SupplServiceCode CreateSupplServiceCode() { return new SupplServiceCode();}
            public static SupplServiceActionCode CreateSupplServiceActionCode() { return new SupplServiceActionCode();}
            public static SsParameters CreateSsParameters() { return new SsParameters();}
            public static ChargingTimeStamp CreateChargingTimeStamp() { return new ChargingTimeStamp();}
            public static ChargeInformation CreateChargeInformation() { return new ChargeInformation();}
            public static BasicServiceCodeList CreateBasicServiceCodeList() { return new BasicServiceCodeList();}
        }
    }

    public partial class TapCurrency : Currency
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8152);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8152);
        }
    }

    public partial class TapDecimalPlaces : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8174);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8174);
        }
    }

    public partial class TaxableAmount : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F830E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F830E);
        }
    }

    public partial class Taxation : Asn1SequenceObject
    {

        public TaxCode taxCode
        {
            get { return m_children[ClassDef.m_children["taxCode"].m_index] as TaxCode; }
        }
        public TaxCode Create_taxCode()
        {
            return CreateChild("taxCode") as TaxCode;
        }

        public TaxType taxType
        {
            get { return m_children[ClassDef.m_children["taxType"].m_index] as TaxType; }
        }
        public TaxType Create_taxType()
        {
            return CreateChild("taxType") as TaxType;
        }

        public TaxRate taxRate
        {
            get { return m_children[ClassDef.m_children["taxRate"].m_index] as TaxRate; }
        }
        public TaxRate Create_taxRate()
        {
            return CreateChild("taxRate") as TaxRate;
        }

        public ChargeType chargeType
        {
            get { return m_children[ClassDef.m_children["chargeType"].m_index] as ChargeType; }
        }
        public ChargeType Create_chargeType()
        {
            return CreateChild("chargeType") as ChargeType;
        }

        public TaxIndicator taxIndicator
        {
            get { return m_children[ClassDef.m_children["taxIndicator"].m_index] as TaxIndicator; }
        }
        public TaxIndicator Create_taxIndicator()
        {
            return CreateChild("taxIndicator") as TaxIndicator;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8158);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8158);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TaxationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Taxation()
        {
            m_children = new Asn1Object[5];
        }
        public class TaxationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TaxationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("taxCode", 0, CreateTaxCode, true, null);
                m_posChildren.Add(0x5F8154, ch);
                m_children.Add("taxCode", ch);

                ch = new OptionalNamedChild("taxType", 1, CreateTaxType, true, null);
                m_posChildren.Add(0x5F8159, ch);
                m_children.Add("taxType", ch);

                ch = new OptionalNamedChild("taxRate", 2, CreateTaxRate, true, null);
                m_posChildren.Add(0x5F8157, ch);
                m_children.Add("taxRate", ch);

                ch = new OptionalNamedChild("chargeType", 3, CreateChargeType, true, null);
                m_posChildren.Add(0x5F47, ch);
                m_children.Add("chargeType", ch);

                ch = new OptionalNamedChild("taxIndicator", 4, CreateTaxIndicator, true, null);
                m_posChildren.Add(0x5F8330, ch);
                m_children.Add("taxIndicator", ch);

            }
            public static TaxCode CreateTaxCode() { return new TaxCode();}
            public static TaxType CreateTaxType() { return new TaxType();}
            public static TaxRate CreateTaxRate() { return new TaxRate();}
            public static ChargeType CreateChargeType() { return new ChargeType();}
            public static TaxIndicator CreateTaxIndicator() { return new TaxIndicator();}
        }
    }

    public partial class TaxationList : Asn1SequenceOfObject<Taxation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8153);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8153);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8158 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<Taxation> CreateEmptyChild { get { return delegate() { return new Taxation (); }; } }
    }

    public partial class TaxCode : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8154);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8154);
        }
    }

    public partial class TaxIndicator : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8330);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8330);
        }
    }

    public partial class TaxInformation : Asn1SequenceObject
    {

        public TaxCode taxCode
        {
            get { return m_children[ClassDef.m_children["taxCode"].m_index] as TaxCode; }
        }
        public TaxCode Create_taxCode()
        {
            return CreateChild("taxCode") as TaxCode;
        }

        public TaxValue taxValue
        {
            get { return m_children[ClassDef.m_children["taxValue"].m_index] as TaxValue; }
        }
        public TaxValue Create_taxValue()
        {
            return CreateChild("taxValue") as TaxValue;
        }

        public TaxableAmount taxableAmount
        {
            get { return m_children[ClassDef.m_children["taxableAmount"].m_index] as TaxableAmount; }
        }
        public TaxableAmount Create_taxableAmount()
        {
            return CreateChild("taxableAmount") as TaxableAmount;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8155);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8155);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TaxInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TaxInformation()
        {
            m_children = new Asn1Object[3];
        }
        public class TaxInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TaxInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("taxCode", 0, CreateTaxCode, true, null);
                m_posChildren.Add(0x5F8154, ch);
                m_children.Add("taxCode", ch);

                ch = new OptionalNamedChild("taxValue", 1, CreateTaxValue, true, null);
                m_posChildren.Add(0x5F830D, ch);
                m_children.Add("taxValue", ch);

                ch = new OptionalNamedChild("taxableAmount", 2, CreateTaxableAmount, true, null);
                m_posChildren.Add(0x5F830E, ch);
                m_children.Add("taxableAmount", ch);

            }
            public static TaxCode CreateTaxCode() { return new TaxCode();}
            public static TaxValue CreateTaxValue() { return new TaxValue();}
            public static TaxableAmount CreateTaxableAmount() { return new TaxableAmount();}
        }
    }

    public partial class TaxInformationList : Asn1SequenceOfObject<TaxInformation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8156);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8156);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8155 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<TaxInformation> CreateEmptyChild { get { return delegate() { return new TaxInformation (); }; } }
    }

    public partial class TaxRate : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8157);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8157);
        }
    }

    public partial class TaxType : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8159);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8159);
        }
    }

    public partial class TaxValue : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F830D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F830D);
        }
    }

    public partial class TeleServiceCode : HexString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F815A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F815A);
        }
    }

    public partial class ThirdPartyInformation : Asn1SequenceObject
    {

        public ThirdPartyNumber thirdPartyNumber
        {
            get { return m_children[ClassDef.m_children["thirdPartyNumber"].m_index] as ThirdPartyNumber; }
        }
        public ThirdPartyNumber Create_thirdPartyNumber()
        {
            return CreateChild("thirdPartyNumber") as ThirdPartyNumber;
        }

        public ClirIndicator clirIndicator
        {
            get { return m_children[ClassDef.m_children["clirIndicator"].m_index] as ClirIndicator; }
        }
        public ClirIndicator Create_clirIndicator()
        {
            return CreateChild("clirIndicator") as ClirIndicator;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F815B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F815B);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new ThirdPartyInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ThirdPartyInformation()
        {
            m_children = new Asn1Object[2];
        }
        public class ThirdPartyInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public ThirdPartyInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("thirdPartyNumber", 0, CreateThirdPartyNumber, true, null);
                m_posChildren.Add(0x5F8313, ch);
                m_children.Add("thirdPartyNumber", ch);

                ch = new OptionalNamedChild("clirIndicator", 1, CreateClirIndicator, true, null);
                m_posChildren.Add(0x5F4B, ch);
                m_children.Add("clirIndicator", ch);

            }
            public static ThirdPartyNumber CreateThirdPartyNumber() { return new ThirdPartyNumber();}
            public static ClirIndicator CreateClirIndicator() { return new ClirIndicator();}
        }
    }

    public partial class ThirdPartyNumber : AddressStringDigits
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8313);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8313);
        }
    }

    public partial class ThreeGcamelDestination : Asn1ChoiceObject
    {

        public CamelDestinationNumber camelDestinationNumber
        {
            get { return m_children[ClassDef.m_children["camelDestinationNumber"].m_index] as CamelDestinationNumber; }
        }
        public CamelDestinationNumber Create_camelDestinationNumber()
        {
            return CreateChild("camelDestinationNumber") as CamelDestinationNumber;
        }

        public GprsDestination gprsDestination
        {
            get { return m_children[ClassDef.m_children["gprsDestination"].m_index] as GprsDestination; }
        }
        public GprsDestination Create_gprsDestination()
        {
            return CreateChild("gprsDestination") as GprsDestination;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F832F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F832F);
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new ThreeGcamelDestinationClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ThreeGcamelDestination()
        {
            m_children = new Asn1Object[2];
        }
        public class ThreeGcamelDestinationClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public ThreeGcamelDestinationClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("camelDestinationNumber", 0, CreateCamelDestinationNumber);
                m_posChildren.Add(0x5F8314, ch);
                m_children.Add("camelDestinationNumber", ch);
                ch = new NamedChild("gprsDestination", 1, CreateGprsDestination);
                m_posChildren.Add(0x5F74, ch);
                m_children.Add("gprsDestination", ch);
            }
            public static CamelDestinationNumber CreateCamelDestinationNumber() { return new CamelDestinationNumber();}
            public static GprsDestination CreateGprsDestination() { return new GprsDestination();}
        }
    }

    public partial class TotalAdvisedCharge : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8264);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8264);
        }
    }

    public partial class TotalAdvisedChargeRefund : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8265);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8265);
        }
    }

    public partial class TotalAdvisedChargeValue : Asn1SequenceObject
    {

        public AdvisedChargeCurrency advisedChargeCurrency
        {
            get { return m_children[ClassDef.m_children["advisedChargeCurrency"].m_index] as AdvisedChargeCurrency; }
        }
        public AdvisedChargeCurrency Create_advisedChargeCurrency()
        {
            return CreateChild("advisedChargeCurrency") as AdvisedChargeCurrency;
        }

        public TotalAdvisedCharge totalAdvisedCharge
        {
            get { return m_children[ClassDef.m_children["totalAdvisedCharge"].m_index] as TotalAdvisedCharge; }
        }
        public TotalAdvisedCharge Create_totalAdvisedCharge()
        {
            return CreateChild("totalAdvisedCharge") as TotalAdvisedCharge;
        }

        public TotalAdvisedChargeRefund totalAdvisedChargeRefund
        {
            get { return m_children[ClassDef.m_children["totalAdvisedChargeRefund"].m_index] as TotalAdvisedChargeRefund; }
        }
        public TotalAdvisedChargeRefund Create_totalAdvisedChargeRefund()
        {
            return CreateChild("totalAdvisedChargeRefund") as TotalAdvisedChargeRefund;
        }

        public TotalCommission totalCommission
        {
            get { return m_children[ClassDef.m_children["totalCommission"].m_index] as TotalCommission; }
        }
        public TotalCommission Create_totalCommission()
        {
            return CreateChild("totalCommission") as TotalCommission;
        }

        public TotalCommissionRefund totalCommissionRefund
        {
            get { return m_children[ClassDef.m_children["totalCommissionRefund"].m_index] as TotalCommissionRefund; }
        }
        public TotalCommissionRefund Create_totalCommissionRefund()
        {
            return CreateChild("totalCommissionRefund") as TotalCommissionRefund;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8268);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8268);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TotalAdvisedChargeValueClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TotalAdvisedChargeValue()
        {
            m_children = new Asn1Object[5];
        }
        public class TotalAdvisedChargeValueClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TotalAdvisedChargeValueClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("advisedChargeCurrency", 0, CreateAdvisedChargeCurrency, true, null);
                m_posChildren.Add(0x5F825C, ch);
                m_children.Add("advisedChargeCurrency", ch);

                ch = new OptionalNamedChild("totalAdvisedCharge", 1, CreateTotalAdvisedCharge, true, null);
                m_posChildren.Add(0x5F8264, ch);
                m_children.Add("totalAdvisedCharge", ch);

                ch = new OptionalNamedChild("totalAdvisedChargeRefund", 2, CreateTotalAdvisedChargeRefund, true, null);
                m_posChildren.Add(0x5F8265, ch);
                m_children.Add("totalAdvisedChargeRefund", ch);

                ch = new OptionalNamedChild("totalCommission", 3, CreateTotalCommission, true, null);
                m_posChildren.Add(0x5F8266, ch);
                m_children.Add("totalCommission", ch);

                ch = new OptionalNamedChild("totalCommissionRefund", 4, CreateTotalCommissionRefund, true, null);
                m_posChildren.Add(0x5F8267, ch);
                m_children.Add("totalCommissionRefund", ch);

            }
            public static AdvisedChargeCurrency CreateAdvisedChargeCurrency() { return new AdvisedChargeCurrency();}
            public static TotalAdvisedCharge CreateTotalAdvisedCharge() { return new TotalAdvisedCharge();}
            public static TotalAdvisedChargeRefund CreateTotalAdvisedChargeRefund() { return new TotalAdvisedChargeRefund();}
            public static TotalCommission CreateTotalCommission() { return new TotalCommission();}
            public static TotalCommissionRefund CreateTotalCommissionRefund() { return new TotalCommissionRefund();}
        }
    }

    public partial class TotalAdvisedChargeValueList : Asn1SequenceOfObject<TotalAdvisedChargeValue>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8269);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8269);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8268 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<TotalAdvisedChargeValue> CreateEmptyChild { get { return delegate() { return new TotalAdvisedChargeValue (); }; } }
    }

    public partial class TotalCallEventDuration : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F815F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F815F);
        }
    }

    public partial class TotalCharge : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F831F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F831F);
        }
    }

    public partial class TotalChargeRefund : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8263);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8263);
        }
    }

    public partial class TotalCommission : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8266);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8266);
        }
    }

    public partial class TotalCommissionRefund : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8267);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8267);
        }
    }

    public partial class TotalDataVolume : DataVolume
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8257);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8257);
        }
    }

    public partial class TotalDiscountRefund : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8262);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8262);
        }
    }

    public partial class TotalDiscountValue : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8161);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8161);
        }
    }

    public partial class TotalTaxRefund : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8261);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8261);
        }
    }

    public partial class TotalTaxValue : AbsoluteAmount
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8162);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8162);
        }
    }

    public partial class TotalTransactionDuration : TotalCallEventDuration
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8320);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8320);
        }
    }

    public partial class TrackedCustomerEquipment : Asn1SequenceObject
    {

        public EquipmentIdType equipmentIdType
        {
            get { return m_children[ClassDef.m_children["equipmentIdType"].m_index] as EquipmentIdType; }
        }
        public EquipmentIdType Create_equipmentIdType()
        {
            return CreateChild("equipmentIdType") as EquipmentIdType;
        }

        public EquipmentId equipmentId
        {
            get { return m_children[ClassDef.m_children["equipmentId"].m_index] as EquipmentId; }
        }
        public EquipmentId Create_equipmentId()
        {
            return CreateChild("equipmentId") as EquipmentId;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F827D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F827D);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackedCustomerEquipmentClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackedCustomerEquipment()
        {
            m_children = new Asn1Object[2];
        }
        public class TrackedCustomerEquipmentClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackedCustomerEquipmentClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("equipmentIdType", 0, CreateEquipmentIdType, true, null);
                m_posChildren.Add(0x5F8242, ch);
                m_children.Add("equipmentIdType", ch);

                ch = new OptionalNamedChild("equipmentId", 1, CreateEquipmentId, true, null);
                m_posChildren.Add(0x5F8222, ch);
                m_children.Add("equipmentId", ch);

            }
            public static EquipmentIdType CreateEquipmentIdType() { return new EquipmentIdType();}
            public static EquipmentId CreateEquipmentId() { return new EquipmentId();}
        }
    }

    public partial class TrackedCustomerHomeId : Asn1SequenceObject
    {

        public HomeIdType homeIdType
        {
            get { return m_children[ClassDef.m_children["homeIdType"].m_index] as HomeIdType; }
        }
        public HomeIdType Create_homeIdType()
        {
            return CreateChild("homeIdType") as HomeIdType;
        }

        public HomeIdentifier homeIdentifier
        {
            get { return m_children[ClassDef.m_children["homeIdentifier"].m_index] as HomeIdentifier; }
        }
        public HomeIdentifier Create_homeIdentifier()
        {
            return CreateChild("homeIdentifier") as HomeIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8279);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8279);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackedCustomerHomeIdClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackedCustomerHomeId()
        {
            m_children = new Asn1Object[2];
        }
        public class TrackedCustomerHomeIdClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackedCustomerHomeIdClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("homeIdType", 0, CreateHomeIdType, true, null);
                m_posChildren.Add(0x5F8237, ch);
                m_children.Add("homeIdType", ch);

                ch = new OptionalNamedChild("homeIdentifier", 1, CreateHomeIdentifier, true, null);
                m_posChildren.Add(0x5F8220, ch);
                m_children.Add("homeIdentifier", ch);

            }
            public static HomeIdType CreateHomeIdType() { return new HomeIdType();}
            public static HomeIdentifier CreateHomeIdentifier() { return new HomeIdentifier();}
        }
    }

    public partial class TrackedCustomerHomeIdList : Asn1SequenceOfObject<TrackedCustomerHomeId>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8278);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8278);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8279 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<TrackedCustomerHomeId> CreateEmptyChild { get { return delegate() { return new TrackedCustomerHomeId (); }; } }
    }

    public partial class TrackedCustomerIdentification : Asn1SequenceObject
    {

        public CustomerIdType customerIdType
        {
            get { return m_children[ClassDef.m_children["customerIdType"].m_index] as CustomerIdType; }
        }
        public CustomerIdType Create_customerIdType()
        {
            return CreateChild("customerIdType") as CustomerIdType;
        }

        public CustomerIdentifier customerIdentifier
        {
            get { return m_children[ClassDef.m_children["customerIdentifier"].m_index] as CustomerIdentifier; }
        }
        public CustomerIdentifier Create_customerIdentifier()
        {
            return CreateChild("customerIdentifier") as CustomerIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8274);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8274);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackedCustomerIdentificationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackedCustomerIdentification()
        {
            m_children = new Asn1Object[2];
        }
        public class TrackedCustomerIdentificationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackedCustomerIdentificationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("customerIdType", 0, CreateCustomerIdType, true, null);
                m_posChildren.Add(0x5F826B, ch);
                m_children.Add("customerIdType", ch);

                ch = new OptionalNamedChild("customerIdentifier", 1, CreateCustomerIdentifier, true, null);
                m_posChildren.Add(0x5F826C, ch);
                m_children.Add("customerIdentifier", ch);

            }
            public static CustomerIdType CreateCustomerIdType() { return new CustomerIdType();}
            public static CustomerIdentifier CreateCustomerIdentifier() { return new CustomerIdentifier();}
        }
    }

    public partial class TrackedCustomerIdList : Asn1SequenceOfObject<TrackedCustomerIdentification>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8272);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8272);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8274 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<TrackedCustomerIdentification> CreateEmptyChild { get { return delegate() { return new TrackedCustomerIdentification (); }; } }
    }

    public partial class TrackedCustomerInformation : Asn1SequenceObject
    {

        public TrackedCustomerIdList trackedCustomerIdList
        {
            get { return m_children[ClassDef.m_children["trackedCustomerIdList"].m_index] as TrackedCustomerIdList; }
        }
        public TrackedCustomerIdList Create_trackedCustomerIdList()
        {
            return CreateChild("trackedCustomerIdList") as TrackedCustomerIdList;
        }

        public TrackedCustomerHomeIdList trackedCustomerHomeIdList
        {
            get { return m_children[ClassDef.m_children["trackedCustomerHomeIdList"].m_index] as TrackedCustomerHomeIdList; }
        }
        public TrackedCustomerHomeIdList Create_trackedCustomerHomeIdList()
        {
            return CreateChild("trackedCustomerHomeIdList") as TrackedCustomerHomeIdList;
        }

        public TrackedCustomerLocList trackedCustomerLocList
        {
            get { return m_children[ClassDef.m_children["trackedCustomerLocList"].m_index] as TrackedCustomerLocList; }
        }
        public TrackedCustomerLocList Create_trackedCustomerLocList()
        {
            return CreateChild("trackedCustomerLocList") as TrackedCustomerLocList;
        }

        public TrackedCustomerEquipment trackedCustomerEquipment
        {
            get { return m_children[ClassDef.m_children["trackedCustomerEquipment"].m_index] as TrackedCustomerEquipment; }
        }
        public TrackedCustomerEquipment Create_trackedCustomerEquipment()
        {
            return CreateChild("trackedCustomerEquipment") as TrackedCustomerEquipment;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F826F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F826F);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackedCustomerInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackedCustomerInformation()
        {
            m_children = new Asn1Object[4];
        }
        public class TrackedCustomerInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackedCustomerInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("trackedCustomerIdList", 0, CreateTrackedCustomerIdList, true, null);
                m_posChildren.Add(0x5F8272, ch);
                m_children.Add("trackedCustomerIdList", ch);

                ch = new OptionalNamedChild("trackedCustomerHomeIdList", 1, CreateTrackedCustomerHomeIdList, true, null);
                m_posChildren.Add(0x5F8278, ch);
                m_children.Add("trackedCustomerHomeIdList", ch);

                ch = new OptionalNamedChild("trackedCustomerLocList", 2, CreateTrackedCustomerLocList, true, null);
                m_posChildren.Add(0x5F827B, ch);
                m_children.Add("trackedCustomerLocList", ch);

                ch = new OptionalNamedChild("trackedCustomerEquipment", 3, CreateTrackedCustomerEquipment, true, null);
                m_posChildren.Add(0x5F827D, ch);
                m_children.Add("trackedCustomerEquipment", ch);

            }
            public static TrackedCustomerIdList CreateTrackedCustomerIdList() { return new TrackedCustomerIdList();}
            public static TrackedCustomerHomeIdList CreateTrackedCustomerHomeIdList() { return new TrackedCustomerHomeIdList();}
            public static TrackedCustomerLocList CreateTrackedCustomerLocList() { return new TrackedCustomerLocList();}
            public static TrackedCustomerEquipment CreateTrackedCustomerEquipment() { return new TrackedCustomerEquipment();}
        }
    }

    public partial class TrackedCustomerLocation : Asn1SequenceObject
    {

        public LocationIdType locationIdType
        {
            get { return m_children[ClassDef.m_children["locationIdType"].m_index] as LocationIdType; }
        }
        public LocationIdType Create_locationIdType()
        {
            return CreateChild("locationIdType") as LocationIdType;
        }

        public LocationIdentifier locationIdentifier
        {
            get { return m_children[ClassDef.m_children["locationIdentifier"].m_index] as LocationIdentifier; }
        }
        public LocationIdentifier Create_locationIdentifier()
        {
            return CreateChild("locationIdentifier") as LocationIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F827C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F827C);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackedCustomerLocationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackedCustomerLocation()
        {
            m_children = new Asn1Object[2];
        }
        public class TrackedCustomerLocationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackedCustomerLocationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("locationIdType", 0, CreateLocationIdType, true, null);
                m_posChildren.Add(0x5F823B, ch);
                m_children.Add("locationIdType", ch);

                ch = new OptionalNamedChild("locationIdentifier", 1, CreateLocationIdentifier, true, null);
                m_posChildren.Add(0x5F8221, ch);
                m_children.Add("locationIdentifier", ch);

            }
            public static LocationIdType CreateLocationIdType() { return new LocationIdType();}
            public static LocationIdentifier CreateLocationIdentifier() { return new LocationIdentifier();}
        }
    }

    public partial class TrackedCustomerLocList : Asn1SequenceOfObject<TrackedCustomerLocation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F827B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F827B);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F827C } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<TrackedCustomerLocation> CreateEmptyChild { get { return delegate() { return new TrackedCustomerLocation (); }; } }
    }

    public partial class TrackingCustomerEquipment : Asn1SequenceObject
    {

        public EquipmentIdType equipmentIdType
        {
            get { return m_children[ClassDef.m_children["equipmentIdType"].m_index] as EquipmentIdType; }
        }
        public EquipmentIdType Create_equipmentIdType()
        {
            return CreateChild("equipmentIdType") as EquipmentIdType;
        }

        public EquipmentId equipmentId
        {
            get { return m_children[ClassDef.m_children["equipmentId"].m_index] as EquipmentId; }
        }
        public EquipmentId Create_equipmentId()
        {
            return CreateChild("equipmentId") as EquipmentId;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8273);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8273);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackingCustomerEquipmentClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackingCustomerEquipment()
        {
            m_children = new Asn1Object[2];
        }
        public class TrackingCustomerEquipmentClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackingCustomerEquipmentClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("equipmentIdType", 0, CreateEquipmentIdType, true, null);
                m_posChildren.Add(0x5F8242, ch);
                m_children.Add("equipmentIdType", ch);

                ch = new OptionalNamedChild("equipmentId", 1, CreateEquipmentId, true, null);
                m_posChildren.Add(0x5F8222, ch);
                m_children.Add("equipmentId", ch);

            }
            public static EquipmentIdType CreateEquipmentIdType() { return new EquipmentIdType();}
            public static EquipmentId CreateEquipmentId() { return new EquipmentId();}
        }
    }

    public partial class TrackingCustomerHomeId : Asn1SequenceObject
    {

        public HomeIdType homeIdType
        {
            get { return m_children[ClassDef.m_children["homeIdType"].m_index] as HomeIdType; }
        }
        public HomeIdType Create_homeIdType()
        {
            return CreateChild("homeIdType") as HomeIdType;
        }

        public HomeIdentifier homeIdentifier
        {
            get { return m_children[ClassDef.m_children["homeIdentifier"].m_index] as HomeIdentifier; }
        }
        public HomeIdentifier Create_homeIdentifier()
        {
            return CreateChild("homeIdentifier") as HomeIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F826E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F826E);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackingCustomerHomeIdClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackingCustomerHomeId()
        {
            m_children = new Asn1Object[2];
        }
        public class TrackingCustomerHomeIdClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackingCustomerHomeIdClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("homeIdType", 0, CreateHomeIdType, true, null);
                m_posChildren.Add(0x5F8237, ch);
                m_children.Add("homeIdType", ch);

                ch = new OptionalNamedChild("homeIdentifier", 1, CreateHomeIdentifier, true, null);
                m_posChildren.Add(0x5F8220, ch);
                m_children.Add("homeIdentifier", ch);

            }
            public static HomeIdType CreateHomeIdType() { return new HomeIdType();}
            public static HomeIdentifier CreateHomeIdentifier() { return new HomeIdentifier();}
        }
    }

    public partial class TrackingCustomerHomeIdList : Asn1SequenceOfObject<TrackingCustomerHomeId>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F826D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F826D);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F826E } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<TrackingCustomerHomeId> CreateEmptyChild { get { return delegate() { return new TrackingCustomerHomeId (); }; } }
    }

    public partial class TrackingCustomerIdentification : Asn1SequenceObject
    {

        public CustomerIdType customerIdType
        {
            get { return m_children[ClassDef.m_children["customerIdType"].m_index] as CustomerIdType; }
        }
        public CustomerIdType Create_customerIdType()
        {
            return CreateChild("customerIdType") as CustomerIdType;
        }

        public CustomerIdentifier customerIdentifier
        {
            get { return m_children[ClassDef.m_children["customerIdentifier"].m_index] as CustomerIdentifier; }
        }
        public CustomerIdentifier Create_customerIdentifier()
        {
            return CreateChild("customerIdentifier") as CustomerIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F826A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F826A);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackingCustomerIdentificationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackingCustomerIdentification()
        {
            m_children = new Asn1Object[2];
        }
        public class TrackingCustomerIdentificationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackingCustomerIdentificationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("customerIdType", 0, CreateCustomerIdType, true, null);
                m_posChildren.Add(0x5F826B, ch);
                m_children.Add("customerIdType", ch);

                ch = new OptionalNamedChild("customerIdentifier", 1, CreateCustomerIdentifier, true, null);
                m_posChildren.Add(0x5F826C, ch);
                m_children.Add("customerIdentifier", ch);

            }
            public static CustomerIdType CreateCustomerIdType() { return new CustomerIdType();}
            public static CustomerIdentifier CreateCustomerIdentifier() { return new CustomerIdentifier();}
        }
    }

    public partial class TrackingCustomerIdList : Asn1SequenceOfObject<TrackingCustomerIdentification>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F822B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F822B);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F826A } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<TrackingCustomerIdentification> CreateEmptyChild { get { return delegate() { return new TrackingCustomerIdentification (); }; } }
    }

    public partial class TrackingCustomerInformation : Asn1SequenceObject
    {

        public TrackingCustomerIdList trackingCustomerIdList
        {
            get { return m_children[ClassDef.m_children["trackingCustomerIdList"].m_index] as TrackingCustomerIdList; }
        }
        public TrackingCustomerIdList Create_trackingCustomerIdList()
        {
            return CreateChild("trackingCustomerIdList") as TrackingCustomerIdList;
        }

        public TrackingCustomerHomeIdList trackingCustomerHomeIdList
        {
            get { return m_children[ClassDef.m_children["trackingCustomerHomeIdList"].m_index] as TrackingCustomerHomeIdList; }
        }
        public TrackingCustomerHomeIdList Create_trackingCustomerHomeIdList()
        {
            return CreateChild("trackingCustomerHomeIdList") as TrackingCustomerHomeIdList;
        }

        public TrackingCustomerLocList trackingCustomerLocList
        {
            get { return m_children[ClassDef.m_children["trackingCustomerLocList"].m_index] as TrackingCustomerLocList; }
        }
        public TrackingCustomerLocList Create_trackingCustomerLocList()
        {
            return CreateChild("trackingCustomerLocList") as TrackingCustomerLocList;
        }

        public TrackingCustomerEquipment trackingCustomerEquipment
        {
            get { return m_children[ClassDef.m_children["trackingCustomerEquipment"].m_index] as TrackingCustomerEquipment; }
        }
        public TrackingCustomerEquipment Create_trackingCustomerEquipment()
        {
            return CreateChild("trackingCustomerEquipment") as TrackingCustomerEquipment;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F822A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F822A);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackingCustomerInformationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackingCustomerInformation()
        {
            m_children = new Asn1Object[4];
        }
        public class TrackingCustomerInformationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackingCustomerInformationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("trackingCustomerIdList", 0, CreateTrackingCustomerIdList, true, null);
                m_posChildren.Add(0x5F822B, ch);
                m_children.Add("trackingCustomerIdList", ch);

                ch = new OptionalNamedChild("trackingCustomerHomeIdList", 1, CreateTrackingCustomerHomeIdList, true, null);
                m_posChildren.Add(0x5F826D, ch);
                m_children.Add("trackingCustomerHomeIdList", ch);

                ch = new OptionalNamedChild("trackingCustomerLocList", 2, CreateTrackingCustomerLocList, true, null);
                m_posChildren.Add(0x5F8270, ch);
                m_children.Add("trackingCustomerLocList", ch);

                ch = new OptionalNamedChild("trackingCustomerEquipment", 3, CreateTrackingCustomerEquipment, true, null);
                m_posChildren.Add(0x5F8273, ch);
                m_children.Add("trackingCustomerEquipment", ch);

            }
            public static TrackingCustomerIdList CreateTrackingCustomerIdList() { return new TrackingCustomerIdList();}
            public static TrackingCustomerHomeIdList CreateTrackingCustomerHomeIdList() { return new TrackingCustomerHomeIdList();}
            public static TrackingCustomerLocList CreateTrackingCustomerLocList() { return new TrackingCustomerLocList();}
            public static TrackingCustomerEquipment CreateTrackingCustomerEquipment() { return new TrackingCustomerEquipment();}
        }
    }

    public partial class TrackingCustomerLocation : Asn1SequenceObject
    {

        public LocationIdType locationIdType
        {
            get { return m_children[ClassDef.m_children["locationIdType"].m_index] as LocationIdType; }
        }
        public LocationIdType Create_locationIdType()
        {
            return CreateChild("locationIdType") as LocationIdType;
        }

        public LocationIdentifier locationIdentifier
        {
            get { return m_children[ClassDef.m_children["locationIdentifier"].m_index] as LocationIdentifier; }
        }
        public LocationIdentifier Create_locationIdentifier()
        {
            return CreateChild("locationIdentifier") as LocationIdentifier;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8271);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8271);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new TrackingCustomerLocationClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public TrackingCustomerLocation()
        {
            m_children = new Asn1Object[2];
        }
        public class TrackingCustomerLocationClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public TrackingCustomerLocationClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("locationIdType", 0, CreateLocationIdType, true, null);
                m_posChildren.Add(0x5F823B, ch);
                m_children.Add("locationIdType", ch);

                ch = new OptionalNamedChild("locationIdentifier", 1, CreateLocationIdentifier, true, null);
                m_posChildren.Add(0x5F8221, ch);
                m_children.Add("locationIdentifier", ch);

            }
            public static LocationIdType CreateLocationIdType() { return new LocationIdType();}
            public static LocationIdentifier CreateLocationIdentifier() { return new LocationIdentifier();}
        }
    }

    public partial class TrackingCustomerLocList : Asn1SequenceOfObject<TrackingCustomerLocation>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8270);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8270);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8271 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<TrackingCustomerLocation> CreateEmptyChild { get { return delegate() { return new TrackingCustomerLocation (); }; } }
    }

    public partial class TrackingFrequency : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8305);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8305);
        }
    }

    public partial class TrackingPeriod : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8304);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8304);
        }
    }

    public partial class TransactionAuthCode : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8256);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8256);
        }
    }

    public partial class TransactionDescriptionSupp : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8252);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8252);
        }
    }

    public partial class TransactionDetailDescription : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8253);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8253);
        }
    }

    public partial class TransactionIdentifier : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8255);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8255);
        }
    }

    public partial class TransactionShortDescription : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8254);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8254);
        }
    }

    public partial class TransactionStatus : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F822F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F822F);
        }
    }

    public partial class TransferCutOffTimeStamp : DateTimeLong
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8163);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8163);
        }
    }

    public partial class TransparencyIndicator : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8164);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8164);
        }
    }

    public partial class UserProtocolIndicator : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8218);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8218);
        }
    }

    public partial class UtcTimeOffset : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8167);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8167);
        }
    }

    public partial class UtcTimeOffsetCode : Code
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8168);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8168);
        }
    }

    public partial class UtcTimeOffsetInfo : Asn1SequenceObject
    {

        public UtcTimeOffsetCode utcTimeOffsetCode
        {
            get { return m_children[ClassDef.m_children["utcTimeOffsetCode"].m_index] as UtcTimeOffsetCode; }
        }
        public UtcTimeOffsetCode Create_utcTimeOffsetCode()
        {
            return CreateChild("utcTimeOffsetCode") as UtcTimeOffsetCode;
        }

        public UtcTimeOffset utcTimeOffset
        {
            get { return m_children[ClassDef.m_children["utcTimeOffset"].m_index] as UtcTimeOffset; }
        }
        public UtcTimeOffset Create_utcTimeOffset()
        {
            return CreateChild("utcTimeOffset") as UtcTimeOffset;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8169);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8169);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new UtcTimeOffsetInfoClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public UtcTimeOffsetInfo()
        {
            m_children = new Asn1Object[2];
        }
        public class UtcTimeOffsetInfoClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public UtcTimeOffsetInfoClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("utcTimeOffsetCode", 0, CreateUtcTimeOffsetCode, true, null);
                m_posChildren.Add(0x5F8168, ch);
                m_children.Add("utcTimeOffsetCode", ch);

                ch = new OptionalNamedChild("utcTimeOffset", 1, CreateUtcTimeOffset, true, null);
                m_posChildren.Add(0x5F8167, ch);
                m_children.Add("utcTimeOffset", ch);

            }
            public static UtcTimeOffsetCode CreateUtcTimeOffsetCode() { return new UtcTimeOffsetCode();}
            public static UtcTimeOffset CreateUtcTimeOffset() { return new UtcTimeOffset();}
        }
    }

    public partial class UtcTimeOffsetInfoList : Asn1SequenceOfObject<UtcTimeOffsetInfo>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F816A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F816A);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[1] { 0x5F8169 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<UtcTimeOffsetInfo> CreateEmptyChild { get { return delegate() { return new UtcTimeOffsetInfo (); }; } }
    }

    public partial class VerticalAccuracyDelivered : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8309);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8309);
        }
    }

    public partial class VerticalAccuracyRequested : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F8302);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F8302);
        }
    }

    public partial class AbsoluteAmount : Asn1IntegerObject
    {
    }

    public partial class Bid : AsciiString
    {
    }

    public partial class Code : Asn1IntegerObject
    {
    }

    public partial class AsciiString : Asn1IA5StringObject
    {
    }

    public partial class Currency : Asn1IA5StringObject
    {
    }

    public partial class HexString : Asn1IA5StringObject
    {
    }

    public partial class NumberString : Asn1NumericStringObject
    {
    }

    public partial class BCDString : Asn1OctetStringObject
    {
    }

    public partial class PercentageRate : Asn1IntegerObject
    {
    }

}
