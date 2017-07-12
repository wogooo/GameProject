-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf"
local role_pb = require("role_pb")
module('gw2c_pb')


SELECTROLE = protobuf.Descriptor();
local SELECTROLE_USER_FIELD = protobuf.FieldDescriptor();
EQUIPLVLUP = protobuf.Descriptor();
local EQUIPLVLUP_EQUIP_FIELD = protobuf.FieldDescriptor();
local EQUIPLVLUP_CURRENCY_FIELD = protobuf.FieldDescriptor();
EQUIPLOCK = protobuf.Descriptor();
local EQUIPLOCK_EQUIP_FIELD = protobuf.FieldDescriptor();
EQUIPREPAIR = protobuf.Descriptor();
local EQUIPREPAIR_EQUIP_FIELD = protobuf.FieldDescriptor();
local EQUIPREPAIR_CURRENCY_FIELD = protobuf.FieldDescriptor();
EQUIPREMAKE = protobuf.Descriptor();
local EQUIPREMAKE_EQUIP_FIELD = protobuf.FieldDescriptor();
local EQUIPREMAKE_CURRENCY_FIELD = protobuf.FieldDescriptor();
EQUIPCONFIRMREMAKE = protobuf.Descriptor();
local EQUIPCONFIRMREMAKE_EQUIP_FIELD = protobuf.FieldDescriptor();
CARDFEED = protobuf.Descriptor();
local CARDFEED_CARD_FIELD = protobuf.FieldDescriptor();
local CARDFEED_CURRENCY_FIELD = protobuf.FieldDescriptor();
CARDSTARUP = protobuf.Descriptor();
local CARDSTARUP_CARD_FIELD = protobuf.FieldDescriptor();
local CARDSTARUP_CURRENCY_FIELD = protobuf.FieldDescriptor();
CARDCARRYUP = protobuf.Descriptor();
local CARDCARRYUP_CARD_FIELD = protobuf.FieldDescriptor();
local CARDCARRYUP_CURRENCY_FIELD = protobuf.FieldDescriptor();
CARDRANKUP = protobuf.Descriptor();
local CARDRANKUP_CARD_FIELD = protobuf.FieldDescriptor();
local CARDRANKUP_CURRENCY_FIELD = protobuf.FieldDescriptor();
CARDTAKEMEDAL = protobuf.Descriptor();
local CARDTAKEMEDAL_CARD_FIELD = protobuf.FieldDescriptor();
local CARDTAKEMEDAL_ITEM_FIELD = protobuf.FieldDescriptor();
SKILLLEVELUP = protobuf.Descriptor();
local SKILLLEVELUP_CARD_FIELD = protobuf.FieldDescriptor();
local SKILLLEVELUP_CURRENCY_FIELD = protobuf.FieldDescriptor();
SKILLRESET = protobuf.Descriptor();
local SKILLRESET_CARD_FIELD = protobuf.FieldDescriptor();
local SKILLRESET_CURRENCY_FIELD = protobuf.FieldDescriptor();
PUBLICNOTE = protobuf.Descriptor();
local PUBLICNOTE_MSG_FIELD = protobuf.FieldDescriptor();
SCILVLUP = protobuf.Descriptor();
local SCILVLUP_SCI_FIELD = protobuf.FieldDescriptor();
local SCILVLUP_CURRENCY_FIELD = protobuf.FieldDescriptor();
SCISPEED = protobuf.Descriptor();
local SCISPEED_SCI_FIELD = protobuf.FieldDescriptor();
local SCISPEED_CURRENCY_FIELD = protobuf.FieldDescriptor();
CARDUNIONLVLUP = protobuf.Descriptor();
local CARDUNIONLVLUP_CARD_FIELD = protobuf.FieldDescriptor();
local CARDUNIONLVLUP_CURRENCY_FIELD = protobuf.FieldDescriptor();
GETMAILLIST = protobuf.Descriptor();
local GETMAILLIST_MAILS_FIELD = protobuf.FieldDescriptor();
GETMAILREWARD = protobuf.Descriptor();
local GETMAILREWARD_CARD_FIELD = protobuf.FieldDescriptor();
local GETMAILREWARD_EQUIP_FIELD = protobuf.FieldDescriptor();
local GETMAILREWARD_CURRENCY_FIELD = protobuf.FieldDescriptor();
local GETMAILREWARD_ITEM_FIELD = protobuf.FieldDescriptor();
EQUIPFIT = protobuf.Descriptor();
local EQUIPFIT_LST_FIELD = protobuf.FieldDescriptor();
SELLITEM = protobuf.Descriptor();
local SELLITEM_ITEM_FIELD = protobuf.FieldDescriptor();
local SELLITEM_CURRENCY_FIELD = protobuf.FieldDescriptor();
SELLEQUIP = protobuf.Descriptor();
local SELLEQUIP_CURRENCY_FIELD = protobuf.FieldDescriptor();
COMPOSEEQUIP = protobuf.Descriptor();
local COMPOSEEQUIP_EQUIP_FIELD = protobuf.FieldDescriptor();
local COMPOSEEQUIP_ITEM_FIELD = protobuf.FieldDescriptor();
READMAIL = protobuf.Descriptor();
local READMAIL_MAIL_FIELD = protobuf.FieldDescriptor();
local READMAIL_CARD_FIELD = protobuf.FieldDescriptor();
local READMAIL_EQUIP_FIELD = protobuf.FieldDescriptor();
local READMAIL_CURRENCY_FIELD = protobuf.FieldDescriptor();
local READMAIL_ITEM_FIELD = protobuf.FieldDescriptor();
GETSHOPDETAIL = protobuf.Descriptor();
local GETSHOPDETAIL_SHOP_FIELD = protobuf.FieldDescriptor();
REFRESHSHOP = protobuf.Descriptor();
local REFRESHSHOP_SHOP_FIELD = protobuf.FieldDescriptor();
BUYSHOPITEM = protobuf.Descriptor();
local BUYSHOPITEM_SHOP_FIELD = protobuf.FieldDescriptor();
local BUYSHOPITEM_CARD_FIELD = protobuf.FieldDescriptor();
local BUYSHOPITEM_EQUIP_FIELD = protobuf.FieldDescriptor();
local BUYSHOPITEM_CURRENCY_FIELD = protobuf.FieldDescriptor();
local BUYSHOPITEM_ITEM_FIELD = protobuf.FieldDescriptor();

SELECTROLE_USER_FIELD.name = "user"
SELECTROLE_USER_FIELD.full_name = ".SelectRole.user"
SELECTROLE_USER_FIELD.number = 1
SELECTROLE_USER_FIELD.index = 0
SELECTROLE_USER_FIELD.label = 2
SELECTROLE_USER_FIELD.has_default_value = false
SELECTROLE_USER_FIELD.default_value = nil
SELECTROLE_USER_FIELD.message_type = role_pb.ROLE
SELECTROLE_USER_FIELD.type = 11
SELECTROLE_USER_FIELD.cpp_type = 10

