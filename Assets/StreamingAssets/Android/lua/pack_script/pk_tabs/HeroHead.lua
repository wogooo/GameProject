local data ={
	info={key="ID",keytype=keytype.int},
	head={"ID","Type","Skin","Note","Effect"},
	body={
		[1]={1,1,"h1","帝门传人",-1},
		[2]={2,1,"h2","雪国圣女",-1},
		[3]={3,-1,"face_1","达到无尽之域第70关解锁",-1},
		[4]={4,-1,"face_2","达到vip1解锁",-1},
		[5]={5,-1,"face_3","荣登国家君主解锁",-1},
		[6]={6,-1,"face_4","竞技场前5名解锁",-1},
		[7]={7,-1,"face_5","王者竞技前5名解锁",-1},
		[8]={8,-1,"face_6","达到凛冬之征第10关解锁",-1},
		[9]={9,2,"face_7","中秋节活动获得",-1},
		[10]={10,2,"h14","吕布头像",-1},
		[11]={11,-1,"h21","张辽头像",-1},
		[12]={12,2,"h22","赵云头像",-1},
		[13]={13,1,"h17","太史慈头像",-1},
		[14]={14,-1,"h34","孟获头像",-1},
		[15]={15,-1,"h26","李典头像",-1},
		[16]={16,1,"h27","庞德头像",-1},
		[17]={17,-1,"h29","夏侯惇头像",-1},
		[18]={18,-1,"h25","姜维头像",-1},
		[19]={19,-1,"h23","高顺头像",-1},
		[20]={20,-1,"h20","张飞头像",-1},
		[21]={21,-1,"h70","蒋钦头像",-1},
		[22]={22,-1,"h16","孙策头像",-1},
		[23]={23,2,"h10","关羽头像",-1},
		[24]={24,-1,"h15","马超头像",-1},
		[25]={25,-1,"h31","许褚头像",-1},
		[26]={26,1,"h4","马云禄头像",-1},
		[27]={27,-1,"h24","黄月英头像",-1},
		[28]={28,-1,"h13","黄忠头像",-1},
		[29]={29,-1,"h32","甄姬头像",-1},
		[30]={30,-1,"h6","大乔头像",-1},
		[31]={31,2,"h28","孙尚香头像",-1},
		[32]={32,-1,"h30","夏侯渊头像",-1},
		[33]={33,-1,"h8","貂蝉头像",-1},
		[34]={34,-1,"h9","甘宁头像",-1},
		[35]={35,-1,"h5","蔡琰头像",-1},
		[36]={36,-1,"h11","华雄头像",-1},
		[37]={37,-1,"h12","黄盖头像",-1},
		[38]={38,-1,"h19","小乔头像",-1},
		[39]={39,-1,"h18","童渊头像",-1},
		[40]={40,-1,"h7","典韦头像",-1},
		[41]={41,-1,"h35","祝融头像",-1},
		[42]={42,-1,"h3","刑天头像",-1},
		[43]={43,-1,"h33","周泰头像",-1},
		[44]={44,-1,"h59","颜良头像",-1},
		[45]={45,-1,"h52","曹仁头像",-1},
		[46]={46,-1,"h72","步练师头像",-1},
		[47]={47,-1,"h62","徐晃头像",-1},
		[48]={48,-1,"h61","张郃头像",-1},
		[49]={49,-1,"h73","彭政闵头像",-1},
		[50]={50,-1,"h77","吕蒙头像",-1},
		[51]={51,2,"h63","于禁头像",-1},
		[52]={52,-1,"h76","曹洪头像",-1},
		[53]={53,-1,"h74","马岱头像",-1},
		[54]={54,-1,"h78","韩当头像",-1},
		[55]={55,-1,"h55","管亥头像",-1},
		[56]={56,-1,"h79","左慈头像",-1},
		[57]={57,-1,"h75","廖化头像",-1},
		[58]={58,-1,"h60","文丑头像",-1},
		[59]={59,-1,"h64","魏延头像",-1},
		[60]={60,-1,"h80","关平头像",-1},
		[61]={61,-1,"h86","孙坚头像",-1},
		[62]={62,-1,"h87","曹彰头像",-1},
		[63]={63,-1,"h88","潘璋头像",-1},
		[64]={64,-1,"h92","文鸯头像",-1},
		[65]={65,-1,"h85","乐进头像",-1},
		[66]={66,-1,"h58","袁绍头像",-1},
		[67]={67,2,"h49","曹操头像",-1},
		[68]={68,-1,"h48","刘备头像",-1},
		[69]={69,-1,"h50","孙权头像",-1},
		[70]={70,2,"h96","吕玲绮头像",-1},
		[71]={71,-1,"h97","关凤头像",-1},
		[72]={72,2,"h98","张星彩头像",-1},
		[73]={73,2,"h47","张角头像",-1},
		[74]={74,2,"h46","张梁头像",-1},
		[75]={75,2,"face_8","跨海战第一赛季冠军头像",-1},
		[76]={76,2,"face_9","跨海战第一赛季亚军头像",-1},
		[77]={77,2,"face_10","跨海战第一赛纪念头像",-1},
		[78]={78,2,"h103","夏侯霸头像",-1},
		[79]={79,2,"face_11","万圣节活动获得",-1},
		[80]={80,2,"face_12","2015第二赛季冠军头像",-1},
		[81]={81,2,"face_13","2015第二赛季亚军头像",-1},
		[82]={82,2,"face_14","2015第二赛季季军头像",-1},
		[83]={83,2,"face_15","2015第二赛季纪念头像",-1},
		[84]={84,2,"face_16","圣诞节头像",-1},
		[85]={85,2,"face_17","猴年头像",-1},
		[86]={86,2,"face_18","春节纪念头像",-1},
		[87]={87,2,"face_19","卧龙诸葛",-1},
		[88]={88,2,"face_20","冢虎司马",-1},
		[89]={89,2,"face_21","江东都督",-1},
	}
}
return data
