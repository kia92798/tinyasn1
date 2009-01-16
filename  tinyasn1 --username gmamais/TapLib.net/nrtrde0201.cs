using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CSharpAsn1CRT;

namespace NRTRDE_0201
{

    public partial class Nrtrde : Asn1SequenceObject
    {

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

        public SequenceNumber sequenceNumber
        {
            get { return m_children[ClassDef.m_children["sequenceNumber"].m_index] as SequenceNumber; }
        }
        public SequenceNumber Create_sequenceNumber()
        {
            return CreateChild("sequenceNumber") as SequenceNumber;
        }

        public FileAvailableTimeStamp fileAvailableTimeStamp
        {
            get { return m_children[ClassDef.m_children["fileAvailableTimeStamp"].m_index] as FileAvailableTimeStamp; }
        }
        public FileAvailableTimeStamp Create_fileAvailableTimeStamp()
        {
            return CreateChild("fileAvailableTimeStamp") as FileAvailableTimeStamp;
        }

        public UtcTimeOffset utcTimeOffset
        {
            get { return m_children[ClassDef.m_children["utcTimeOffset"].m_index] as UtcTimeOffset; }
        }
        public UtcTimeOffset Create_utcTimeOffset()
        {
            return CreateChild("utcTimeOffset") as UtcTimeOffset;
        }

        public CallEventList callEvents
        {
            get { return m_children[ClassDef.m_children["callEvents"].m_index] as CallEventList; }
        }
        public CallEventList Create_callEvents()
        {
            return CreateChild("callEvents") as CallEventList;
        }

        public CallEventsCount callEventsCount
        {
            get { return m_children[ClassDef.m_children["callEventsCount"].m_index] as CallEventsCount; }
        }
        public CallEventsCount Create_callEventsCount()
        {
            return CreateChild("callEventsCount") as CallEventsCount;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x41);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x41);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new NrtrdeClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Nrtrde()
        {
            m_children = new Asn1Object[9];
        }
        public class NrtrdeClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public NrtrdeClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("specificationVersionNumber", 0, CreateSpecificationVersionNumber, true, null);
                m_posChildren.Add(0x5F29, ch);
                m_children.Add("specificationVersionNumber", ch);

                ch = new OptionalNamedChild("releaseVersionNumber", 1, CreateReleaseVersionNumber, true, null);
                m_posChildren.Add(0x5F25, ch);
                m_children.Add("releaseVersionNumber", ch);

                ch = new OptionalNamedChild("sender", 2, CreateSender, true, null);
                m_posChildren.Add(0x5F26, ch);
                m_children.Add("sender", ch);

                ch = new OptionalNamedChild("recipient", 3, CreateRecipient, true, null);
                m_posChildren.Add(0x5F24, ch);
                m_children.Add("recipient", ch);

                ch = new OptionalNamedChild("sequenceNumber", 4, CreateSequenceNumber, true, null);
                m_posChildren.Add(0x5F27, ch);
                m_children.Add("sequenceNumber", ch);

                ch = new OptionalNamedChild("fileAvailableTimeStamp", 5, CreateFileAvailableTimeStamp, true, null);
                m_posChildren.Add(0x5F1F, ch);
                m_children.Add("fileAvailableTimeStamp", ch);

                ch = new OptionalNamedChild("utcTimeOffset", 6, CreateUtcTimeOffset, true, null);
                m_posChildren.Add(0x5F2D, ch);
                m_children.Add("utcTimeOffset", ch);

                ch = new OptionalNamedChild("callEvents", 7, CreateCallEventList, true, null);
                m_posChildren.Add(0x42, ch);
                m_children.Add("callEvents", ch);