SELECTROLE.name = "SelectRole"
SELECTROLE.full_name = ".SelectRole"
SELECTROLE.nested_types = {}
SELECTROLE.enum_types = {}
SELECTROLE.fields = {SELECTROLE_USER_FIELD}
SELECTROLE.is_extendable = false
SELECTROLE.extensions = {}
EQUIPLVLUP_EQUIP_FIELD.name = "equip"
EQUIPLVLUP_EQUIP_FIELD.full_name = ".EquipLvlup.equip"
EQUIPLVLUP_EQUIP_FIELD.number = 1
EQUIPLVLUP_EQUIP_FIELD.index = 0
EQUIPLVLUP_EQUIP_FIELD.label = 2
EQUIPLVLUP_EQUIP_FIELD.has_default_value = false
EQUIPLVLUP_EQUIP_FIELD.default_value = nil
EQUIPLVLUP_EQUIP_FIELD.message_type = role_pb.EQUIP
EQUIPLVLUP_EQUIP_FIELD.type = 11
EQUIPLVLUP_EQUIP_FIELD.cpp_type = 10

EQUIPLVLUP_CURRENCY_FIELD.name = "currency"
EQUIPLVLUP_CURRENCY_FIELD.full_name = ".EquipLvlup.currency"
EQUIPLVLUP_CURRENCY_FIELD.number = 2
EQUIPLVLUP_CURRENCY_FIELD.index = 1
EQUIPLVLUP_CURRENCY_FIELD.label = 2
EQUIPLVLUP_CURRENCY_FIELD.has_default_value = false
EQUIPLVLUP_CURRENCY_FIELD.default_value = nil
EQUIPLVLUP_CURRENCY_FIELD.message_type = role_pb.CURRENCY
EQUIPLVLUP_CURRENCY_FIELD.type = 11
EQUIPLVLUP_CURRENCY_FIELD.cpp_type = 10

EQUIPLVLUP.name = "EquipLvlup"
EQUIPLVLUP.full_name = ".EquipLvlup"
EQUIPLVLUP.nested_types = {}
EQUIPLVLUP.enum_types = {}
EQUIPLVLUP.fields = {EQUIPLVLUP_EQUIP_FIELD, EQUIPLVLUP_CURRENCY_FIELD}
EQUIPLVLUP.is_extendable = false
EQUIPLVLUP.extensions = {}
EQUIPLOCK_EQUIP_FIELD.name = "equip"
EQUIPLOCK_EQUIP_FIELD.full_name = ".EquipLock.equip"
EQUIPLOCK_EQUIP_FIELD.number = 1
EQUIPLOCK_EQUIP_FIELD.index = 0
EQUIPLOCK_EQUIP_FIELD.label = 2
EQUIPLOCK_EQUIP_FIELD.has_default_value = false
EQUIPLOCK_EQUIP_FIELD.default_value = nil
EQUIPLOCK_EQUIP_FIELD.message_type = role_pb.EQUIP
EQUIPLOCK_EQUIP_FIELD.type = 11
EQUIPLOCK_EQUIP_FIELD.cpp_type = 10

EQUIPLOCK.name = "EquipLock"
EQUIPLOCK.full_name = ".EquipLock"
EQUIPLOCK.nested_types = {}
EQUIPLOCK.enum_types = {}
EQUIPLOCK.fields = {EQUIPLOCK_EQUIP_FIELD}
EQUIPLOCK.is_extendable = false
EQUIPLOCK.extensions = {}
EQUIPREPAIR_EQUIP_FIELD.name = "equip"
EQUIPREPAIR_EQUIP_FIELD.full_name = ".EquipRepair.equip"
EQUIPREPAIR_EQUIP_FIELD.number = 1
EQUIPREPAIR_EQUIP_FIELD.index = 0
EQUIPREPAIR_EQUIP_FIELD.label = 2
EQUIPREPAIR_EQUIP_FIELD.has_default_value = false
EQUIPREPAIR_EQUIP_FIELD.default_value = nil
EQUIPREPAIR_EQUIP_FIELD.message_type = role_pb.EQUIP
EQUIPREPAIR_EQUIP_FIELD.type = 11
EQUIPREPAIR_EQUIP_FIELD.cpp_type = 10

EQUIPREPAIR_CURRENCY_FIELD.name = "currency"
EQUIPREPAIR_CURRENCY_FIELD.full_name = ".EquipRepair.currency"
EQUIPREPAIR_CURRENCY_FIELD.number = 2
EQUIPREPAIR_CURRENCY_FIELD.index = 1
EQUIPREPAIR_CURRENCY_FIELD.label = 2
EQUIPREPAIR_CURRENCY_FIELD.has_default_value = false
EQUIPREPAIR_CURRENCY_FIELD.default_value = nil
EQUIPREPAIR_CURRENCY_FIELD.message_type = role_pb.CURRENCY
EQUIPREPAIR_CURRENCY_FIELD.type = 11
EQUIPREPAIR_CURRENCY_FIELD.cpp_type = 10

EQUIPREPAIR.name = "EquipRepair"
EQUIPREPAIR.full_name = ".EquipRepair"
EQUIPREPAIR.nested_types = {}
EQUIPREPAIR.enum_types = {}
EQUIPREPAIR.fields = {EQUIPREPAIR_EQUIP_FIELD, EQUIPREPAIR_CURRENCY_FIELD}
EQUIPREPAIR.is_extendable = false
EQUIPREPAIR.extensions = {}
EQUIPREMAKE_EQUIP_FIELD.name = "equip"
EQUIPREMAKE_EQUIP_FIELD.full_name = ".EquipRemake.equip"
EQUIPREMAKE_EQUIP_FIELD.number = 1
EQUIPREMAKE_EQUIP_FIELD.index = 0
EQUIPREMAKE_EQUIP_FIELD.label = 2
EQUIPREMAKE_EQUIP_FIELD.has_default_value = false
EQUIPREMAKE_EQUIP_FIELD.default_value = nil
EQUIPREMAKE_EQUIP_FIELD.message_type = role_pb.EQUIP
EQUIPREMAKE_EQUIP_FIELD.type = 11
EQUIPREMAKE_EQUIP_FIELD.cpp_type = 10

EQUIPREMAKE_CURRENCY_FIELD.name = "currency"
EQUIPREMAKE_CURRENCY_FIELD.full_name = ".EquipRemake.currency"
EQUIPREMAKE_CURRENCY_FIELD.number = 2
EQUIPREMAKE_CURRENCY_FIELD.index = 1
EQUIPREMAKE_CURRENCY_FIELD.label = 2
EQUIPREMAKE_CURRENCY_FIELD.has_default_value = false
EQUIPREMAKE_CURRENCY_FIELD.default_value = nil
EQUIPREMAKE_CURRENCY_FIELD.message_type = role_pb.CURRENCY
EQUIPREMAKE_CURRENCY_FIELD.type = 11
EQUIPREMAKE_CURRENCY_FIELD.cpp_type = 10

