local data ={
	info={key="ID",keytype=keytype.int},
	head={"ID","SurrenderCostID","Time","BookName2","SubType2","Num2","SuccessRate","FailChatNote","SuccessChatNote","ShifangPaid","ShifangUnpaid"},
	body={
		[1]={1,13,1,1,5,200,0,"在下家贫，上有老母，下有妻儿，此不足养也。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[2]={2,13,2,1,5,600,0,"足下厚恩，心中感念，然出生入死，吾有后顾之忧。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[3]={3,13,3,1,5,1000,100,"主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[4]={4,14,1,1,5,100,0,"蝇头小利，非吾所求，足下请回。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[5]={5,14,2,1,5,300,0,"足下招揽人才，须用真金白银。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[6]={6,14,3,1,5,500,0,"明公岂不明白重赏之下，必有勇夫的道理？","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[7]={7,14,4,1,5,900,100,"主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[8]={8,15,1,1,5,100,0,"蝇头小利，非吾所求，足下请回。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[9]={9,15,2,1,5,200,0,"我乃虎将，可敌万人，非寻常人可比。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[10]={10,15,3,1,5,300,0,"常闻明公有厚待群臣之名，不料名不副实。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[11]={11,15,4,1,5,500,0,"若主公仅有此等财力，恐怕难以平定天下。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[12]={12,15,5,1,5,700,100,"主公器宇不凡，雅量非常，吾愿以死相报。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[13]={13,23,1,1,5,200,0,"足下出手平凡，恐怕难以服众。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[14]={14,23,2,1,5,600,20,"某虽心怀天下，然家中贫寒，实在无可奈何。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[15]={15,23,3,1,5,1000,80,"明公恩德，没齿难忘，然尚需银钱，安顿家小。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[16]={16,23,4,1,5,1200,100,"主公器宇不凡，雅量非常，必成大业，吾愿以死相报。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[17]={17,24,1,1,5,100,0,"足下出手平凡，如何招揽人才？","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[18]={18,24,2,1,5,300,0,"天下群雄并起，良禽择木而栖，吾亦欲寻明主。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[19]={19,24,3,1,5,500,20,"明公有志天下，则当不吝重赏。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[20]={20,24,4,1,5,900,80,"主公求贤若渴，若能不惜财货，必能一统天下。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[21]={21,24,5,1,5,1200,100,"吾观主公出手不凡，犒赏丰厚，我必誓死相随！","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[22]={22,25,1,1,5,100,0,"人为财死，鸟为食亡，还望足下体察下情。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[23]={23,25,2,1,5,200,0,"从军征战，出生入死，实在如履薄冰。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[24]={24,25,3,1,5,300,0,"若能多加犒赏，足下何愁将士不用命？","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[25]={25,25,4,1,5,500,20,"明公博学多闻，必定知晓千金买骨的典故。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[26]={26,25,5,1,5,700,80,"明公数次招揽，颇见诚意，容我三思……","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[27]={27,25,6,1,5,1000,100,"主公真乃英雄豪杰，御下有方，我愿效犬马之劳。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[28]={28,33,1,1,5,100,0,"某非不愿出仕，足下待我太薄。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[29]={29,33,2,1,5,300,0,"明公心怀天下，为何吝惜钱财？","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[30]={30,33,3,1,5,500,100,"主公真乃英雄豪杰，御下有方，我愿效犬马之劳。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[31]={31,34,1,1,5,50,0,"某非不愿出仕，足下待我太薄。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[32]={32,34,2,1,5,150,0,"生于乱世，若不能封侯拜将，还是性命要紧。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[33]={33,34,3,1,5,250,0,"明公若不惜重金，何愁天下不定？","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[34]={34,34,4,1,5,450,100,"主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[35]={35,35,1,1,5,50,0,"在下家贫，上有老母，下有妻儿，此不足养也。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[36]={36,35,2,1,5,100,0,"不能尽忠，则当尽孝，家中无人赡养老母。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[37]={37,35,3,1,5,150,0,"素知明公仁厚，必肯接济。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[38]={38,35,4,1,5,250,0,"明公屡次重赏，足见诚意，容我三思……","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[39]={39,35,5,1,5,350,100,"主公如此器重，解难纾困，我愿报答恩德。","主公如此器重，解难纾困，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[40]={40,43,1,1,5,20,50,"跟随旧主已久，不忍背弃。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[41]={41,43,2,1,5,50,50,"足下招募降将，需备重赏，以安其心。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[42]={42,43,3,1,5,80,50,"明公若肯厚待吾之旧部，定然相从。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[43]={43,43,4,1,5,120,100,"主公如此仁厚，不计前嫌，我愿报答恩德。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[44]={44,46,1,1,5,20,20,"旗下旧部甚多，不忍离弃。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[45]={45,46,2,1,5,50,30,"足下若有志天下，必定胸襟开阔，肯容我旧部。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[46]={46,46,3,1,5,80,40,"明公真乃豪杰，可否借我银钱，安顿旧部？","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[47]={47,46,4,1,5,120,50,"若明公供给资财，我必能招降旧部兵马。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[48]={48,46,5,1,5,180,60,"主公恩德，没齿难忘，但人马较多，尚需经费。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[49]={49,46,6,1,5,260,100,"主公如此仁厚，不计前嫌，我愿报答恩德。","主公如此仁厚，不计前嫌，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[50]={50,113,1,1,5,600,0,"忠臣不事二主，足下请回吧！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[51]={51,113,2,1,5,1800,0,"明公若有志安定天下，吾方肯跟随。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[52]={52,113,3,1,5,3000,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[53]={53,114,1,1,5,300,0,"阵前归降，恐为天下笑。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[54]={54,114,2,1,5,900,0,"我出生入死，只为安定天下，不知足下是否肯慷慨解囊。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[55]={55,114,3,1,5,1500,0,"明公既有志安定天下，定明白财散人聚，财聚人散。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[56]={56,114,4,1,5,2700,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[57]={57,115,1,1,5,300,0,"大丈夫宁临阵战死，岂可归降而苟活？","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[58]={58,115,2,1,5,600,0,"昔日陈平降高祖，为天下大业也，足下比高祖如何？","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[59]={59,115,3,1,5,900,0,"若明公能尽我之才，委以重任，必当相从。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[60]={60,115,4,1,5,1500,0,"高祖拜韩信为将，宠遇过人，主公可效仿。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[61]={61,115,5,1,5,2100,100,"主公待我如国士，我必以国士报之！","主公待我如国士，我必以国士报之！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[62]={62,123,1,1,5,600,0,"不忠不孝，如何立于天地间？","主公待我如国士，我必以国士报之！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[63]={63,123,2,1,5,1800,20,"不能尽忠，则当尽孝，家中无人赡养老母。","主公待我如国士，我必以国士报之！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[64]={64,123,3,1,5,3000,80,"阁下厚恩，心中感念，然我与母亲相依为命。","主公待我如国士，我必以国士报之！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[65]={65,123,4,1,5,3600,100,"主公仁厚，解难纾困，我誓死相随！","主公待我如国士，我必以国士报之！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[66]={66,124,1,1,5,300,0,"某少事我主，誓同生死；皇天后土，实如斯言。","主公待我如国士，我必以国士报之！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[67]={67,124,2,1,5,900,0,"人生在世，非只有名利二字。","主公待我如国士，我必以国士报之！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[68]={68,124,3,1,5,1500,20,"成就大业者，必有容人之雅量，明公能容我旧部否？","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[69]={69,124,4,1,5,2700,80,"明公气魄，甚是佩服，然尚需钱财，安顿旧部。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[70]={70,124,5,1,5,3600,100,"主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[71]={71,125,1,1,5,300,0,"汝等欲陷我于不义耶？","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[72]={72,125,2,1,5,600,0,"君恩虽厚，旧义难忘！","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[73]={73,125,3,1,5,900,0,"屡受足下重赏，于心有愧。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[74]={74,125,4,1,5,1500,20,"吾自飘零江湖，未遇明主，不知足下如何？","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[75]={75,125,5,1,5,2100,80,"明公有安定天下之志，则需不惜钱财，方可得人才。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[76]={76,125,6,1,5,3000,100,"主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[77]={77,133,1,1,5,300,0,"忠臣不事二主，足下请回吧！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[78]={78,133,2,1,5,900,0,"明公虽有安天下之志，未闻实力如何？","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[79]={79,133,3,1,5,1500,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[80]={80,134,1,1,5,150,0,"大丈夫宁临阵战死，不可归降而苟活。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[81]={81,134,2,1,5,450,0,"不忠不孝，如何立于天地间？","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[82]={82,134,3,1,5,750,0,"自古忠孝不能两全，还望明公见谅。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[83]={83,134,4,1,5,1350,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[84]={84,135,1,1,5,150,0,"汝等欲陷我于不义耶？","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[85]={85,135,2,1,5,300,0,"人生在世，非只有名利二字。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[86]={86,135,3,1,5,450,0,"足下厚恩，心中感念，然旧主亦待我不薄。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[87]={87,135,4,1,5,750,0,"吾何尝不知明公心意，容我三思。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[88]={88,135,5,1,5,1050,100,"主公恩德，没齿难忘，我当鞠躬尽瘁，死而后已。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[89]={89,143,1,1,5,60,50,"旧主待我不薄，不忍弃之。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[90]={90,143,2,1,5,150,50,"我征战多年，旧部颇多，尚需安置。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[91]={91,143,3,1,5,240,50,"若明公肯慷慨解囊，收留旧部，必定誓死相随。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[92]={92,143,4,1,5,360,100,"主公恩德，没齿难忘，我当鞠躬尽瘁，死而后已。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[93]={93,213,1,1,5,400,0,"我已决意归隐，不复征战。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[94]={94,213,2,1,5,1200,0,"足下厚恩，心中感念，然上有老母，下有妻儿，此不足养也。","主公恩德，没齿难忘，必当效鞍马之力，澄清天下！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[95]={95,213,3,1,5,2000,100,"主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[96]={96,214,1,1,5,200,0,"我已厌倦厮杀，希望安享富贵。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[97]={97,214,2,1,5,600,0,"足下出手平凡，如何招揽人才？","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[98]={98,214,3,1,5,1000,0,"明公重赏，我心感激，但归隐之心仍在。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[99]={99,214,4,1,5,1800,100,"主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[100]={100,215,1,1,5,200,0,"蝇头小利，非吾所求，我欲归隐山林，不复为官。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[101]={101,215,2,1,5,400,0,"我乃虎将，可敌万人，非寻常人可比。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[102]={102,215,3,1,5,600,0,"若足下仅有此等财力，如何平定天下？","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[103]={103,215,4,1,5,1000,0,"重赏之下，方有勇夫。明公赏赐尚不足。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[104]={104,215,5,1,5,1400,100,"主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[105]={105,223,1,1,5,400,0,"此地一别，我便隐居乡里，从此不再为官。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[106]={106,223,2,1,5,1200,20,"不能尽忠，则当尽孝，老母年迈，吾当养之。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[107]={107,223,3,1,5,2000,80,"明公厚恩，心中感念，然我若出山，老母无人赡养。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[108]={108,223,4,1,5,2400,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[109]={109,224,1,1,5,200,0,"大丈夫宁临阵战死，岂可归降而苟活？","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[110]={110,224,2,1,5,600,0,"阵前归降，恐为天下笑，请足下容我归隐，不复征战。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[111]={111,224,3,1,5,1000,20,"为天下大义，吾方肯归顺，不然请容我退隐。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[112]={112,224,4,1,5,1800,80,"明公若有志安定天下，则需明白千金买骨的道理。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[113]={113,224,5,1,5,2400,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[114]={114,225,1,1,5,200,0,"我已厌倦厮杀，希望归隐山林，安享富贵。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[115]={115,225,2,1,5,400,0,"天下群雄并起，良禽择木而栖，足下为明主乎？","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[116]={116,225,3,1,5,600,0,"重赏之下，方有勇夫。明公赏赐尚不足。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[117]={117,225,4,1,5,1000,20,"明公出手平凡，如何招揽人才？","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[118]={118,225,5,1,5,1400,80,"主公屡次重赏，雅量过人，且容我三思……","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[119]={119,225,6,1,5,2000,100,"主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[120]={120,233,1,1,5,200,0,"忠臣不事二主，我已决意归隐，足下请回吧！","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[121]={121,233,2,1,5,600,0,"不能尽忠，则当尽孝，我若出山，家中无人赡养老母。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[122]={122,233,3,1,5,1000,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[123]={123,234,1,1,5,100,0,"我还是隐居乡里，方可忠孝两全，从此不再为官。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[124]={124,234,2,1,5,300,0,"不能尽忠，则当尽孝，我若出山，家中无人赡养老母。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[125]={125,234,3,1,5,500,0,"明公志向令人钦佩，还需明白财散人聚的道理。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[126]={126,234,4,1,5,900,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[127]={127,235,1,1,5,100,0,"蝇头小利，非吾所求，我欲归隐山林，不复为官。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[128]={128,235,2,1,5,200,0,"我乃虎将，可敌万人，非寻常人可比。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[129]={129,235,3,1,5,300,0,"若足下仅有此等财力，如何平定天下？","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[130]={130,235,4,1,5,500,0,"明公志向令人钦佩，定明白财散人聚的道理。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[131]={131,235,5,1,5,700,100,"主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公如此器重，犒赏丰厚，我愿效犬马之劳。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[132]={132,243,1,1,5,40,50,"我还是隐居乡里，方可忠孝两全，从此不再为官。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[133]={133,243,2,1,5,100,50,"吾亦不是全无功名之心，奈何忠孝不能两全。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[134]={134,243,3,1,5,160,50,"明公若能替我赡养家人，必当相随。","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[135]={135,243,4,1,5,240,100,"主公高义！在下誓死相随！","主公高义！在下誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[136]={136,1008,1,1,5,200,0,"陷阵杀敌，马革裹尸，为将本分，休要再劝。","今当从主公征战，一展平生所学！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[137]={137,1008,2,1,5,400,0,"吾虽跟从丁原、董卓、吕布，然从未阵前归降。","今当从主公征战，一展平生所学！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[138]={138,1008,3,1,5,600,0,"吕布已为三姓家奴，我再从阁下，岂非再添一姓？","今当从主公征战，一展平生所学！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[139]={139,1008,4,1,5,1000,0,"足下若收我为将，不怕吓到小孩吗？","今当从主公征战，一展平生所学！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[140]={140,1008,5,1,5,1400,20,"明公贤明，似乎远胜旧主，容我三思……","今当从主公征战，一展平生所学！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[141]={141,1008,6,1,5,2000,40,"我已跟从数主，又为降将，恐不被信重","今当从主公征战，一展平生所学！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[142]={142,1008,7,1,5,2600,100,"今当从主公征战，一展平生所学！","今当从主公征战，一展平生所学！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[143]={143,1020,1,1,5,200,0,"吾乃威震华夏之关云长是也！岂肯降汝？","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[144]={144,1020,2,1,5,400,0,"要我降，先问问这偃月刀答不答应！","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[145]={145,1020,3,1,5,600,0,"我若降汝，有何面目见大哥、三弟？","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[146]={146,1020,4,1,5,1000,0,"足下待我虽厚，但我誓与大哥同生共死。","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[147]={147,1020,5,1,5,1400,0,"吾劝足下早回，当年颜良欲招降我，被一刀斩于马下。","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[148]={148,1020,6,1,5,2000,0,"昔日吾暂从曹操，后来斩关夺将，又投奔大哥去也","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[149]={149,1020,7,1,5,3000,0,"曹操赏金万两，封我汉寿亭侯，仍不敌大哥情义","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[150]={150,1020,8,1,5,4000,0,"大哥，三弟尚在，不忍弃之","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[151]={151,1020,9,1,5,5000,0,"若足下能兴复汉室，讨灭曹贼，于愿足矣。","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[152]={152,1020,10,1,5,6000,0,"明公有志匡扶天下，若能将我兄弟接来，方可效命。","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[153]={153,1020,11,1,5,7000,0,"明公之情义，关某心领，然不能与兄弟齐聚，则恕难从命。","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[154]={154,1020,12,1,5,8000,20,"主公若能备下重金，我可做说客，说服大哥、三弟。","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[155]={155,1020,13,1,5,9000,40,"若主公诚意更足，关某虽不才，必能使兄弟共同效力。","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[156]={156,1020,14,1,5,10000,100,"听主公一席话，关某茅塞顿开，今为天下大义相从，必替主公劝我大哥、三弟来归。","听主公一席话，关某茅塞顿开，今为天下大义相从，改日必当替主公劝服我大哥、三弟来归。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[157]={157,1021,1,1,5,100,0,"家族灭门，超不肯独活于世。","国仇家恨，系于曹贼一身。超虽不才，亦有所愿。一报仇雪恨，告慰家族英灵。一匡扶汉室，扫除汉贼。今当誓死报效主公。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[158]={158,1021,2,1,5,200,10,"阖族老少百余口，皆为超所害，只求速死","国仇家恨，系于曹贼一身。超虽不才，亦有所愿。一报仇雪恨，告慰家族英灵。一匡扶汉室，扫除汉贼。今当誓死报效主公。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[159]={159,1021,3,1,5,300,20,"老父被害，超为不孝，岂敢谋取功名利禄？","国仇家恨，系于曹贼一身。超虽不才，亦有所愿。一报仇雪恨，告慰家族英灵。一匡扶汉室，扫除汉贼。今当誓死报效主公。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[160]={160,1021,4,1,5,500,30,"曹操实为汉贼，与我有不共戴天之仇，明公若能扫灭曹操，我方肯跟随","国仇家恨，系于曹贼一身。超虽不才，亦有所愿。一报仇雪恨，告慰家族英灵。一匡扶汉室，扫除汉贼。今当誓死报效主公。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[161]={161,1021,5,1,5,700,40,"我与曹贼势不两立，明公若能提供资财，孟起定能招兵买马，扫清曹贼。","国仇家恨，系于曹贼一身。超虽不才，亦有所愿。一报仇雪恨，告慰家族英灵。一匡扶汉室，扫除汉贼。今当誓死报效主公。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[162]={162,1021,6,1,5,1000,50,"若主公肯多出银钱，为马家报仇，孟起必誓死相随。","国仇家恨，系于曹贼一身。超虽不才，亦有所愿。一报仇雪恨，告慰家族英灵。一匡扶汉室，扫除汉贼。今当誓死报效主公。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[163]={163,1021,7,1,5,1300,100,"国仇家恨，系于曹贼一身。超虽不才，今当誓死报效主公。","国仇家恨，系于曹贼一身。超虽不才，亦有所愿。一报仇雪恨，告慰家族英灵。一匡扶汉室，扫除汉贼。今当誓死报效主公。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[164]={164,1025,1,1,5,100,0,"恨不能沙场战死！岂肯从贼？","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[165]={165,1025,2,1,5,200,0,"贼子休言，吾意已决！","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[166]={166,1025,3,1,5,300,0,"老夫征战一生，只求速死！","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[167]={167,1025,4,1,5,500,0,"休要劝我，忠臣不事二主！","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[168]={168,1025,5,1,5,700,0,"吾已年老，无能为也，阁下请回吧。","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[169]={169,1025,6,1,5,1000,0,"老夫年迈，何用于阁下？","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[170]={170,1025,7,1,5,1500,0,"阁下厚意，我心领了，恕不能从命","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[171]={171,1025,8,1,5,2000,0,"旧主韩玄待我虽薄，不忍弃之","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[172]={172,1025,9,1,5,2500,20,"廉颇老矣","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[173]={173,1025,10,1,5,3000,30,"我名忠，字汉升，当以恢复汉室为己任","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[174]={174,1025,11,1,5,3500,40,"若阁下以平定天下，匡扶汉室为己任，我方可效命","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[175]={175,1025,12,1,5,4000,50,"吾虽老，手中宝刀、硬弓却不老","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[176]={176,1025,13,1,5,4500,60,"阁下若为真英雄，我必当皓首从军，报效国家","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[177]={177,1025,14,1,5,5000,100,"戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","戎马一生，未遇明主。今见主公，诚为幸事。吾虽年迈，尤怀壮志。必当肝脑涂地，马革裹尸，以报知遇之恩。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[178]={178,1026,1,1,5,100,0,"妾身一介女流，不通军事，足下请回。","主公若能以诚相待，妾身必以一生相报","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[179]={179,1026,2,1,5,200,30,"妾身生于乱世，屡遭流离，只愿平静生活，不愿厮杀。","主公若能以诚相待，妾身必以一生相报","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[180]={180,1026,3,1,5,300,40,"曹丕始乱终弃，妾身哀莫大于心死，足下莫劝。","主公若能以诚相待，妾身必以一生相报","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[181]={181,1026,4,1,5,500,50,"明公帐下良将千员，怕不需要妾身吧？","主公若能以诚相待，妾身必以一生相报","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[182]={182,1026,5,1,5,700,60,"明公屡次重赏，妾身惶恐，恕不敢当。","主公若能以诚相待，妾身必以一生相报","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[183]={183,1026,6,1,5,1000,70,"主公真乃英雄！若能赐下银钱，妾身当一改红妆，戎装上阵。","主公若能以诚相待，妾身必以一生相报","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[184]={184,1026,7,1,5,1300,100,"主公若能以诚相待，妾身必当巾帼不让须眉。","主公若能以诚相待，妾身必以一生相报","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[185]={185,1035,1,1,5,50,0,"东吴男儿皆血性方刚，妾身虽女流，亦不落下风","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[186]={186,1035,2,1,5,100,0,"家父乃庐江乔氏，岂是这等金钱所能收买？","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[187]={187,1035,3,1,5,150,0,"休要劝我，忠臣不事二主，烈女不从二夫。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[188]={188,1035,4,1,5,200,0,"妾身一介女流，怕不能当此重任。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[189]={189,1035,5,1,5,250,0,"公瑾离我而去，妾身不愿独活。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[190]={190,1035,6,1,5,300,0,"足下太小瞧我江东女子的眼界了。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[191]={191,1035,7,1,5,350,0,"足下若能得江东民心，妾身自然愿降。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[192]={192,1035,8,1,5,400,0,"妾身虽在深闺，也常闻明公待人豪爽，不料出手如此平凡。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[193]={193,1035,9,1,5,450,0,"明公若能厚待我家人，妾身当不辞万死相随。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[194]={194,1035,10,1,5,500,10,"我与大乔姐妹情深，不知明公可曾打探她的下落？","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[195]={195,1035,11,1,5,550,20,"若是明公让我姐妹重聚，妾身自然效命。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[196]={196,1035,12,1,5,600,30,"主公待我恩同再造，可否容我安顿家人，去去就回？","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[197]={197,1035,13,1,5,650,40,"主公若能备下重金，差人与我，或可寻回我姐姐大乔。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[198]={198,1035,14,1,5,700,100,"主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公高义，小乔虽一介女流，亦愿为大业出一份力。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[199]={199,1036,1,1,5,200,0,"欲平定天下可找老夫的弟子张绣。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[200]={200,1036,2,1,5,400,0,"欲平定天下可找老夫的弟子张任。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[201]={201,1036,3,1,5,600,0,"欲平定天下可找老夫的弟子赵云。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[202]={202,1036,4,1,5,1000,0,"足下为何不找我那几个弟子？","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[203]={203,1036,5,1,5,1400,0,"足下不找我的弟子也罢，犬子童飞亦颇通枪法。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[204]={204,1036,6,1,5,2000,0,"足下何故不爱年轻壮士，要找我这老头呢？","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[205]={205,1036,7,1,5,3000,0,"足下何故非要和我这老头过不去呢？","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[206]={206,1036,8,1,5,4000,0,"我早已归隐，不问世事。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[207]={207,1036,9,1,5,5000,0,"小隐隐于野，大隐隐于市，早知该去洛阳。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[208]={208,1036,10,1,5,7000,0,"天下是年轻人的，老夫已不中用。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[209]={209,1036,11,1,5,9000,0,"老夫衰朽，枪法不及当年十一。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[210]={210,1036,12,1,5,11000,0,"若是明公识得我弟子，必知青出于蓝而胜于蓝。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[211]={211,1036,13,1,5,13000,0,"老夫年事已高，实在力不从心啊。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[212]={212,1036,14,1,5,15000,10,"明公屡次相请，礼遇备至，但老夫气力不济。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[213]={213,1036,15,1,5,17000,20,"明公慧眼识人，可惜晚生数十年。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[214]={214,1036,16,1,5,19000,30,"明公资财如此丰厚，足可招致我三大弟子。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[215]={215,1036,17,1,5,21000,40,"明公财力富甲天下，但好钢该用在刀刃上。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[216]={216,1036,18,1,5,23000,50,"明公虽乃陶朱公在世，亦不可如此虚掷银钱。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[217]={217,1036,19,1,5,25000,60,"明公财富无人可敌，纵然良将千员，也已招致麾下。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[218]={218,1036,20,1,5,27000,70,"主公何必如此固执，我虽出山，寿已不久。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[219]={219,1036,21,1,5,29000,80,"主公虽不嫌弃老朽，但我实在不值如此耗费。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[220]={220,1036,22,1,5,31000,100,"主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公为老夫耗费巨大，老夫不忍拒绝，必誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[221]={221,1039,1,1,5,50,0,"哼，今番败仗，是汝等耍诈，怎可降汝？","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[222]={222,1039,2,1,5,100,0,"汝等中原人，诡计百端，必定有诈。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[223]={223,1039,3,1,5,150,0,"看汝油头粉面，心眼不少，不敢从命。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[224]={224,1039,4,1,5,200,0,"我们部落只服勇者，凭阴谋算不得本事。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[225]={225,1039,5,1,5,250,0,"汝不知我南中之人喜好白银？","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[226]={226,1039,6,1,5,300,20,"嗯，看汝行事，倒是个实诚人，可惜财力不够。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[227]={227,1039,7,1,5,350,30,"汝若非敌人，倒与我等颇为投缘，可惜可惜。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[228]={228,1039,8,1,5,400,40,"我看汝倒全无中原人习气，何不入赘我南中？","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[229]={229,1039,9,1,5,450,50,"哎，可惜你一条英雄好汉，不能与我并肩作战。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[230]={230,1039,10,1,5,500,60,"恩公待我真是有情有义，但我南中部落众多，尚需安抚。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[231]={231,1039,11,1,5,550,70,"恩公不知我南中情况，部落间互不统属，非我一人能控制。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[232]={232,1039,12,1,5,600,80,"恩公肯多出银两，我必能说服他们来降。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[233]={233,1039,13,1,5,650,90,"若恩公实力更强就好了，必能收服各部落。","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[234]={234,1039,14,1,5,700,100,"主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公实力雄厚，真乃英雄豪杰，我愿誓死相随！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[235]={235,1057,1,1,5,50,0,"区区小利，焉能诱我魏文长？","主公厚恩，必扫清天下相报！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[236]={236,1057,2,1,5,100,0,"刘将军拔我于小兵之中，不敢相负","主公厚恩，必扫清天下相报！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[237]={237,1057,3,1,5,150,0,"魏某出身寒微，不堪重任，足下请回","主公厚恩，必扫清天下相报！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[238]={238,1057,4,1,5,200,0,"吾亦有志一展平生所学，奈何不受重用","主公厚恩，必扫清天下相报！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[239]={239,1057,5,1,5,250,0,"明公若肯委我重任，必当效力","主公厚恩，必扫清天下相报！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[240]={240,1057,6,1,5,300,0,"明公之重赏，方能显示诚意","主公厚恩，必扫清天下相报！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[241]={241,1057,7,1,5,350,0,"主公屡次重赏，足见诚意，容魏某三思","主公厚恩，必扫清天下相报！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[242]={242,1057,8,1,5,400,100,"主公厚恩，必扫清天下相报！","主公厚恩，必扫清天下相报！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[243]={243,1059,1,1,5,200,0,"汝视我孙文台为何物耶？","主公高义，请让我孙坚来助一臂之力！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[244]={244,1059,2,1,5,300,0,"我堂堂长沙太守，乃朝廷命官，岂肯从贼？","主公高义，请让我孙坚来助一臂之力！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[245]={245,1059,3,1,5,400,0,"足下虽非凡人，但我心意已决，恕难从命。","主公高义，请让我孙坚来助一臂之力！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[246]={246,1059,4,1,5,500,0,"我出仕为官，非为一家一姓，实为万民。","主公高义，请让我孙坚来助一臂之力！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[247]={247,1059,5,1,5,600,0,"如讨伐董卓，乃为百姓，虽万死不辞。","主公高义，请让我孙坚来助一臂之力！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[248]={248,1059,6,1,5,700,0,"明公若有爱民之心，孙某敢不从命？","主公高义，请让我孙坚来助一臂之力！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[249]={249,1059,7,1,5,800,50,"主公之志，文台已知晓。江东健儿随我征战多年，辛苦非常，尚需安置。","主公高义，请让我孙坚来助一臂之力！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[250]={250,1059,8,1,5,1000,100,"主公高义，请让我孙坚来助一臂之力！","主公高义，请让我孙坚来助一臂之力！","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[251]={251,1068,1,1,5,150,0,"家父威名震天下，我岂可降汝？","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[252]={252,1068,2,1,5,300,0,"我绝不可让吕氏一门受辱！","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[253]={253,1068,3,1,5,450,0,"我随父亲四处征战，早已淡看生死。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[254]={254,1068,4,1,5,750,0,"足下不必多言，吾意已决。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[255]={255,1068,5,1,5,1050,0,"虎父无犬女，足下请回吧。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[256]={256,1068,6,1,5,1500,0,"足下虽屡次相劝，但恕玲绮不能从命。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[257]={257,1068,7,1,5,2250,10,"若是明公能告知家父下落，玲绮可以考虑效力。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[258]={258,1068,8,1,5,3000,20,"明公心胸开阔，非常人可比，不知能容家父否？","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[259]={259,1068,9,1,5,3750,30,"家父之名声，我也曾有耳闻，恐不受信重。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[260]={260,1068,10,1,5,4500,40,"请恕玲绮无礼，焉知明公非口是心非之辈？","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[261]={261,1068,11,1,5,5250,50,"明公屡次重赏，玲绮深知心意，还望多赐银钱，令我寻找父亲下落。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[262]={262,1068,12,1,5,6000,60,"主公高义，若能令我父女团聚，必当相随。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[263]={263,1068,13,1,5,6750,70,"屡受主公恩德，但所需银两尚有不足，实在惭愧。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[264]={264,1068,14,1,5,7500,100,"主公恩德，无以为报，玲绮愿誓死相随。","主公恩德，无以为报，玲绮愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[265]={265,999,1,1,5,100,0,"这点赏赐，实在可笑之极","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[266]={266,999,2,1,5,500,0,"蝇头小利，不足挂齿！","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[267]={267,999,3,1,5,1000,0,"当年虎牢关大战刘关张，不落下风，岂可轻易降汝？","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[268]={268,999,4,1,5,2000,0,"吾乃堂堂温侯，享尽人间富贵，非尔所能收买。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[269]={269,999,5,1,5,5000,0,"董卓虽待我如家奴，但赏赐丰厚，不曾亏待。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[270]={270,999,6,1,5,10000,0,"吾杀董卓，非为一己私利，莫要另眼看人。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[271]={271,999,7,1,5,20000,0,"若无重金厚赏，我吕奉先如何服众？","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[272]={272,999,8,1,5,30000,0,"招贤纳士，各取所需，布所求无非钱财而已。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[273]={273,999,9,1,5,40000,0,"征战沙场多年，两次背弃旧主，非我本意明公肯不弃否？","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[274]={274,999,10,1,5,50000,0,"承蒙明公不弃，屡次重赏，容布三思。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[275]={275,999,11,1,5,60000,0,"布贪念财货，以示无二心，还望明公见谅","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[276]={276,999,12,1,5,70000,0,"高顺等部下不离不弃，我于心有愧，尚需银钱，安顿旧部。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[277]={277,999,13,1,5,80000,0,"吾当年逐鹿天下，实在不知天高地厚，如今只欲富贵。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[278]={278,999,14,1,5,90000,0,"征战沙场多年，两次背弃旧主，非我本意，明公肯不弃否？","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[279]={279,999,15,1,5,100000,0,"高顺等部下不离不弃，我于心有愧，尚需银钱，安顿旧部。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[280]={280,999,16,1,5,110000,0,"布知此为不情之请，还望主公能再赐财帛。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
		[281]={281,999,17,1,5,500000,100,"主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公对布推心置腹，以诚相待，不吝重赏，在下愿誓死相随。","主公已费重金，此时离去，岂不可惜？","主公尚未出银两，何不一试？"},
	}
}
return data