                ch = new OptionalNamedChild("callEventsCount", 8, CreateCallEventsCount, true, null);
                m_posChildren.Add(0x54, ch);
                m_children.Add("callEventsCount", ch);

            }
            public static SpecificationVersionNumber CreateSpecificationVersionNumber() { return new SpecificationVersionNumber();}
            public static ReleaseVersionNumber CreateReleaseVersionNumber() { return new ReleaseVersionNumber();}
            public static Sender CreateSender() { return new Sender();}
            public static Recipient CreateRecipient() { return new Recipient();}
            public static SequenceNumber CreateSequenceNumber() { return new SequenceNumber();}
            public static FileAvailableTimeStamp CreateFileAvailableTimeStamp() { return new FileAvailableTimeStamp();}
            public static UtcTimeOffset CreateUtcTimeOffset() { return new UtcTimeOffset();}
            public static CallEventList CreateCallEventList() { return new CallEventList();}
            public static CallEventsCount CreateCallEventsCount() { return new CallEventsCount();}
        }
    }

    public partial class CallEventList : Asn1SequenceOfObject<CallEvent>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x42);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x42);
        }
        static List<UInt32> _childTags = new List<UInt32>( new UInt32[3] { 0x43,0x44,0x45 } );
        protected override List<UInt32> ChildTags { get { return _childTags; } }
        protected override Func<CallEvent> CreateEmptyChild { get { return delegate() { return new CallEvent (); }; } }
    }

    public partial class CallEvent : Asn1ChoiceObject
    {

        public Moc moc
        {
            get { return m_children[ClassDef.m_children["moc"].m_index] as Moc; }
        }
        public Moc Create_moc()
        {
            return CreateChild("moc") as Moc;
        }

        public Mtc mtc
        {
            get { return m_children[ClassDef.m_children["mtc"].m_index] as Mtc; }
        }
        public Mtc Create_mtc()
        {
            return CreateChild("mtc") as Mtc;
        }

        public Gprs gprs
        {
            get { return m_children[ClassDef.m_children["gprs"].m_index] as Gprs; }
        }
        public Gprs Create_gprs()
        {
            return CreateChild("gprs") as Gprs;
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new CallEventClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public CallEvent()
        {
            m_children = new Asn1Object[3];
        }
        public class CallEventClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public CallEventClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("moc", 0, CreateMoc);
                m_posChildren.Add(0x43, ch);
                m_children.Add("moc", ch);
                ch = new NamedChild("mtc", 1, CreateMtc);
                m_posChildren.Add(0x44, ch);
                m_children.Add("mtc", ch);
                ch = new NamedChild("gprs", 2, CreateGprs);
                m_posChildren.Add(0x45, ch);
                m_children.Add("gprs", ch);
            }
            public static Moc CreateMoc() { return new Moc();}
            public static Mtc CreateMtc() { return new Mtc();}
            public static Gprs CreateGprs() { return new Gprs();}
        }
    }

    public partial class Moc : Asn1SequenceObject
    {

        public Imsi imsi
        {
            get { return m_children[ClassDef.m_children["imsi"].m_index] as Imsi; }
        }
        public Imsi Create_imsi()
        {
            return CreateChild("imsi") as Imsi;
        }

        public Imei imei
        {
            get { return m_children[ClassDef.m_children["imei"].m_index] as Imei; }
        }
        public Imei Create_imei()
        {
            return CreateChild("imei") as Imei;
        }

        public CallEventStartTimeStamp callEventStartTimeStamp
        {
            get { return m_children[ClassDef.m_children["callEventStartTimeStamp"].m_index] as CallEventStartTimeStamp; }
        }
        public CallEventStartTimeStamp Create_callEventStartTimeStamp()
        {
            return CreateChild("callEventStartTimeStamp") as CallEventStartTimeStamp;
        }

        public UtcTimeOffset utcTimeOffset
        {
            get { return m_children[ClassDef.m_children["utcTimeOffset"].m_index] as UtcTimeOffset; }
        }
        public UtcTimeOffset Create_utcTimeOffset()
        {
            return CreateChild("utcTimeOffset") as UtcTimeOffset;
        }

        public CallEventDuration callEventDuration
        {
            get { return m_children[ClassDef.m_children["callEventDuration"].m_index] as CallEventDuration; }
        }
        public CallEventDuration Create_callEventDuration()
        {
            return CreateChild("callEventDuration") as CallEventDuration;
        }

        public CauseForTermination causeForTermination
        {
            get { return m_children[ClassDef.m_children["causeForTermination"].m_index] as CauseForTermination; }
        }
        public CauseForTermination Create_causeForTermination()
        {
            return CreateChild("causeForTermination") as CauseForTermination;
        }

        public ServiceCode serviceCode
        {
            get { return m_children[ClassDef.m_children["serviceCode"].m_index] as ServiceCode; }
        }
        public ServiceCode Create_serviceCode()
        {
            return CreateChild("serviceCode") as ServiceCode;
        }

        public SupplementaryServiceCode supplementaryServiceCode
        {
            get { return m_children[ClassDef.m_children["supplementaryServiceCode"].m_index] as SupplementaryServiceCode; }
        }
        public SupplementaryServiceCode Create_supplementaryServiceCode()
        {
            return CreateChild("supplementaryServiceCode") as SupplementaryServiceCode;
        }

        public DialledDigits dialledDigits
        {
            get { return m_children[ClassDef.m_children["dialledDigits"].m_index] as DialledDigits; }
        }
        public DialledDigits Create_dialledDigits()
        {
            return CreateChild("dialledDigits") as DialledDigits;
        }

        public ConnectedNumber connectedNumber
        {
            get { return m_children[ClassDef.m_children["connectedNumber"].m_index] as ConnectedNumber; }
        }
        public ConnectedNumber Create_connectedNumber()
        {
            return CreateChild("connectedNumber") as ConnectedNumber;
        }

        public ThirdPartyNumber thirdPartyNumber
        {
            get { return m_children[ClassDef.m_children["thirdPartyNumber"].m_index] as ThirdPartyNumber; }
        }
        public ThirdPartyNumber Create_thirdPartyNumber()
        {
            return CreateChild("thirdPartyNumber") as ThirdPartyNumber;
        }

        public RecEntityId recEntityId
        {
            get { return m_children[ClassDef.m_children["recEntityId"].m_index] as RecEntityId; }
        }
        public RecEntityId Create_recEntityId()
        {
            return CreateChild("recEntityId") as RecEntityId;
        }

        public CallReference callReference
        {
            get { return m_children[ClassDef.m_children["callReference"].m_index] as CallReference; }
        }
        public CallReference Create_callReference()
        {
            return CreateChild("callReference") as CallReference;
        }

        public ChargeAmount chargeAmount
        {
            get { return m_children[ClassDef.m_children["chargeAmount"].m_index] as ChargeAmount; }
        }
        public ChargeAmount Create_chargeAmount()
        {
            return CreateChild("chargeAmount") as ChargeAmount;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x43);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x43);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new MocClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Moc()
        {
            m_children = new Asn1Object[14];
        }
        public class MocClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public MocClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("imsi", 0, CreateImsi, true, null);
                m_posChildren.Add(0x5F22, ch);
                m_children.Add("imsi", ch);

                ch = new OptionalNamedChild("imei", 1, CreateImei, true, null);
                m_posChildren.Add(0x5F21, ch);
                m_children.Add("imei", ch);

                ch = new OptionalNamedChild("callEventStartTimeStamp", 2, CreateCallEventStartTimeStamp, true, null);
                m_posChildren.Add(0x55, ch);
                m_children.Add("callEventStartTimeStamp", ch);

                ch = new OptionalNamedChild("utcTimeOffset", 3, CreateUtcTimeOffset, true, null);
                m_posChildren.Add(0x5F2D, ch);
                m_children.Add("utcTimeOffset", ch);

                ch = new OptionalNamedChild("callEventDuration", 4, CreateCallEventDuration, true, null);
                m_posChildren.Add(0x53, ch);
                m_children.Add("callEventDuration", ch);

                ch = new OptionalNamedChild("causeForTermination", 5, CreateCauseForTermination, true, null);
                m_posChildren.Add(0x58, ch);
                m_children.Add("causeForTermination", ch);

                ch = new OptionalNamedChild("serviceCode", 6, CreateServiceCode, true, null);
                m_posChildren.Add(0x5F2E, ch);
                m_children.Add("serviceCode", ch);

                ch = new OptionalNamedChild("supplementaryServiceCode", 7, CreateSupplementaryServiceCode, true, null);
                m_posChildren.Add(0x5F2A, ch);
                m_children.Add("supplementaryServiceCode", ch);

                ch = new OptionalNamedChild("dialledDigits", 8, CreateDialledDigits, true, null);
                m_posChildren.Add(0x5E, ch);
                m_children.Add("dialledDigits", ch);

                ch = new OptionalNamedChild("connectedNumber", 9, CreateConnectedNumber, true, null);
                m_posChildren.Add(0x5B, ch);
                m_children.Add("connectedNumber", ch);

                ch = new OptionalNamedChild("thirdPartyNumber", 10, CreateThirdPartyNumber, true, null);
                m_posChildren.Add(0x5F2C, ch);
                m_children.Add("thirdPartyNumber", ch);

                ch = new OptionalNamedChild("recEntityId", 11, CreateRecEntityId, true, null);
                m_posChildren.Add(0x5F23, ch);
                m_children.Add("recEntityId", ch);

                ch = new OptionalNamedChild("callReference", 12, CreateCallReference, true, null);
                m_posChildren.Add(0x57, ch);
                m_children.Add("callReference", ch);

                ch = new OptionalNamedChild("chargeAmount", 13, CreateChargeAmount, true, null);
                m_posChildren.Add(0x59, ch);
                m_children.Add("chargeAmount", ch);

            }
            public static Imsi CreateImsi() { return new Imsi();}
            public static Imei CreateImei() { return new Imei();}
            public static CallEventStartTimeStamp CreateCallEventStartTimeStamp() { return new CallEventStartTimeStamp();}
            public static UtcTimeOffset CreateUtcTimeOffset() { return new UtcTimeOffset();}
            public static CallEventDuration CreateCallEventDuration() { return new CallEventDuration();}
            public static CauseForTermination CreateCauseForTermination() { return new CauseForTermination();}
            public static ServiceCode CreateServiceCode() { return new ServiceCode();}
            public static SupplementaryServiceCode CreateSupplementaryServiceCode() { return new SupplementaryServiceCode();}
            public static DialledDigits CreateDialledDigits() { return new DialledDigits();}
            public static ConnectedNumber CreateConnectedNumber() { return new ConnectedNumber();}
            public static ThirdPartyNumber CreateThirdPartyNumber() { return new ThirdPartyNumber();}
            public static RecEntityId CreateRecEntityId() { return new RecEntityId();}
            public static CallReference CreateCallReference() { return new CallReference();}
            public static ChargeAmount CreateChargeAmount() { return new ChargeAmount();}
        }
    }

    public partial class Mtc : Asn1SequenceObject
    {

        public Imsi imsi
        {
            get { return m_children[ClassDef.m_children["imsi"].m_index] as Imsi; }
        }
        public Imsi Create_imsi()
        {
            return CreateChild("imsi") as Imsi;
        }

        public Imei imei
        {
            get { return m_children[ClassDef.m_children["imei"].m_index] as Imei; }
        }
        public Imei Create_imei()
        {
            return CreateChild("imei") as Imei;
        }

        public CallEventStartTimeStamp callEventStartTimeStamp
        {
            get { return m_children[ClassDef.m_children["callEventStartTimeStamp"].m_index] as CallEventStartTimeStamp; }
        }
        public CallEventStartTimeStamp Create_callEventStartTimeStamp()
        {
            return CreateChild("callEventStartTimeStamp") as CallEventStartTimeStamp;
        }

        public UtcTimeOffset utcTimeOffset
        {
            get { return m_children[ClassDef.m_children["utcTimeOffset"].m_index] as UtcTimeOffset; }
        }
        public UtcTimeOffset Create_utcTimeOffset()
        {
            return CreateChild("utcTimeOffset") as UtcTimeOffset;
        }

        public CallEventDuration callEventDuration
        {
            get { return m_children[ClassDef.m_children["callEventDuration"].m_index] as CallEventDuration; }
        }
        public CallEventDuration Create_callEventDuration()
        {
            return CreateChild("callEventDuration") as CallEventDuration;
        }

        public CauseForTermination causeForTermination
        {
            get { return m_children[ClassDef.m_children["causeForTermination"].m_index] as CauseForTermination; }
        }
        public CauseForTermination Create_causeForTermination()
        {
            return CreateChild("causeForTermination") as CauseForTermination;
        }

        public ServiceCode serviceCode
        {
            get { return m_children[ClassDef.m_children["serviceCode"].m_index] as ServiceCode; }
        }
        public ServiceCode Create_serviceCode()
        {
            return CreateChild("serviceCode") as ServiceCode;
        }

        public CallingNumber callingNumber
        {
            get { return m_children[ClassDef.m_children["callingNumber"].m_index] as CallingNumber; }
        }
        public CallingNumber Create_callingNumber()
        {
            return CreateChild("callingNumber") as CallingNumber;
        }

        public RecEntityId recEntityId
        {
            get { return m_children[ClassDef.m_children["recEntityId"].m_index] as RecEntityId; }
        }
        public RecEntityId Create_recEntityId()
        {
            return CreateChild("recEntityId") as RecEntityId;
        }

        public CallReference callReference
        {
            get { return m_children[ClassDef.m_children["callReference"].m_index] as CallReference; }
        }
        public CallReference Create_callReference()
        {
            return CreateChild("callReference") as CallReference;
        }

        public ChargeAmount chargeAmount
        {
            get { return m_children[ClassDef.m_children["chargeAmount"].m_index] as ChargeAmount; }
        }
        public ChargeAmount Create_chargeAmount()
        {
            return CreateChild("chargeAmount") as ChargeAmount;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x44);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x44);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new MtcClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Mtc()
        {
            m_children = new Asn1Object[11];
        }
        public class MtcClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public MtcClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("imsi", 0, CreateImsi, true, null);
                m_posChildren.Add(0x5F22, ch);
                m_children.Add("imsi", ch);

                ch = new OptionalNamedChild("imei", 1, CreateImei, true, null);
                m_posChildren.Add(0x5F21, ch);
                m_children.Add("imei", ch);

                ch = new OptionalNamedChild("callEventStartTimeStamp", 2, CreateCallEventStartTimeStamp, true, null);
                m_posChildren.Add(0x55, ch);
                m_children.Add("callEventStartTimeStamp", ch);

                ch = new OptionalNamedChild("utcTimeOffset", 3, CreateUtcTimeOffset, true, null);
                m_posChildren.Add(0x5F2D, ch);
                m_children.Add("utcTimeOffset", ch);

                ch = new OptionalNamedChild("callEventDuration", 4, CreateCallEventDuration, true, null);
                m_posChildren.Add(0x53, ch);
                m_children.Add("callEventDuration", ch);

                ch = new OptionalNamedChild("causeForTermination", 5, CreateCauseForTermination, true, null);
                m_posChildren.Add(0x58, ch);
                m_children.Add("causeForTermination", ch);

                ch = new OptionalNamedChild("serviceCode", 6, CreateServiceCode, true, null);
                m_posChildren.Add(0x5F2E, ch);
                m_children.Add("serviceCode", ch);

                ch = new OptionalNamedChild("callingNumber", 7, CreateCallingNumber, true, null);
                m_posChildren.Add(0x56, ch);
                m_children.Add("callingNumber", ch);

                ch = new OptionalNamedChild("recEntityId", 8, CreateRecEntityId, true, null);
                m_posChildren.Add(0x5F23, ch);
                m_children.Add("recEntityId", ch);

                ch = new OptionalNamedChild("callReference", 9, CreateCallReference, true, null);
                m_posChildren.Add(0x57, ch);
                m_children.Add("callReference", ch);

                ch = new OptionalNamedChild("chargeAmount", 10, CreateChargeAmount, true, null);
                m_posChildren.Add(0x59, ch);
                m_children.Add("chargeAmount", ch);

            }
            public static Imsi CreateImsi() { return new Imsi();}
            public static Imei CreateImei() { return new Imei();}
            public static CallEventStartTimeStamp CreateCallEventStartTimeStamp() { return new CallEventStartTimeStamp();}
            public static UtcTimeOffset CreateUtcTimeOffset() { return new UtcTimeOffset();}
            public static CallEventDuration CreateCallEventDuration() { return new CallEventDuration();}
            public static CauseForTermination CreateCauseForTermination() { return new CauseForTermination();}
            public static ServiceCode CreateServiceCode() { return new ServiceCode();}
            public static CallingNumber CreateCallingNumber() { return new CallingNumber();}
            public static RecEntityId CreateRecEntityId() { return new RecEntityId();}
            public static CallReference CreateCallReference() { return new CallReference();}
            public static ChargeAmount CreateChargeAmount() { return new ChargeAmount();}
        }
    }

    public partial class Gprs : Asn1SequenceObject
    {

        public Imsi imsi
        {
            get { return m_children[ClassDef.m_children["imsi"].m_index] as Imsi; }
        }
        public Imsi Create_imsi()
        {
            return CreateChild("imsi") as Imsi;
        }

        public Imei imei
        {
            get { return m_children[ClassDef.m_children["imei"].m_index] as Imei; }
        }
        public Imei Create_imei()
        {
            return CreateChild("imei") as Imei;
        }

        public CallEventStartTimeStamp callEventStartTimeStamp
        {
            get { return m_children[ClassDef.m_children["callEventStartTimeStamp"].m_index] as CallEventStartTimeStamp; }
        }
        public CallEventStartTimeStamp Create_callEventStartTimeStamp()
        {
            return CreateChild("callEventStartTimeStamp") as CallEventStartTimeStamp;
        }

        public UtcTimeOffset utcTimeOffset
        {
            get { return m_children[ClassDef.m_children["utcTimeOffset"].m_index] as UtcTimeOffset; }
        }
        public UtcTimeOffset Create_utcTimeOffset()
        {
            return CreateChild("utcTimeOffset") as UtcTimeOffset;
        }

        public CallEventDuration callEventDuration
        {
            get { return m_children[ClassDef.m_children["callEventDuration"].m_index] as CallEventDuration; }
        }
        public CallEventDuration Create_callEventDuration()
        {
            return CreateChild("callEventDuration") as CallEventDuration;
        }

        public CauseForTermination causeForTermination
        {
            get { return m_children[ClassDef.m_children["causeForTermination"].m_index] as CauseForTermination; }
        }
        public CauseForTermination Create_causeForTermination()
        {
            return CreateChild("causeForTermination") as CauseForTermination;
        }

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

        public SgsnAddress sgsnAddress
        {
            get { return m_children[ClassDef.m_children["sgsnAddress"].m_index] as SgsnAddress; }
        }
        public SgsnAddress Create_sgsnAddress()
        {
            return CreateChild("sgsnAddress") as SgsnAddress;
        }

        public GgsnAddress ggsnAddress
        {
            get { return m_children[ClassDef.m_children["ggsnAddress"].m_index] as GgsnAddress; }
        }
        public GgsnAddress Create_ggsnAddress()
        {
            return CreateChild("ggsnAddress") as GgsnAddress;
        }

        public ChargingId chargingId
        {
            get { return m_children[ClassDef.m_children["chargingId"].m_index] as ChargingId; }
        }
        public ChargingId Create_chargingId()
        {
            return CreateChild("chargingId") as ChargingId;
        }

        public ChargeAmount chargeAmount
        {
            get { return m_children[ClassDef.m_children["chargeAmount"].m_index] as ChargeAmount; }
        }
        public ChargeAmount Create_chargeAmount()
        {
            return CreateChild("chargeAmount") as ChargeAmount;
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x45);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x45);
        }
        static Asn1CompositeClass<OptionalNamedChild> _clsDef = new GprsClassDefinition();
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public Gprs()
        {
            m_children = new Asn1Object[14];
        }
        public class GprsClassDefinition : Asn1CompositeClass<OptionalNamedChild>
        {
            public GprsClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("imsi", 0, CreateImsi, true, null);
                m_posChildren.Add(0x5F22, ch);
                m_children.Add("imsi", ch);

                ch = new OptionalNamedChild("imei", 1, CreateImei, true, null);
                m_posChildren.Add(0x5F21, ch);
                m_children.Add("imei", ch);

                ch = new OptionalNamedChild("callEventStartTimeStamp", 2, CreateCallEventStartTimeStamp, true, null);
                m_posChildren.Add(0x55, ch);
                m_children.Add("callEventStartTimeStamp", ch);

                ch = new OptionalNamedChild("utcTimeOffset", 3, CreateUtcTimeOffset, true, null);
                m_posChildren.Add(0x5F2D, ch);
                m_children.Add("utcTimeOffset", ch);

                ch = new OptionalNamedChild("callEventDuration", 4, CreateCallEventDuration, true, null);
                m_posChildren.Add(0x53, ch);
                m_children.Add("callEventDuration", ch);

                ch = new OptionalNamedChild("causeForTermination", 5, CreateCauseForTermination, true, null);
                m_posChildren.Add(0x58, ch);
                m_children.Add("causeForTermination", ch);

                ch = new OptionalNamedChild("accessPointNameNI", 6, CreateAccessPointNameNI, true, null);
                m_posChildren.Add(0x50, ch);
                m_children.Add("accessPointNameNI", ch);

                ch = new OptionalNamedChild("accessPointNameOI", 7, CreateAccessPointNameOI, true, null);
                m_posChildren.Add(0x51, ch);
                m_children.Add("accessPointNameOI", ch);

                ch = new OptionalNamedChild("dataVolumeIncoming", 8, CreateDataVolumeIncoming, true, null);
                m_posChildren.Add(0x5C, ch);
                m_children.Add("dataVolumeIncoming", ch);

                ch = new OptionalNamedChild("dataVolumeOutgoing", 9, CreateDataVolumeOutgoing, true, null);
                m_posChildren.Add(0x5D, ch);
                m_children.Add("dataVolumeOutgoing", ch);

                ch = new OptionalNamedChild("sgsnAddress", 10, CreateSgsnAddress, true, null);
                m_posChildren.Add(0x5F28, ch);
                m_children.Add("sgsnAddress", ch);

                ch = new OptionalNamedChild("ggsnAddress", 11, CreateGgsnAddress, true, null);
                m_posChildren.Add(0x5F20, ch);
                m_children.Add("ggsnAddress", ch);

                ch = new OptionalNamedChild("chargingId", 12, CreateChargingId, true, null);
                m_posChildren.Add(0x5A, ch);
                m_children.Add("chargingId", ch);

                ch = new OptionalNamedChild("chargeAmount", 13, CreateChargeAmount, true, null);
                m_posChildren.Add(0x59, ch);
                m_children.Add("chargeAmount", ch);

            }
            public static Imsi CreateImsi() { return new Imsi();}
            public static Imei CreateImei() { return new Imei();}
            public static CallEventStartTimeStamp CreateCallEventStartTimeStamp() { return new CallEventStartTimeStamp();}
            public static UtcTimeOffset CreateUtcTimeOffset() { return new UtcTimeOffset();}
            public static CallEventDuration CreateCallEventDuration() { return new CallEventDuration();}
            public static CauseForTermination CreateCauseForTermination() { return new CauseForTermination();}
            public static AccessPointNameNI CreateAccessPointNameNI() { return new AccessPointNameNI();}
            public static AccessPointNameOI CreateAccessPointNameOI() { return new AccessPointNameOI();}
            public static DataVolumeIncoming CreateDataVolumeIncoming() { return new DataVolumeIncoming();}
            public static DataVolumeOutgoing CreateDataVolumeOutgoing() { return new DataVolumeOutgoing();}
            public static SgsnAddress CreateSgsnAddress() { return new SgsnAddress();}
            public static GgsnAddress CreateGgsnAddress() { return new GgsnAddress();}
            public static ChargingId CreateChargingId() { return new ChargingId();}
            public static ChargeAmount CreateChargeAmount() { return new ChargeAmount();}
        }
    }

    public partial class AccessPointNameNI : AsciiString
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

    public partial class AccessPointNameOI : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x51);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x51);
        }
    }

    public partial class BearerServiceCode : HexString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x52);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x52);
        }
    }

    public partial class CallEventDuration : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x53);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x53);
        }
    }

    public partial class CallEventsCount : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x54);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x54);
        }
    }

    public partial class CallEventStartTimeStamp : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x55);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x55);
        }
    }

    public partial class CallingNumber : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x56);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x56);
        }
    }

    public partial class CallReference : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x57);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x57);
        }
    }

    public partial class CauseForTermination : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x58);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x58);
        }
    }

    public partial class ChargeAmount : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x59);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x59);
        }
    }

    public partial class ChargingId : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5A);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5A);
        }
    }

    public partial class ConnectedNumber : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5B);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5B);
        }
    }

    public partial class DataVolumeIncoming : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5C);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5C);
        }
    }

    public partial class DataVolumeOutgoing : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5D);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5D);
        }
    }

    public partial class DialledDigits : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5E);
        }
    }

    public partial class FileAvailableTimeStamp : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F1F);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F1F);
        }
    }

    public partial class GgsnAddress : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F20);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F20);
        }
    }

    public partial class Imei : BCDString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F21);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F21);
        }
    }

    public partial class Imsi : BCDString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F22);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F22);
        }
    }

    public partial class RecEntityId : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F23);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F23);
        }
    }

    public partial class Recipient : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F24);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F24);
        }
    }

    public partial class ReleaseVersionNumber : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F25);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F25);
        }
    }

    public partial class Sender : AsciiString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F26);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F26);
        }
    }

    public partial class SequenceNumber : NumberString
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F27);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F27);
        }
    }

    public partial class ServiceCode : Asn1ChoiceObject
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
            return Encode(strm, encRule, IsPrimitive, 0x5F2E);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F2E);
        }
        static Asn1CompositeClass<NamedChild> _clsDef = new ServiceCodeClassDefinition();
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                return _clsDef;
            }
        }
        public ServiceCode()
        {
            m_children = new Asn1Object[2];
        }
        public class ServiceCodeClassDefinition : Asn1CompositeClass<NamedChild>
        {
            public ServiceCodeClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("teleServiceCode", 0, CreateTeleServiceCode);
                m_posChildren.Add(0x5F2B, ch);
                m_children.Add("teleServiceCode", ch);
                ch = new NamedChild("bearerServiceCode", 1, CreateBearerServiceCode);
                m_posChildren.Add(0x52, ch);
                m_children.Add("bearerServiceCode", ch);
            }
            public static TeleServiceCode CreateTeleServiceCode() { return new TeleServiceCode();}
            public static BearerServiceCode CreateBearerServiceCode() { return new BearerServiceCode();}
        }
    }

    public partial class SgsnAddress : AsciiString
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

    public partial class SpecificationVersionNumber : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, IsPrimitive, 0x5F29);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, IsPrimitive, 0x5F29);
        }
    }

    public partial class SupplementaryServiceCode : HexString
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

    public partial class TeleServiceCode : HexString
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

    public partial class ThirdPartyNumber : NumberString
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

    public partial class UtcTimeOffset : AsciiString
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

    public partial class AsciiString : Asn1OctetStringObject
    {
    }

    public partial class HexString : Asn1OctetStringObject
    {
    }

    public partial class NumberString : Asn1OctetStringObject
    {
    }

    public partial class BCDString : Asn1OctetStringObject
    {
    }

}