EQUIPREMAKE.name = "EquipRemake"
EQUIPREMAKE.full_name = ".EquipRemake"
EQUIPREMAKE.nested_types = {}
EQUIPREMAKE.enum_types = {}
EQUIPREMAKE.fields = {EQUIPREMAKE_EQUIP_FIELD, EQUIPREMAKE_CURRENCY_FIELD}
EQUIPREMAKE.is_extendable = false
EQUIPREMAKE.extensions = {}
EQUIPCONFIRMREMAKE_EQUIP_FIELD.name = "equip"
EQUIPCONFIRMREMAKE_EQUIP_FIELD.full_name = ".EquipConfirmRemake.equip"
EQUIPCONFIRMREMAKE_EQUIP_FIELD.number = 1
EQUIPCONFIRMREMAKE_EQUIP_FIELD.index = 0
EQUIPCONFIRMREMAKE_EQUIP_FIELD.label = 2
EQUIPCONFIRMREMAKE_EQUIP_FIELD.has_default_value = false
EQUIPCONFIRMREMAKE_EQUIP_FIELD.default_value = nil
EQUIPCONFIRMREMAKE_EQUIP_FIELD.message_type = role_pb.EQUIP
EQUIPCONFIRMREMAKE_EQUIP_FIELD.type = 11
EQUIPCONFIRMREMAKE_EQUIP_FIELD.cpp_type = 10

EQUIPCONFIRMREMAKE.name = "EquipConfirmRemake"
EQUIPCONFIRMREMAKE.full_name = ".EquipConfirmRemake"
EQUIPCONFIRMREMAKE.nested_types = {}
EQUIPCONFIRMREMAKE.enum_types = {}
EQUIPCONFIRMREMAKE.fields = {EQUIPCONFIRMREMAKE_EQUIP_FIELD}
EQUIPCONFIRMREMAKE.is_extendable = false
EQUIPCONFIRMREMAKE.extensions = {}
CARDFEED_CARD_FIELD.name = "card"
CARDFEED_CARD_FIELD.full_name = ".CardFeed.card"
CARDFEED_CARD_FIELD.number = 1
CARDFEED_CARD_FIELD.index = 0
CARDFEED_CARD_FIELD.label = 2
CARDFEED_CARD_FIELD.has_default_value = false
CARDFEED_CARD_FIELD.default_value = nil
CARDFEED_CARD_FIELD.message_type = role_pb.CARD
CARDFEED_CARD_FIELD.type = 11
CARDFEED_CARD_FIELD.cpp_type = 10

CARDFEED_CURRENCY_FIELD.name = "currency"
CARDFEED_CURRENCY_FIELD.full_name = ".CardFeed.currency"
CARDFEED_CURRENCY_FIELD.number = 2
CARDFEED_CURRENCY_FIELD.index = 1
CARDFEED_CURRENCY_FIELD.label = 2
CARDFEED_CURRENCY_FIELD.has_default_value = false
CARDFEED_CURRENCY_FIELD.default_value = nil
CARDFEED_CURRENCY_FIELD.message_type = role_pb.CURRENCY
CARDFEED_CURRENCY_FIELD.type = 11
CARDFEED_CURRENCY_FIELD.cpp_type = 10

CARDFEED.name = "CardFeed"
CARDFEED.full_name = ".CardFeed"
CARDFEED.nested_types = {}
CARDFEED.enum_types = {}
CARDFEED.fields = {CARDFEED_CARD_FIELD, CARDFEED_CURRENCY_FIELD}
CARDFEED.is_extendable = false
CARDFEED.extensions = {}
CARDSTARUP_CARD_FIELD.name = "card"
CARDSTARUP_CARD_FIELD.full_name = ".CardStarup.card"
CARDSTARUP_CARD_FIELD.number = 1
CARDSTARUP_CARD_FIELD.index = 0
CARDSTARUP_CARD_FIELD.label = 2
CARDSTARUP_CARD_FIELD.has_default_value = false
CARDSTARUP_CARD_FIELD.default_value = nil
CARDSTARUP_CARD_FIELD.message_type = role_pb.CARD
CARDSTARUP_CARD_FIELD.type = 11
CARDSTARUP_CARD_FIELD.cpp_type = 10

CARDSTARUP_CURRENCY_FIELD.name = "currency"
CARDSTARUP_CURRENCY_FIELD.full_name = ".CardStarup.currency"
CARDSTARUP_CURRENCY_FIELD.number = 2
CARDSTARUP_CURRENCY_FIELD.index = 1
CARDSTARUP_CURRENCY_FIELD.label = 2
CARDSTARUP_CURRENCY_FIELD.has_default_value = false
CARDSTARUP_CURRENCY_FIELD.default_value = nil
CARDSTARUP_CURRENCY_FIELD.message_type = role_pb.CURRENCY
CARDSTARUP_CURRENCY_FIELD.type = 11
CARDSTARUP_CURRENCY_FIELD.cpp_type = 10

CARDSTARUP.name = "CardStarup"
CARDSTARUP.full_name = ".CardStarup"
CARDSTARUP.nested_types = {}
CARDSTARUP.enum_types = {}
CARDSTARUP.fields = {CARDSTARUP_CARD_FIELD, CARDSTARUP_CURRENCY_FIELD}
CARDSTARUP.is_extendable = false
CARDSTARUP.extensions = {}
CARDCARRYUP_CARD_FIELD.name = "card"
CARDCARRYUP_CARD_FIELD.full_name = ".CardCarryup.card"
CARDCARRYUP_CARD_FIELD.number = 1
CARDCARRYUP_CARD_FIELD.index = 0
CARDCARRYUP_CARD_FIELD.label = 2
CARDCARRYUP_CARD_FIELD.has_default_value = false
CARDCARRYUP_CARD_FIELD.default_value = nil
CARDCARRYUP_CARD_FIELD.message_type = role_pb.CARD
CARDCARRYUP_CARD_FIELD.type = 11
CARDCARRYUP_CARD_FIELD.cpp_type = 10

CARDCARRYUP_CURRENCY_FIELD.name = "currency"
CARDCARRYUP_CURRENCY_FIELD.full_name = ".CardCarryup.currency"
CARDCARRYUP_CURRENCY_FIELD.number = 2
CARDCARRYUP_CURRENCY_FIELD.index = 1
CARDCARRYUP_CURRENCY_FIELD.label = 2
CARDCARRYUP_CURRENCY_FIELD.has_default_value = false
CARDCARRYUP_CURRENCY_FIELD.default_value = nil
CARDCARRYUP_CURRENCY_FIELD.message_type = role_pb.CURRENCY
CARDCARRYUP_CURRENCY_FIELD.type = 11
CARDCARRYUP_CURRENCY_FIELD.cpp_type = 10

CARDCARRYUP.name = "CardCarryup"
CARDCARRYUP.full_name = ".CardCarryup"
CARDCARRYUP.nested_types = {}
CARDCARRYUP.enum_types = {}
CARDCARRYUP.fields = {CARDCARRYUP_CARD_FIELD, CARDCARRYUP_CURRENCY_FIELD}
CARDCARRYUP.is_extendable = false
CARDCARRYUP.extensions = {}
CARDRANKUP_CARD_FIELD.name = "card"
CARDRANKUP_CARD_FIELD.full_name = ".CardRankup.card"
CARDRANKUP_CARD_FIELD.number = 1
CARDRANKUP_CARD_FIELD.index = 0
CARDRANKUP_CARD_FIELD.label = 2
CARDRANKUP_CARD_FIELD.has_default_value = false
CARDRANKUP_CARD_FIELD.default_value = nil
CARDRANKUP_CARD_FIELD.message_type = role_pb.CARD
CARDRANKUP_CARD_FIELD.type = 11
CARDRANKUP_CARD_FIELD.cpp_type = 10

CARDRANKUP_CURRENCY_FIELD.name = "currency"
CARDRANKUP_CURRENCY_FIELD.full_name = ".CardRankup.currency"
CARDRANKUP_CURRENCY_FIELD.number = 2
CARDRANKUP_CURRENCY_FIELD.index = 1
CARDRANKUP_CURRENCY_FIELD.label = 2
CARDRANKUP_CURRENCY_FIELD.has_default_value = false
CARDRANKUP_CURRENCY_FIELD.default_value = nil
CARDRANKUP_CURRENCY_FIELD.message_type = role_pb.CURRENCY
CARDRANKUP_CURRENCY_FIELD.type = 11
CARDRANKUP_CURRENCY_FIELD.cpp_type = 10

CARDRANKUP.name = "CardRankup"
CARDRANKUP.full_name = ".CardRankup"
CARDRANKUP.nested_types = {}
CARDRANKUP.enum_types = {}
CARDRANKUP.fields = {CARDRANKUP_CARD_FIELD, CARDRANKUP_CURRENCY_FIELD}
CARDRANKUP.is_extendable = false
CARDRANKUP.extensions = {}
CARDTAKEMEDAL_CARD_FIELD.name = "card"
CARDTAKEMEDAL_CARD_FIELD.full_name = ".CardTakeMedal.card"
CARDTAKEMEDAL_CARD_FIELD.number = 1
CARDTAKEMEDAL_CARD_FIELD.index = 0
CARDTAKEMEDAL_CARD_FIELD.label = 2
CARDTAKEMEDAL_CARD_FIELD.has_default_value = false
CARDTAKEMEDAL_CARD_FIELD.default_value = nil
CARDTAKEMEDAL_CARD_FIELD.message_type = role_pb.CARD
CARDTAKEMEDAL_CARD_FIELD.type = 11
CARDTAKEMEDAL_CARD_FIELD.cpp_type = 10

CARDTAKEMEDAL_ITEM_FIELD.name = "item"
CARDTAKEMEDAL_ITEM_FIELD.full_name = ".CardTakeMedal.item"
CARDTAKEMEDAL_ITEM_FIELD.number = 2
CARDTAKEMEDAL_ITEM_FIELD.index = 1
CARDTAKEMEDAL_ITEM_FIELD.label = 3
CARDTAKEMEDAL_ITEM_FIELD.has_default_value = false
CARDTAKEMEDAL_ITEM_FIELD.default_value = {}
CARDTAKEMEDAL_ITEM_FIELD.message_type = role_pb.ITEM
CARDTAKEMEDAL_ITEM_FIELD.type = 11
CARDTAKEMEDAL_ITEM_FIELD.cpp_type = 10

CARDTAKEMEDAL.name = "CardTakeMedal"
CARDTAKEMEDAL.full_name = ".CardTakeMedal"
CARDTAKEMEDAL.nested_types = {}
CARDTAKEMEDAL.enum_types = {}
CARDTAKEMEDAL.fields = {CARDTAKEMEDAL_CARD_FIELD, CARDTAKEMEDAL_ITEM_FIELD}
CARDTAKEMEDAL.is_extendable = false
CARDTAKEMEDAL.extensions = {}
SKILLLEVELUP_CARD_FIELD.name = "card"
SKILLLEVELUP_CARD_FIELD.full_name = ".SkillLevelup.card"
SKILLLEVELUP_CARD_FIELD.number = 1
SKILLLEVELUP_CARD_FIELD.index = 0
SKILLLEVELUP_CARD_FIELD.label = 2
SKILLLEVELUP_CARD_FIELD.has_default_value = false
SKILLLEVELUP_CARD_FIELD.default_value = nil
SKILLLEVELUP_CARD_FIELD.message_type = role_pb.CARD
SKILLLEVELUP_CARD_FIELD.type = 11
SKILLLEVELUP_CARD_FIELD.cpp_type = 10

SKILLLEVELUP_CURRENCY_FIELD.name = "currency"
SKILLLEVELUP_CURRENCY_FIELD.full_name = ".SkillLevelup.currency"
SKILLLEVELUP_CURRENCY_FIELD.number = 2
SKILLLEVELUP_CURRENCY_FIELD.index = 1
SKILLLEVELUP_CURRENCY_FIELD.label = 2
SKILLLEVELUP_CURRENCY_FIELD.has_default_value = false
SKILLLEVELUP_CURRENCY_FIELD.default_value = nil
SKILLLEVELUP_CURRENCY_FIELD.message_type = role_pb.CURRENCY
SKILLLEVELUP_CURRENCY_FIELD.type = 11
SKILLLEVELUP_CURRENCY_FIELD.cpp_type = 10

SKILLLEVELUP.name = "SkillLevelup"
SKILLLEVELUP.full_name = ".SkillLevelup"
SKILLLEVELUP.nested_types = {}
SKILLLEVELUP.enum_types = {}
SKILLLEVELUP.fields = {SKILLLEVELUP_CARD_FIELD, SKILLLEVELUP_CURRENCY_FIELD}
SKILLLEVELUP.is_extendable = false
SKILLLEVELUP.extensions = {}
SKILLRESET_CARD_FIELD.name = "card"
SKILLRESET_CARD_FIELD.full_name = ".SkillReset.card"
SKILLRESET_CARD_FIELD.number = 1
SKILLRESET_CARD_FIELD.index = 0
SKILLRESET_CARD_FIELD.label = 2
SKILLRESET_CARD_FIELD.has_default_value = false
SKILLRESET_CARD_FIELD.default_value = nil
SKILLRESET_CARD_FIELD.message_type = role_pb.CARD
SKILLRESET_CARD_FIELD.type = 11
SKILLRESET_CARD_FIELD.cpp_type = 10

SKILLRESET_CURRENCY_FIELD.name = "currency"
SKILLRESET_CURRENCY_FIELD.full_name = ".SkillReset.currency"
SKILLRESET_CURRENCY_FIELD.number = 2
SKILLRESET_CURRENCY_FIELD.index = 1
SKILLRESET_CURRENCY_FIELD.label = 2
SKILLRESET_CURRENCY_FIELD.has_default_value = false
SKILLRESET_CURRENCY_FIELD.default_value = nil
SKILLRESET_CURRENCY_FIELD.message_type = role_pb.CURRENCY
SKILLRESET_CURRENCY_FIELD.type = 11
SKILLRESET_CURRENCY_FIELD.cpp_type = 10

SKILLRESET.name = "SkillReset"
SKILLRESET.full_name = ".SkillReset"
SKILLRESET.nested_types = {}
SKILLRESET.enum_types = {}
SKILLRESET.fields = {SKILLRESET_CARD_FIELD, SKILLRESET_CURRENCY_FIELD}
SKILLRESET.is_extendable = false
SKILLRESET.extensions = {}
PUBLICNOTE_MSG_FIELD.name = "msg"
PUBLICNOTE_MSG_FIELD.full_name = ".PublicNote.msg"
PUBLICNOTE_MSG_FIELD.number = 1
PUBLICNOTE_MSG_FIELD.index = 0
PUBLICNOTE_MSG_FIELD.label = 2
PUBLICNOTE_MSG_FIELD.has_default_value = false
PUBLICNOTE_MSG_FIELD.default_value = ""
PUBLICNOTE_MSG_FIELD.type = 9
PUBLICNOTE_MSG_FIELD.cpp_type = 9

PUBLICNOTE.name = "PublicNote"
PUBLICNOTE.full_name = ".PublicNote"
PUBLICNOTE.nested_types = {}
PUBLICNOTE.enum_types = {}
PUBLICNOTE.fields = {PUBLICNOTE_MSG_FIELD}
PUBLICNOTE.is_extendable = false
PUBLICNOTE.extensions = {}
SCILVLUP_SCI_FIELD.name = "sci"
SCILVLUP_SCI_FIELD.full_name = ".SciLvlup.sci"
SCILVLUP_SCI_FIELD.number = 1
SCILVLUP_SCI_FIELD.index = 0
SCILVLUP_SCI_FIELD.label = 2
SCILVLUP_SCI_FIELD.has_default_value = false
SCILVLUP_SCI_FIELD.default_value = nil
SCILVLUP_SCI_FIELD.message_type = role_pb.SCI
SCILVLUP_SCI_FIELD.type = 11
SCILVLUP_SCI_FIELD.cpp_type = 10

SCILVLUP_CURRENCY_FIELD.name = "currency"
SCILVLUP_CURRENCY_FIELD.full_name = ".SciLvlup.currency"
SCILVLUP_CURRENCY_FIELD.number = 2
SCILVLUP_CURRENCY_FIELD.index = 1
SCILVLUP_CURRENCY_FIELD.label = 2
SCILVLUP_CURRENCY_FIELD.has_default_value = false
SCILVLUP_CURRENCY_FIELD.default_value = nil
SCILVLUP_CURRENCY_FIELD.message_type = role_pb.CURRENCY
SCILVLUP_CURRENCY_FIELD.type = 11
SCILVLUP_CURRENCY_FIELD.cpp_type = 10

SCILVLUP.name = "SciLvlup"
SCILVLUP.full_name = ".SciLvlup"
SCILVLUP.nested_types = {}
SCILVLUP.enum_types = {}
SCILVLUP.fields = {SCILVLUP_SCI_FIELD, SCILVLUP_CURRENCY_FIELD}
SCILVLUP.is_extendable = false
SCILVLUP.extensions = {}
SCISPEED_SCI_FIELD.name = "sci"
SCISPEED_SCI_FIELD.full_name = ".SciSpeed.sci"
SCISPEED_SCI_FIELD.number = 1
SCISPEED_SCI_FIELD.index = 0
SCISPEED_SCI_FIELD.label = 2
SCISPEED_SCI_FIELD.has_default_value = false
SCISPEED_SCI_FIELD.default_value = nil
SCISPEED_SCI_FIELD.message_type = role_pb.SCI
SCISPEED_SCI_FIELD.type = 11
SCISPEED_SCI_FIELD.cpp_type = 10

SCISPEED_CURRENCY_FIELD.name = "currency"
SCISPEED_CURRENCY_FIELD.full_name = ".SciSpeed.currency"
SCISPEED_CURRENCY_FIELD.number = 2
SCISPEED_CURRENCY_FIELD.index = 1
SCISPEED_CURRENCY_FIELD.label = 2
SCISPEED_CURRENCY_FIELD.has_default_value = false
SCISPEED_CURRENCY_FIELD.default_value = nil
SCISPEED_CURRENCY_FIELD.message_type = role_pb.CURRENCY
SCISPEED_CURRENCY_FIELD.type = 11
SCISPEED_CURRENCY_FIELD.cpp_type = 10

SCISPEED.name = "SciSpeed"
SCISPEED.full_name = ".SciSpeed"
SCISPEED.nested_types = {}
SCISPEED.enum_types = {}
SCISPEED.fields = {SCISPEED_SCI_FIELD, SCISPEED_CURRENCY_FIELD}
SCISPEED.is_extendable = false
SCISPEED.extensions = {}
CARDUNIONLVLUP_CARD_FIELD.name = "card"
CARDUNIONLVLUP_CARD_FIELD.full_name = ".CardUnionLvlup.card"
CARDUNIONLVLUP_CARD_FIELD.number = 1
CARDUNIONLVLUP_CARD_FIELD.index = 0
CARDUNIONLVLUP_CARD_FIELD.label = 2
CARDUNIONLVLUP_CARD_FIELD.has_default_value = false
CARDUNIONLVLUP_CARD_FIELD.default_value = nil
CARDUNIONLVLUP_CARD_FIELD.message_type = role_pb.CARD
CARDUNIONLVLUP_CARD_FIELD.type = 11
CARDUNIONLVLUP_CARD_FIELD.cpp_type = 10

CARDUNIONLVLUP_CURRENCY_FIELD.name = "currency"
CARDUNIONLVLUP_CURRENCY_FIELD.full_name = ".CardUnionLvlup.currency"
CARDUNIONLVLUP_CURRENCY_FIELD.number = 2
CARDUNIONLVLUP_CURRENCY_FIELD.index = 1
CARDUNIONLVLUP_CURRENCY_FIELD.label = 2
CARDUNIONLVLUP_CURRENCY_FIELD.has_default_value = false
CARDUNIONLVLUP_CURRENCY_FIELD.default_value = nil
CARDUNIONLVLUP_CURRENCY_FIELD.message_type = role_pb.CURRENCY
CARDUNIONLVLUP_CURRENCY_FIELD.type = 11
CARDUNIONLVLUP_CURRENCY_FIELD.cpp_type = 10

CARDUNIONLVLUP.name = "CardUnionLvlup"
CARDUNIONLVLUP.full_name = ".CardUnionLvlup"
CARDUNIONLVLUP.nested_types = {}
CARDUNIONLVLUP.enum_types = {}
CARDUNIONLVLUP.fields = {CARDUNIONLVLUP_CARD_FIELD, CARDUNIONLVLUP_CURRENCY_FIELD}
CARDUNIONLVLUP.is_extendable = false
CARDUNIONLVLUP.extensions = {}
GETMAILLIST_MAILS_FIELD.name = "mails"
GETMAILLIST_MAILS_FIELD.full_name = ".GetMailList.mails"
GETMAILLIST_MAILS_FIELD.number = 1
GETMAILLIST_MAILS_FIELD.index = 0
GETMAILLIST_MAILS_FIELD.label = 3
GETMAILLIST_MAILS_FIELD.has_default_value = false
GETMAILLIST_MAILS_FIELD.default_value = {}
GETMAILLIST_MAILS_FIELD.message_type = role_pb.MAIL
GETMAILLIST_MAILS_FIELD.type = 11
GETMAILLIST_MAILS_FIELD.cpp_type = 10

GETMAILLIST.name = "GetMailList"
GETMAILLIST.full_name = ".GetMailList"
GETMAILLIST.nested_types = {}
GETMAILLIST.enum_types = {}
GETMAILLIST.fields = {GETMAILLIST_MAILS_FIELD}
GETMAILLIST.is_extendable = false
GETMAILLIST.extensions = {}
GETMAILREWARD_CARD_FIELD.name = "card"
GETMAILREWARD_CARD_FIELD.full_name = ".GetMailReward.card"
GETMAILREWARD_CARD_FIELD.number = 1
GETMAILREWARD_CARD_FIELD.index = 0
GETMAILREWARD_CARD_FIELD.label = 3
GETMAILREWARD_CARD_FIELD.has_default_value = false
GETMAILREWARD_CARD_FIELD.default_value = {}
GETMAILREWARD_CARD_FIELD.message_type = role_pb.CARD
GETMAILREWARD_CARD_FIELD.type = 11
GETMAILREWARD_CARD_FIELD.cpp_type = 10

GETMAILREWARD_EQUIP_FIELD.name = "equip"
GETMAILREWARD_EQUIP_FIELD.full_name = ".GetMailReward.equip"
GETMAILREWARD_EQUIP_FIELD.number = 2
GETMAILREWARD_EQUIP_FIELD.index = 1
GETMAILREWARD_EQUIP_FIELD.label = 3
GETMAILREWARD_EQUIP_FIELD.has_default_value = false
GETMAILREWARD_EQUIP_FIELD.default_value = {}
GETMAILREWARD_EQUIP_FIELD.message_type = role_pb.EQUIP
GETMAILREWARD_EQUIP_FIELD.type = 11
GETMAILREWARD_EQUIP_FIELD.cpp_type = 10

GETMAILREWARD_CURRENCY_FIELD.name = "currency"
GETMAILREWARD_CURRENCY_FIELD.full_name = ".GetMailReward.currency"
GETMAILREWARD_CURRENCY_FIELD.number = 3
GETMAILREWARD_CURRENCY_FIELD.index = 2
GETMAILREWARD_CURRENCY_FIELD.label = 2
GETMAILREWARD_CURRENCY_FIELD.has_default_value = false
GETMAILREWARD_CURRENCY_FIELD.default_value = nil
GETMAILREWARD_CURRENCY_FIELD.message_type = role_pb.CURRENCY
GETMAILREWARD_CURRENCY_FIELD.type = 11
GETMAILREWARD_CURRENCY_FIELD.cpp_type = 10

GETMAILREWARD_ITEM_FIELD.name = "item"
GETMAILREWARD_ITEM_FIELD.full_name = ".GetMailReward.item"
GETMAILREWARD_ITEM_FIELD.number = 4
GETMAILREWARD_ITEM_FIELD.index = 3
GETMAILREWARD_ITEM_FIELD.label = 3
GETMAILREWARD_ITEM_FIELD.has_default_value = false
GETMAILREWARD_ITEM_FIELD.default_value = {}
GETMAILREWARD_ITEM_FIELD.message_type = role_pb.ITEM
GETMAILREWARD_ITEM_FIELD.type = 11
GETMAILREWARD_ITEM_FIELD.cpp_type = 10

GETMAILREWARD.name = "GetMailReward"
GETMAILREWARD.full_name = ".GetMailReward"
GETMAILREWARD.nested_types = {}
GETMAILREWARD.enum_types = {}
GETMAILREWARD.fields = {GETMAILREWARD_CARD_FIELD, GETMAILREWARD_EQUIP_FIELD, GETMAILREWARD_CURRENCY_FIELD, GETMAILREWARD_ITEM_FIELD}
GETMAILREWARD.is_extendable = false
GETMAILREWARD.extensions = {}
EQUIPFIT_LST_FIELD.name = "lst"
EQUIPFIT_LST_FIELD.full_name = ".EquipFit.lst"
EQUIPFIT_LST_FIELD.number = 1
EQUIPFIT_LST_FIELD.index = 0
EQUIPFIT_LST_FIELD.label = 3
EQUIPFIT_LST_FIELD.has_default_value = false
EQUIPFIT_LST_FIELD.default_value = {}
EQUIPFIT_LST_FIELD.type = 5
EQUIPFIT_LST_FIELD.cpp_type = 1

EQUIPFIT.name = "EquipFit"
EQUIPFIT.full_name = ".EquipFit"
EQUIPFIT.nested_types = {}
EQUIPFIT.enum_types = {}
EQUIPFIT.fields = {EQUIPFIT_LST_FIELD}
EQUIPFIT.is_extendable = false
EQUIPFIT.extensions = {}
SELLITEM_ITEM_FIELD.name = "item"
SELLITEM_ITEM_FIELD.full_name = ".SellItem.item"
SELLITEM_ITEM_FIELD.number = 1
SELLITEM_ITEM_FIELD.index = 0
SELLITEM_ITEM_FIELD.label = 3
SELLITEM_ITEM_FIELD.has_default_value = false
SELLITEM_ITEM_FIELD.default_value = {}
SELLITEM_ITEM_FIELD.message_type = role_pb.ITEM
SELLITEM_ITEM_FIELD.type = 11
SELLITEM_ITEM_FIELD.cpp_type = 10

SELLITEM_CURRENCY_FIELD.name = "currency"
SELLITEM_CURRENCY_FIELD.full_name = ".SellItem.currency"
SELLITEM_CURRENCY_FIELD.number = 2
SELLITEM_CURRENCY_FIELD.index = 1
SELLITEM_CURRENCY_FIELD.label = 2
SELLITEM_CURRENCY_FIELD.has_default_value = false
SELLITEM_CURRENCY_FIELD.default_value = nil
SELLITEM_CURRENCY_FIELD.message_type = role_pb.CURRENCY
SELLITEM_CURRENCY_FIELD.type = 11
SELLITEM_CURRENCY_FIELD.cpp_type = 10

SELLITEM.name = "SellItem"
SELLITEM.full_name = ".SellItem"
SELLITEM.nested_types = {}
SELLITEM.enum_types = {}
SELLITEM.fields = {SELLITEM_ITEM_FIELD, SELLITEM_CURRENCY_FIELD}
SELLITEM.is_extendable = false
SELLITEM.extensions = {}
SELLEQUIP_CURRENCY_FIELD.name = "currency"
SELLEQUIP_CURRENCY_FIELD.full_name = ".SellEquip.currency"
SELLEQUIP_CURRENCY_FIELD.number = 1
SELLEQUIP_CURRENCY_FIELD.index = 0
SELLEQUIP_CURRENCY_FIELD.label = 2
SELLEQUIP_CURRENCY_FIELD.has_default_value = false
SELLEQUIP_CURRENCY_FIELD.default_value = nil
SELLEQUIP_CURRENCY_FIELD.message_type = role_pb.CURRENCY
SELLEQUIP_CURRENCY_FIELD.type = 11
SELLEQUIP_CURRENCY_FIELD.cpp_type = 10

SELLEQUIP.name = "SellEquip"
SELLEQUIP.full_name = ".SellEquip"
SELLEQUIP.nested_types = {}
SELLEQUIP.enum_types = {}
SELLEQUIP.fields = {SELLEQUIP_CURRENCY_FIELD}
SELLEQUIP.is_extendable = false
SELLEQUIP.extensions = {}
COMPOSEEQUIP_EQUIP_FIELD.name = "equip"
COMPOSEEQUIP_EQUIP_FIELD.full_name = ".ComposeEquip.equip"
COMPOSEEQUIP_EQUIP_FIELD.number = 1
COMPOSEEQUIP_EQUIP_FIELD.index = 0
COMPOSEEQUIP_EQUIP_FIELD.label = 2
COMPOSEEQUIP_EQUIP_FIELD.has_default_value = false
COMPOSEEQUIP_EQUIP_FIELD.default_value = nil
COMPOSEEQUIP_EQUIP_FIELD.message_type = role_pb.EQUIP
COMPOSEEQUIP_EQUIP_FIELD.type = 11
COMPOSEEQUIP_EQUIP_FIELD.cpp_type = 10

COMPOSEEQUIP_ITEM_FIELD.name = "item"
COMPOSEEQUIP_ITEM_FIELD.full_name = ".ComposeEquip.item"
COMPOSEEQUIP_ITEM_FIELD.number = 2
COMPOSEEQUIP_ITEM_FIELD.index = 1
COMPOSEEQUIP_ITEM_FIELD.label = 3
COMPOSEEQUIP_ITEM_FIELD.has_default_value = false
COMPOSEEQUIP_ITEM_FIELD.default_value = {}
COMPOSEEQUIP_ITEM_FIELD.message_type = role_pb.ITEM
COMPOSEEQUIP_ITEM_FIELD.type = 11
COMPOSEEQUIP_ITEM_FIELD.cpp_type = 10

COMPOSEEQUIP.name = "ComposeEquip"
COMPOSEEQUIP.full_name = ".ComposeEquip"
COMPOSEEQUIP.nested_types = {}
COMPOSEEQUIP.enum_types = {}
COMPOSEEQUIP.fields = {COMPOSEEQUIP_EQUIP_FIELD, COMPOSEEQUIP_ITEM_FIELD}
COMPOSEEQUIP.is_extendable = false
COMPOSEEQUIP.extensions = {}
READMAIL_MAIL_FIELD.name = "mail"
READMAIL_MAIL_FIELD.full_name = ".ReadMail.mail"
READMAIL_MAIL_FIELD.number = 1
READMAIL_MAIL_FIELD.index = 0
READMAIL_MAIL_FIELD.label = 2
READMAIL_MAIL_FIELD.has_default_value = false
READMAIL_MAIL_FIELD.default_value = nil
READMAIL_MAIL_FIELD.message_type = role_pb.MAIL
READMAIL_MAIL_FIELD.type = 11
READMAIL_MAIL_FIELD.cpp_type = 10

READMAIL_CARD_FIELD.name = "card"
READMAIL_CARD_FIELD.full_name = ".ReadMail.card"
READMAIL_CARD_FIELD.number = 2
READMAIL_CARD_FIELD.index = 1
READMAIL_CARD_FIELD.label = 3
READMAIL_CARD_FIELD.has_default_value = false
READMAIL_CARD_FIELD.default_value = {}
READMAIL_CARD_FIELD.message_type = role_pb.CARD
READMAIL_CARD_FIELD.type = 11
READMAIL_CARD_FIELD.cpp_type = 10

READMAIL_EQUIP_FIELD.name = "equip"
READMAIL_EQUIP_FIELD.full_name = ".ReadMail.equip"
READMAIL_EQUIP_FIELD.number = 3
READMAIL_EQUIP_FIELD.index = 2
READMAIL_EQUIP_FIELD.label = 3
READMAIL_EQUIP_FIELD.has_default_value = false
READMAIL_EQUIP_FIELD.default_value = {}
READMAIL_EQUIP_FIELD.message_type = role_pb.EQUIP
READMAIL_EQUIP_FIELD.type = 11
READMAIL_EQUIP_FIELD.cpp_type = 10

READMAIL_CURRENCY_FIELD.name = "currency"
READMAIL_CURRENCY_FIELD.full_name = ".ReadMail.currency"
READMAIL_CURRENCY_FIELD.number = 4
READMAIL_CURRENCY_FIELD.index = 3
READMAIL_CURRENCY_FIELD.label = 2
READMAIL_CURRENCY_FIELD.has_default_value = false
READMAIL_CURRENCY_FIELD.default_value = nil
READMAIL_CURRENCY_FIELD.message_type = role_pb.CURRENCY
READMAIL_CURRENCY_FIELD.type = 11
READMAIL_CURRENCY_FIELD.cpp_type = 10

READMAIL_ITEM_FIELD.name = "item"
READMAIL_ITEM_FIELD.full_name = ".ReadMail.item"
READMAIL_ITEM_FIELD.number = 5
READMAIL_ITEM_FIELD.index = 4
READMAIL_ITEM_FIELD.label = 3
READMAIL_ITEM_FIELD.has_default_value = false
READMAIL_ITEM_FIELD.default_value = {}
READMAIL_ITEM_FIELD.message_type = role_pb.ITEM
READMAIL_ITEM_FIELD.type = 11
READMAIL_ITEM_FIELD.cpp_type = 10

READMAIL.name = "ReadMail"
READMAIL.full_name = ".ReadMail"
READMAIL.nested_types = {}
READMAIL.enum_types = {}
READMAIL.fields = {READMAIL_MAIL_FIELD, READMAIL_CARD_FIELD, READMAIL_EQUIP_FIELD, READMAIL_CURRENCY_FIELD, READMAIL_ITEM_FIELD}
READMAIL.is_extendable = false
READMAIL.extensions = {}
GETSHOPDETAIL_SHOP_FIELD.name = "shop"
GETSHOPDETAIL_SHOP_FIELD.full_name = ".GetShopDetail.shop"
GETSHOPDETAIL_SHOP_FIELD.number = 1
GETSHOPDETAIL_SHOP_FIELD.index = 0
GETSHOPDETAIL_SHOP_FIELD.label = 2
GETSHOPDETAIL_SHOP_FIELD.has_default_value = false
GETSHOPDETAIL_SHOP_FIELD.default_value = nil
GETSHOPDETAIL_SHOP_FIELD.message_type = role_pb.SHOPITEM
GETSHOPDETAIL_SHOP_FIELD.type = 11
GETSHOPDETAIL_SHOP_FIELD.cpp_type = 10

GETSHOPDETAIL.name = "GetShopDetail"
GETSHOPDETAIL.full_name = ".GetShopDetail"
GETSHOPDETAIL.nested_types = {}
GETSHOPDETAIL.enum_types = {}
GETSHOPDETAIL.fields = {GETSHOPDETAIL_SHOP_FIELD}
GETSHOPDETAIL.is_extendable = false
GETSHOPDETAIL.extensions = {}
REFRESHSHOP_SHOP_FIELD.name = "shop"
REFRESHSHOP_SHOP_FIELD.full_name = ".RefreshShop.shop"
REFRESHSHOP_SHOP_FIELD.number = 1
REFRESHSHOP_SHOP_FIELD.index = 0
REFRESHSHOP_SHOP_FIELD.label = 2
REFRESHSHOP_SHOP_FIELD.has_default_value = false
REFRESHSHOP_SHOP_FIELD.default_value = nil
REFRESHSHOP_SHOP_FIELD.message_type = role_pb.SHOPITEM
REFRESHSHOP_SHOP_FIELD.type = 11
REFRESHSHOP_SHOP_FIELD.cpp_type = 10

REFRESHSHOP.name = "RefreshShop"
REFRESHSHOP.full_name = ".RefreshShop"
REFRESHSHOP.nested_types = {}
REFRESHSHOP.enum_types = {}
REFRESHSHOP.fields = {REFRESHSHOP_SHOP_FIELD}
REFRESHSHOP.is_extendable = false
REFRESHSHOP.extensions = {}
BUYSHOPITEM_SHOP_FIELD.name = "shop"
BUYSHOPITEM_SHOP_FIELD.full_name = ".BuyShopItem.shop"
BUYSHOPITEM_SHOP_FIELD.number = 1
BUYSHOPITEM_SHOP_FIELD.index = 0
BUYSHOPITEM_SHOP_FIELD.label = 2
BUYSHOPITEM_SHOP_FIELD.has_default_value = false
BUYSHOPITEM_SHOP_FIELD.default_value = nil
BUYSHOPITEM_SHOP_FIELD.message_type = role_pb.SHOPITEM
BUYSHOPITEM_SHOP_FIELD.type = 11
BUYSHOPITEM_SHOP_FIELD.cpp_type = 10

BUYSHOPITEM_CARD_FIELD.name = "card"
BUYSHOPITEM_CARD_FIELD.full_name = ".BuyShopItem.card"
BUYSHOPITEM_CARD_FIELD.number = 2
BUYSHOPITEM_CARD_FIELD.index = 1
BUYSHOPITEM_CARD_FIELD.label = 3
BUYSHOPITEM_CARD_FIELD.has_default_value = false
BUYSHOPITEM_CARD_FIELD.default_value = {}
BUYSHOPITEM_CARD_FIELD.message_type = role_pb.CARD
BUYSHOPITEM_CARD_FIELD.type = 11
BUYSHOPITEM_CARD_FIELD.cpp_type = 10

BUYSHOPITEM_EQUIP_FIELD.name = "equip"
BUYSHOPITEM_EQUIP_FIELD.full_name = ".BuyShopItem.equip"
BUYSHOPITEM_EQUIP_FIELD.number = 3
BUYSHOPITEM_EQUIP_FIELD.index = 2
BUYSHOPITEM_EQUIP_FIELD.label = 3
BUYSHOPITEM_EQUIP_FIELD.has_default_value = false
BUYSHOPITEM_EQUIP_FIELD.default_value = {}
BUYSHOPITEM_EQUIP_FIELD.message_type = role_pb.EQUIP
BUYSHOPITEM_EQUIP_FIELD.type = 11
BUYSHOPITEM_EQUIP_FIELD.cpp_type = 10

BUYSHOPITEM_CURRENCY_FIELD.name = "currency"
BUYSHOPITEM_CURRENCY_FIELD.full_name = ".BuyShopItem.currency"
BUYSHOPITEM_CURRENCY_FIELD.number = 4
BUYSHOPITEM_CURRENCY_FIELD.index = 3
BUYSHOPITEM_CURRENCY_FIELD.label = 2
BUYSHOPITEM_CURRENCY_FIELD.has_default_value = false
BUYSHOPITEM_CURRENCY_FIELD.default_value = nil
BUYSHOPITEM_CURRENCY_FIELD.message_type = role_pb.CURRENCY
BUYSHOPITEM_CURRENCY_FIELD.type = 11
BUYSHOPITEM_CURRENCY_FIELD.cpp_type = 10

BUYSHOPITEM_ITEM_FIELD.name = "item"
BUYSHOPITEM_ITEM_FIELD.full_name = ".BuyShopItem.item"
BUYSHOPITEM_ITEM_FIELD.number = 5
BUYSHOPITEM_ITEM_FIELD.index = 4
BUYSHOPITEM_ITEM_FIELD.label = 3
BUYSHOPITEM_ITEM_FIELD.has_default_value = false
BUYSHOPITEM_ITEM_FIELD.default_value = {}
BUYSHOPITEM_ITEM_FIELD.message_type = role_pb.ITEM
BUYSHOPITEM_ITEM_FIELD.type = 11
BUYSHOPITEM_ITEM_FIELD.cpp_type = 10

BUYSHOPITEM.name = "BuyShopItem"
BUYSHOPITEM.full_name = ".BuyShopItem"
BUYSHOPITEM.nested_types = {}
BUYSHOPITEM.enum_types = {}
BUYSHOPITEM.fields = {BUYSHOPITEM_SHOP_FIELD, BUYSHOPITEM_CARD_FIELD, BUYSHOPITEM_EQUIP_FIELD, BUYSHOPITEM_CURRENCY_FIELD, BUYSHOPITEM_ITEM_FIELD}
BUYSHOPITEM.is_extendable = false
BUYSHOPITEM.extensions = {}

BuyShopItem = protobuf.Message(BUYSHOPITEM)
CardCarryup = protobuf.Message(CARDCARRYUP)
CardFeed = protobuf.Message(CARDFEED)
CardRankup = protobuf.Message(CARDRANKUP)
CardStarup = protobuf.Message(CARDSTARUP)
CardTakeMedal = protobuf.Message(CARDTAKEMEDAL)
CardUnionLvlup = protobuf.Message(CARDUNIONLVLUP)
ComposeEquip = protobuf.Message(COMPOSEEQUIP)
EquipConfirmRemake = protobuf.Message(EQUIPCONFIRMREMAKE)
EquipFit = protobuf.Message(EQUIPFIT)
EquipLock = protobuf.Message(EQUIPLOCK)
EquipLvlup = protobuf.Message(EQUIPLVLUP)
EquipRemake = protobuf.Message(EQUIPREMAKE)
EquipRepair = protobuf.Message(EQUIPREPAIR)
GetMailList = protobuf.Message(GETMAILLIST)
GetMailReward = protobuf.Message(GETMAILREWARD)
GetShopDetail = protobuf.Message(GETSHOPDETAIL)
PublicNote = protobuf.Message(PUBLICNOTE)
ReadMail = protobuf.Message(READMAIL)
RefreshShop = protobuf.Message(REFRESHSHOP)
SciLvlup = protobuf.Message(SCILVLUP)
SciSpeed = protobuf.Message(SCISPEED)
SelectRole = protobuf.Message(SELECTROLE)
SellEquip = protobuf.Message(SELLEQUIP)
SellItem = protobuf.Message(SELLITEM)
SkillLevelup = protobuf.Message(SKILLLEVELUP)
SkillReset = protobuf.Message(SKILLRESET)

