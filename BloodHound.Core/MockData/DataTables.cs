using System.Collections.Generic;

namespace BloodHound.Core.MockData
{
    public static class MockData
    {
        public static Dictionary<string, string> StoredProcedures => new Dictionary<string, string>
        {
           #region MXP Contacts Details
		 {
                "sharepoint.GetContactDetails","[\n\t{\n\t\t\"charge_cust\": 79237,\n\t\t\"cust_no\": 110192,\n\t\t\"contact\": \"Amos S. Mcleod\",\n\t\t\"telephone\": \"(0112) 082 3760\",\n\t\t\"mobile\": \"(0181) 027 6778\",\n\t\t\"email_add\": \"enim.Curabitur@nisinibhlacinia.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 77308,\n\t\t\"cust_no\": 133302,\n\t\t\"contact\": \"Jordan B. Little\",\n\t\t\"telephone\": \"(0110) 513 3778\",\n\t\t\"mobile\": \"076 7721 7010\",\n\t\t\"email_add\": \"et.netus.et@antedictum.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 142728,\n\t\t\"cust_no\": 87930,\n\t\t\"contact\": \"Bianca Morton\",\n\t\t\"telephone\": \"0305 602 1209\",\n\t\t\"mobile\": \"055 3782 9754\",\n\t\t\"email_add\": \"gravida.sagittis@nasceturridiculus.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 74990,\n\t\t\"cust_no\": 101071,\n\t\t\"contact\": \"Germane G. Terry\",\n\t\t\"telephone\": \"056 8121 9471\",\n\t\t\"mobile\": \"0840 153 2600\",\n\t\t\"email_add\": \"sodales@Cras.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 22386,\n\t\t\"cust_no\": 147147,\n\t\t\"contact\": \"Zelda T. Pace\",\n\t\t\"telephone\": \"0800 362 1937\",\n\t\t\"mobile\": \"070 9372 1720\",\n\t\t\"email_add\": \"vel.vulputate@fringillami.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 52419,\n\t\t\"cust_no\": 148204,\n\t\t\"contact\": \"Amena Crawford\",\n\t\t\"telephone\": \"(01967) 01747\",\n\t\t\"mobile\": \"0800 304 2628\",\n\t\t\"email_add\": \"nisi.nibh@convallis.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 199811,\n\t\t\"cust_no\": 166446,\n\t\t\"contact\": \"Reagan E. Boyle\",\n\t\t\"telephone\": \"(027) 3693 4807\",\n\t\t\"mobile\": \"(016977) 1397\",\n\t\t\"email_add\": \"Nam@Fusce.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 198656,\n\t\t\"cust_no\": 28567,\n\t\t\"contact\": \"Bertha J. Pugh\",\n\t\t\"telephone\": \"055 1404 8763\",\n\t\t\"mobile\": \"07405 689311\",\n\t\t\"email_add\": \"posuere.at@nequesed.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 111612,\n\t\t\"cust_no\": 160286,\n\t\t\"contact\": \"Ria D. Walters\",\n\t\t\"telephone\": \"056 0606 7480\",\n\t\t\"mobile\": \"0800 231811\",\n\t\t\"email_add\": \"ligula.Nullam@quistristiqueac.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 62777,\n\t\t\"cust_no\": 29800,\n\t\t\"contact\": \"Quinn S. Jacobson\",\n\t\t\"telephone\": \"0800 697 2169\",\n\t\t\"mobile\": \"(01684) 76205\",\n\t\t\"email_add\": \"dictum.augue@sitamet.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 114448,\n\t\t\"cust_no\": 198096,\n\t\t\"contact\": \"Channing N. Hahn\",\n\t\t\"telephone\": \"076 8304 3366\",\n\t\t\"mobile\": \"0929 829 3079\",\n\t\t\"email_add\": \"enim.gravida@Aliquameratvolutpat.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 117156,\n\t\t\"cust_no\": 28767,\n\t\t\"contact\": \"Reagan O. Shields\",\n\t\t\"telephone\": \"(01844) 97953\",\n\t\t\"mobile\": \"07624 860071\",\n\t\t\"email_add\": \"non.lacinia.at@adipiscinglacus.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 176263,\n\t\t\"cust_no\": 199997,\n\t\t\"contact\": \"Shaine Sanchez\",\n\t\t\"telephone\": \"0364 648 4049\",\n\t\t\"mobile\": \"07624 531565\",\n\t\t\"email_add\": \"gravida.Praesent.eu@sitamet.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 132143,\n\t\t\"cust_no\": 112962,\n\t\t\"contact\": \"Hamish Pickett\",\n\t\t\"telephone\": \"056 2328 9780\",\n\t\t\"mobile\": \"0800 1111\",\n\t\t\"email_add\": \"nec.malesuada.ut@Praesenteu.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 111467,\n\t\t\"cust_no\": 109486,\n\t\t\"contact\": \"Burke R. Webster\",\n\t\t\"telephone\": \"(029) 6795 5947\",\n\t\t\"mobile\": \"0373 818 0582\",\n\t\t\"email_add\": \"quis.massa.Mauris@amagna.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 96874,\n\t\t\"cust_no\": 107825,\n\t\t\"contact\": \"Cassandra Vargas\",\n\t\t\"telephone\": \"0322 937 2285\",\n\t\t\"mobile\": \"076 6102 2287\",\n\t\t\"email_add\": \"egestas.urna.justo@Vivamusnibh.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 143417,\n\t\t\"cust_no\": 188770,\n\t\t\"contact\": \"Hyatt D. Wright\",\n\t\t\"telephone\": \"0849 505 2613\",\n\t\t\"mobile\": \"0845 46 42\",\n\t\t\"email_add\": \"erat.volutpat.Nulla@ridiculusmus.ca\"\n\t},\n\t{\n\t\t\"charge_cust\": 121614,\n\t\t\"cust_no\": 148462,\n\t\t\"contact\": \"Dante Bush\",\n\t\t\"telephone\": \"070 7095 2576\",\n\t\t\"mobile\": \"(011943) 67811\",\n\t\t\"email_add\": \"ac@egestasadui.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 141960,\n\t\t\"cust_no\": 29437,\n\t\t\"contact\": \"Hammett Rocha\",\n\t\t\"telephone\": \"(01198) 065240\",\n\t\t\"mobile\": \"056 1576 0800\",\n\t\t\"email_add\": \"nunc.risus@tellus.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 136878,\n\t\t\"cust_no\": 76630,\n\t\t\"contact\": \"Sean Hyde\",\n\t\t\"telephone\": \"0800 434306\",\n\t\t\"mobile\": \"0500 781425\",\n\t\t\"email_add\": \"ornare.sagittis.felis@posuere.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 202861,\n\t\t\"cust_no\": 122635,\n\t\t\"contact\": \"Charissa D. Schroeder\",\n\t\t\"telephone\": \"(0115) 322 2694\",\n\t\t\"mobile\": \"0800 1111\",\n\t\t\"email_add\": \"sed.pede@commodo.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 142407,\n\t\t\"cust_no\": 96050,\n\t\t\"contact\": \"Kylynn Joyce\",\n\t\t\"telephone\": \"(026) 0790 7880\",\n\t\t\"mobile\": \"0800 036 2928\",\n\t\t\"email_add\": \"tristique.ac.eleifend@laciniaorciconsectetuer.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 161331,\n\t\t\"cust_no\": 31049,\n\t\t\"contact\": \"Garrison A. Humphrey\",\n\t\t\"telephone\": \"(01510) 07095\",\n\t\t\"mobile\": \"0500 336580\",\n\t\t\"email_add\": \"sodales.nisi.magna@convallisestvitae.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 172300,\n\t\t\"cust_no\": 34143,\n\t\t\"contact\": \"Eden Johnson\",\n\t\t\"telephone\": \"055 9747 4185\",\n\t\t\"mobile\": \"0845 46 42\",\n\t\t\"email_add\": \"eros.nec.tellus@Donecfeugiat.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 143378,\n\t\t\"cust_no\": 195524,\n\t\t\"contact\": \"Sebastian Rowe\",\n\t\t\"telephone\": \"076 3924 2149\",\n\t\t\"mobile\": \"055 9655 7089\",\n\t\t\"email_add\": \"a.arcu.Sed@estmaurisrhoncus.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 191603,\n\t\t\"cust_no\": 111298,\n\t\t\"contact\": \"Uriah Avila\",\n\t\t\"telephone\": \"0800 657 5925\",\n\t\t\"mobile\": \"(01106) 60485\",\n\t\t\"email_add\": \"arcu.vel.quam@orci.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 84485,\n\t\t\"cust_no\": 141317,\n\t\t\"contact\": \"Kennan P. Sims\",\n\t\t\"telephone\": \"056 2155 4467\",\n\t\t\"mobile\": \"0366 511 8443\",\n\t\t\"email_add\": \"adipiscing.Mauris.molestie@nequesed.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 178011,\n\t\t\"cust_no\": 153475,\n\t\t\"contact\": \"Briar Parker\",\n\t\t\"telephone\": \"(028) 1179 6641\",\n\t\t\"mobile\": \"070 2775 3504\",\n\t\t\"email_add\": \"libero.et@Nullamscelerisque.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 109038,\n\t\t\"cust_no\": 115084,\n\t\t\"contact\": \"Clayton Grant\",\n\t\t\"telephone\": \"0845 46 41\",\n\t\t\"mobile\": \"(01455) 00548\",\n\t\t\"email_add\": \"eu.tellus@dolor.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 134742,\n\t\t\"cust_no\": 62135,\n\t\t\"contact\": \"Marvin Rose\",\n\t\t\"telephone\": \"(016977) 9216\",\n\t\t\"mobile\": \"076 7179 3646\",\n\t\t\"email_add\": \"sagittis@Etiam.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 32264,\n\t\t\"cust_no\": 128629,\n\t\t\"contact\": \"Erasmus Z. Solis\",\n\t\t\"telephone\": \"07096 346429\",\n\t\t\"mobile\": \"070 2877 7200\",\n\t\t\"email_add\": \"vulputate@turpisegestasFusce.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 99727,\n\t\t\"cust_no\": 101859,\n\t\t\"contact\": \"Jacqueline P. Mccarty\",\n\t\t\"telephone\": \"0800 504 5039\",\n\t\t\"mobile\": \"(016977) 5862\",\n\t\t\"email_add\": \"Pellentesque@nonenimMauris.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 29202,\n\t\t\"cust_no\": 194026,\n\t\t\"contact\": \"Chloe X. Stanton\",\n\t\t\"telephone\": \"0800 1111\",\n\t\t\"mobile\": \"(0119) 835 8944\",\n\t\t\"email_add\": \"sagittis.Nullam.vitae@consectetueradipiscingelit.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 128779,\n\t\t\"cust_no\": 33184,\n\t\t\"contact\": \"Gage T. Matthews\",\n\t\t\"telephone\": \"076 5926 4986\",\n\t\t\"mobile\": \"055 0322 0648\",\n\t\t\"email_add\": \"sollicitudin.adipiscing@Nulla.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 176635,\n\t\t\"cust_no\": 29681,\n\t\t\"contact\": \"Jonah Barr\",\n\t\t\"telephone\": \"0800 060357\",\n\t\t\"mobile\": \"0800 1111\",\n\t\t\"email_add\": \"faucibus@musAeneaneget.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 21504,\n\t\t\"cust_no\": 96907,\n\t\t\"contact\": \"Gay T. Maxwell\",\n\t\t\"telephone\": \"0500 862068\",\n\t\t\"mobile\": \"0800 151970\",\n\t\t\"email_add\": \"non.magna.Nam@elementum.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 32239,\n\t\t\"cust_no\": 43062,\n\t\t\"contact\": \"Dawn C. Farrell\",\n\t\t\"telephone\": \"(01925) 04522\",\n\t\t\"mobile\": \"07752 846752\",\n\t\t\"email_add\": \"egestas@magna.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 152486,\n\t\t\"cust_no\": 85867,\n\t\t\"contact\": \"Judith Bryant\",\n\t\t\"telephone\": \"07586 731968\",\n\t\t\"mobile\": \"0923 138 5363\",\n\t\t\"email_add\": \"odio.Nam.interdum@antedictum.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 161042,\n\t\t\"cust_no\": 27132,\n\t\t\"contact\": \"Hall E. Elliott\",\n\t\t\"telephone\": \"(01080) 70027\",\n\t\t\"mobile\": \"(01810) 989031\",\n\t\t\"email_add\": \"malesuada.id@arcu.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 104390,\n\t\t\"cust_no\": 101613,\n\t\t\"contact\": \"Lionel Brooks\",\n\t\t\"telephone\": \"(0114) 663 9122\",\n\t\t\"mobile\": \"0363 688 9593\",\n\t\t\"email_add\": \"orci.Ut@aliquam.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 117462,\n\t\t\"cust_no\": 98115,\n\t\t\"contact\": \"Kermit Sargent\",\n\t\t\"telephone\": \"(01799) 19862\",\n\t\t\"mobile\": \"0800 745888\",\n\t\t\"email_add\": \"a.odio.semper@Nuncullamcorper.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 120380,\n\t\t\"cust_no\": 42887,\n\t\t\"contact\": \"Jakeem Richardson\",\n\t\t\"telephone\": \"0308 343 7304\",\n\t\t\"mobile\": \"056 8003 8688\",\n\t\t\"email_add\": \"Fusce.mi.lorem@ridiculus.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 206229,\n\t\t\"cust_no\": 115444,\n\t\t\"contact\": \"Zachary Joyner\",\n\t\t\"telephone\": \"0500 662761\",\n\t\t\"mobile\": \"0800 216 5469\",\n\t\t\"email_add\": \"nonummy.ipsum.non@Phasellusfermentumconvallis.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 144111,\n\t\t\"cust_no\": 115847,\n\t\t\"contact\": \"Thaddeus Hunter\",\n\t\t\"telephone\": \"0800 158 2178\",\n\t\t\"mobile\": \"0845 46 41\",\n\t\t\"email_add\": \"In.scelerisque@suscipitnonummy.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 31583,\n\t\t\"cust_no\": 108731,\n\t\t\"contact\": \"Wynter Coffey\",\n\t\t\"telephone\": \"0800 1111\",\n\t\t\"mobile\": \"(0116) 216 8263\",\n\t\t\"email_add\": \"vitae.sodales@Nunccommodoauctor.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 38438,\n\t\t\"cust_no\": 43984,\n\t\t\"contact\": \"Roth I. Yang\",\n\t\t\"telephone\": \"07624 074240\",\n\t\t\"mobile\": \"0847 228 6711\",\n\t\t\"email_add\": \"ipsum.cursus@Aliquamadipiscinglobortis.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 129812,\n\t\t\"cust_no\": 111932,\n\t\t\"contact\": \"Lisandra H. Frost\",\n\t\t\"telephone\": \"0800 1111\",\n\t\t\"mobile\": \"056 2856 1819\",\n\t\t\"email_add\": \"In.condimentum@dui.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 198003,\n\t\t\"cust_no\": 153375,\n\t\t\"contact\": \"Josephine J. Hurley\",\n\t\t\"telephone\": \"(016977) 6185\",\n\t\t\"mobile\": \"07624 159618\",\n\t\t\"email_add\": \"Aliquam@Fuscemollis.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 78666,\n\t\t\"cust_no\": 190845,\n\t\t\"contact\": \"Amela H. Hickman\",\n\t\t\"telephone\": \"0800 329669\",\n\t\t\"mobile\": \"(0117) 820 3736\",\n\t\t\"email_add\": \"per.inceptos@nibh.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 131800,\n\t\t\"cust_no\": 187125,\n\t\t\"contact\": \"Serina A. Bradley\",\n\t\t\"telephone\": \"0953 615 0056\",\n\t\t\"mobile\": \"0814 922 5222\",\n\t\t\"email_add\": \"turpis.egestas@mollisPhaselluslibero.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 157764,\n\t\t\"cust_no\": 47269,\n\t\t\"contact\": \"Abdul Stafford\",\n\t\t\"telephone\": \"076 8656 5305\",\n\t\t\"mobile\": \"(0171) 972 5590\",\n\t\t\"email_add\": \"ac.mattis.velit@felisNullatempor.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 191118,\n\t\t\"cust_no\": 91862,\n\t\t\"contact\": \"Iliana Bonner\",\n\t\t\"telephone\": \"056 8737 5420\",\n\t\t\"mobile\": \"055 2395 8411\",\n\t\t\"email_add\": \"pede@etmagnis.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 86371,\n\t\t\"cust_no\": 75924,\n\t\t\"contact\": \"Sopoline K. Chapman\",\n\t\t\"telephone\": \"(016977) 3642\",\n\t\t\"mobile\": \"(0110) 661 1142\",\n\t\t\"email_add\": \"quis.pede.Suspendisse@egestasAliquam.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 91336,\n\t\t\"cust_no\": 169773,\n\t\t\"contact\": \"Grady Strickland\",\n\t\t\"telephone\": \"0845 46 42\",\n\t\t\"mobile\": \"0330 488 4533\",\n\t\t\"email_add\": \"interdum@eros.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 33417,\n\t\t\"cust_no\": 23039,\n\t\t\"contact\": \"Diana Collins\",\n\t\t\"telephone\": \"076 5940 5441\",\n\t\t\"mobile\": \"(01971) 983215\",\n\t\t\"email_add\": \"dignissim.pharetra.Nam@dignissimtemporarcu.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 128955,\n\t\t\"cust_no\": 128160,\n\t\t\"contact\": \"Kyla C. Holland\",\n\t\t\"telephone\": \"(013157) 01690\",\n\t\t\"mobile\": \"07488 278256\",\n\t\t\"email_add\": \"nulla@faucibusleo.ca\"\n\t},\n\t{\n\t\t\"charge_cust\": 197106,\n\t\t\"cust_no\": 142162,\n\t\t\"contact\": \"Jerome Jenkins\",\n\t\t\"telephone\": \"0845 46 48\",\n\t\t\"mobile\": \"(025) 8357 4407\",\n\t\t\"email_add\": \"sem.ut@vitaepurus.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 145280,\n\t\t\"cust_no\": 52915,\n\t\t\"contact\": \"Colorado V. Santiago\",\n\t\t\"telephone\": \"0864 066 2046\",\n\t\t\"mobile\": \"07367 553947\",\n\t\t\"email_add\": \"pretium.neque.Morbi@ridiculusmusProin.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 180553,\n\t\t\"cust_no\": 86702,\n\t\t\"contact\": \"Lana A. Hewitt\",\n\t\t\"telephone\": \"(027) 3517 4374\",\n\t\t\"mobile\": \"0800 894206\",\n\t\t\"email_add\": \"consectetuer@lobortis.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 61488,\n\t\t\"cust_no\": 116895,\n\t\t\"contact\": \"Yuri Monroe\",\n\t\t\"telephone\": \"0800 260 8348\",\n\t\t\"mobile\": \"0300 475 0463\",\n\t\t\"email_add\": \"Donec.est@malesuadafringillaest.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 48253,\n\t\t\"cust_no\": 131434,\n\t\t\"contact\": \"Cheyenne N. Lopez\",\n\t\t\"telephone\": \"056 6144 7934\",\n\t\t\"mobile\": \"07785 983632\",\n\t\t\"email_add\": \"fames@quamdignissim.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 73422,\n\t\t\"cust_no\": 65173,\n\t\t\"contact\": \"Walter Dyer\",\n\t\t\"telephone\": \"07624 668467\",\n\t\t\"mobile\": \"(016977) 1684\",\n\t\t\"email_add\": \"adipiscing@arcu.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 123236,\n\t\t\"cust_no\": 47360,\n\t\t\"contact\": \"Merrill J. Hahn\",\n\t\t\"telephone\": \"056 4708 9252\",\n\t\t\"mobile\": \"070 5103 3287\",\n\t\t\"email_add\": \"augue@urnaVivamusmolestie.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 129982,\n\t\t\"cust_no\": 24409,\n\t\t\"contact\": \"Serina H. Roy\",\n\t\t\"telephone\": \"0845 46 46\",\n\t\t\"mobile\": \"(023) 9463 0203\",\n\t\t\"email_add\": \"mollis.nec@utaliquamiaculis.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 133900,\n\t\t\"cust_no\": 39678,\n\t\t\"contact\": \"Farrah I. Owens\",\n\t\t\"telephone\": \"07624 621516\",\n\t\t\"mobile\": \"07624 447299\",\n\t\t\"email_add\": \"est.tempor@ligulaeu.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 90401,\n\t\t\"cust_no\": 195998,\n\t\t\"contact\": \"Pascale C. Acosta\",\n\t\t\"telephone\": \"07624 762066\",\n\t\t\"mobile\": \"0845 46 42\",\n\t\t\"email_add\": \"non.enim.Mauris@purusgravidasagittis.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 107711,\n\t\t\"cust_no\": 21517,\n\t\t\"contact\": \"Zoe I. Gilbert\",\n\t\t\"telephone\": \"(015489) 35392\",\n\t\t\"mobile\": \"(029) 2300 4205\",\n\t\t\"email_add\": \"Cras.dictum@sempertellusid.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 92479,\n\t\t\"cust_no\": 170556,\n\t\t\"contact\": \"Omar L. Heath\",\n\t\t\"telephone\": \"(01872) 820543\",\n\t\t\"mobile\": \"07624 934956\",\n\t\t\"email_add\": \"fermentum@velitAliquam.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 83463,\n\t\t\"cust_no\": 154480,\n\t\t\"contact\": \"Linus Chambers\",\n\t\t\"telephone\": \"07063 290510\",\n\t\t\"mobile\": \"(01828) 63002\",\n\t\t\"email_add\": \"arcu.ac@mollisDuis.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 120235,\n\t\t\"cust_no\": 121827,\n\t\t\"contact\": \"Kristen P. Downs\",\n\t\t\"telephone\": \"056 8782 8729\",\n\t\t\"mobile\": \"(0191) 843 4398\",\n\t\t\"email_add\": \"at.fringilla@congueelit.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 62953,\n\t\t\"cust_no\": 66647,\n\t\t\"contact\": \"Christopher U. Bender\",\n\t\t\"telephone\": \"0845 46 48\",\n\t\t\"mobile\": \"056 7259 0055\",\n\t\t\"email_add\": \"dictum.mi.ac@at.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 191046,\n\t\t\"cust_no\": 160407,\n\t\t\"contact\": \"Karleigh Cline\",\n\t\t\"telephone\": \"(0112) 583 9103\",\n\t\t\"mobile\": \"076 9233 1688\",\n\t\t\"email_add\": \"et@morbitristiquesenectus.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 150458,\n\t\t\"cust_no\": 172661,\n\t\t\"contact\": \"Shea U. Finley\",\n\t\t\"telephone\": \"0845 46 45\",\n\t\t\"mobile\": \"(016977) 9633\",\n\t\t\"email_add\": \"rhoncus.id@magnisdis.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 68814,\n\t\t\"cust_no\": 150956,\n\t\t\"contact\": \"Rafael D. Peters\",\n\t\t\"telephone\": \"0845 46 42\",\n\t\t\"mobile\": \"0500 898655\",\n\t\t\"email_add\": \"id.enim@eratnonummyultricies.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 64296,\n\t\t\"cust_no\": 154782,\n\t\t\"contact\": \"Sarah T. Maldonado\",\n\t\t\"telephone\": \"(0161) 140 5475\",\n\t\t\"mobile\": \"(0115) 687 3101\",\n\t\t\"email_add\": \"molestie.arcu@eu.ca\"\n\t},\n\t{\n\t\t\"charge_cust\": 129176,\n\t\t\"cust_no\": 85097,\n\t\t\"contact\": \"Dustin Burke\",\n\t\t\"telephone\": \"(020) 6356 4582\",\n\t\t\"mobile\": \"(01754) 19279\",\n\t\t\"email_add\": \"sapien@estvitae.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 187974,\n\t\t\"cust_no\": 123575,\n\t\t\"contact\": \"Ahmed Q. Meyer\",\n\t\t\"telephone\": \"(016977) 7998\",\n\t\t\"mobile\": \"(01206) 918809\",\n\t\t\"email_add\": \"primis.in.faucibus@Phasellus.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 135680,\n\t\t\"cust_no\": 176069,\n\t\t\"contact\": \"Kadeem Ryan\",\n\t\t\"telephone\": \"0800 890 8785\",\n\t\t\"mobile\": \"(01968) 887008\",\n\t\t\"email_add\": \"mollis.Phasellus@quama.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 70742,\n\t\t\"cust_no\": 37874,\n\t\t\"contact\": \"Jayme J. Underwood\",\n\t\t\"telephone\": \"0800 1111\",\n\t\t\"mobile\": \"0911 573 3105\",\n\t\t\"email_add\": \"orci.quis@famesacturpis.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 167446,\n\t\t\"cust_no\": 49526,\n\t\t\"contact\": \"Idona Lester\",\n\t\t\"telephone\": \"0800 300566\",\n\t\t\"mobile\": \"0500 739076\",\n\t\t\"email_add\": \"nunc.id@adipiscing.ca\"\n\t},\n\t{\n\t\t\"charge_cust\": 179469,\n\t\t\"cust_no\": 198947,\n\t\t\"contact\": \"Katell Z. Ellison\",\n\t\t\"telephone\": \"(010162) 73238\",\n\t\t\"mobile\": \"0323 836 2350\",\n\t\t\"email_add\": \"sem@commodo.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 133636,\n\t\t\"cust_no\": 114954,\n\t\t\"contact\": \"Cain Hernandez\",\n\t\t\"telephone\": \"056 1170 4496\",\n\t\t\"mobile\": \"0849 704 4942\",\n\t\t\"email_add\": \"sollicitudin.adipiscing.ligula@inmagna.ca\"\n\t},\n\t{\n\t\t\"charge_cust\": 111912,\n\t\t\"cust_no\": 58598,\n\t\t\"contact\": \"Jenette M. Thompson\",\n\t\t\"telephone\": \"0800 103678\",\n\t\t\"mobile\": \"(01061) 40735\",\n\t\t\"email_add\": \"Praesent.luctus@malesuadafames.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 177162,\n\t\t\"cust_no\": 128483,\n\t\t\"contact\": \"Zeph Castro\",\n\t\t\"telephone\": \"070 7727 0885\",\n\t\t\"mobile\": \"(0131) 104 8094\",\n\t\t\"email_add\": \"ipsum.Curabitur.consequat@luctusut.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 37554,\n\t\t\"cust_no\": 52704,\n\t\t\"contact\": \"Piper G. Morrow\",\n\t\t\"telephone\": \"0377 874 0272\",\n\t\t\"mobile\": \"(01453) 521149\",\n\t\t\"email_add\": \"accumsan.sed.facilisis@litoratorquentper.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 178621,\n\t\t\"cust_no\": 37420,\n\t\t\"contact\": \"Bree L. Shields\",\n\t\t\"telephone\": \"(016977) 5710\",\n\t\t\"mobile\": \"(0151) 950 7862\",\n\t\t\"email_add\": \"odio.auctor.vitae@enimgravidasit.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 117194,\n\t\t\"cust_no\": 171221,\n\t\t\"contact\": \"Lacota Grimes\",\n\t\t\"telephone\": \"(0171) 873 9345\",\n\t\t\"mobile\": \"0800 595202\",\n\t\t\"email_add\": \"laoreet.lectus.quis@ante.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 173147,\n\t\t\"cust_no\": 70477,\n\t\t\"contact\": \"Gloria Hoover\",\n\t\t\"telephone\": \"(016977) 6070\",\n\t\t\"mobile\": \"(016977) 2446\",\n\t\t\"email_add\": \"vitae.erat.Vivamus@dolornonummy.co.uk\"\n\t},\n\t{\n\t\t\"charge_cust\": 187343,\n\t\t\"cust_no\": 41775,\n\t\t\"contact\": \"Rooney Bailey\",\n\t\t\"telephone\": \"0800 208290\",\n\t\t\"mobile\": \"0845 46 45\",\n\t\t\"email_add\": \"et.malesuada@ipsumnonarcu.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 198350,\n\t\t\"cust_no\": 170188,\n\t\t\"contact\": \"Amanda Spears\",\n\t\t\"telephone\": \"0980 354 9257\",\n\t\t\"mobile\": \"0800 1111\",\n\t\t\"email_add\": \"semper@non.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 157914,\n\t\t\"cust_no\": 98482,\n\t\t\"contact\": \"Maisie L. Bruce\",\n\t\t\"telephone\": \"(01806) 028866\",\n\t\t\"mobile\": \"(01168) 255280\",\n\t\t\"email_add\": \"et.netus@tortorInteger.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 56802,\n\t\t\"cust_no\": 69886,\n\t\t\"contact\": \"Orson Lyons\",\n\t\t\"telephone\": \"0363 320 2626\",\n\t\t\"mobile\": \"0355 458 0055\",\n\t\t\"email_add\": \"Morbi@nec.ca\"\n\t},\n\t{\n\t\t\"charge_cust\": 137512,\n\t\t\"cust_no\": 40700,\n\t\t\"contact\": \"Ivy R. Walton\",\n\t\t\"telephone\": \"(013432) 91989\",\n\t\t\"mobile\": \"0800 1111\",\n\t\t\"email_add\": \"ipsum.Donec.sollicitudin@magnaCras.org\"\n\t},\n\t{\n\t\t\"charge_cust\": 171248,\n\t\t\"cust_no\": 151855,\n\t\t\"contact\": \"Dennis French\",\n\t\t\"telephone\": \"(016977) 9639\",\n\t\t\"mobile\": \"0845 46 48\",\n\t\t\"email_add\": \"pharetra.Nam@tellus.edu\"\n\t},\n\t{\n\t\t\"charge_cust\": 105027,\n\t\t\"cust_no\": 30933,\n\t\t\"contact\": \"Carter Murphy\",\n\t\t\"telephone\": \"(0110) 002 0982\",\n\t\t\"mobile\": \"0840 556 8264\",\n\t\t\"email_add\": \"Nulla.tempor@arcu.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 166933,\n\t\t\"cust_no\": 119128,\n\t\t\"contact\": \"Vance Stephenson\",\n\t\t\"telephone\": \"0800 965 5303\",\n\t\t\"mobile\": \"076 2668 7519\",\n\t\t\"email_add\": \"lectus@morbi.ca\"\n\t},\n\t{\n\t\t\"charge_cust\": 177818,\n\t\t\"cust_no\": 195574,\n\t\t\"contact\": \"Sharon Gibbs\",\n\t\t\"telephone\": \"0981 257 9083\",\n\t\t\"mobile\": \"(025) 3882 6246\",\n\t\t\"email_add\": \"quis@magna.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 135177,\n\t\t\"cust_no\": 169940,\n\t\t\"contact\": \"Palmer Gomez\",\n\t\t\"telephone\": \"(01316) 919020\",\n\t\t\"mobile\": \"055 0003 5620\",\n\t\t\"email_add\": \"dignissim.tempor@lectus.com\"\n\t},\n\t{\n\t\t\"charge_cust\": 201421,\n\t\t\"cust_no\": 62756,\n\t\t\"contact\": \"Brody Montoya\",\n\t\t\"telephone\": \"0800 1111\",\n\t\t\"mobile\": \"0973 697 5333\",\n\t\t\"email_add\": \"Nullam.feugiat@ametloremsemper.net\"\n\t},\n\t{\n\t\t\"charge_cust\": 165260,\n\t\t\"cust_no\": 190814,\n\t\t\"contact\": \"Maggy Whitehead\",\n\t\t\"telephone\": \"0845 46 49\",\n\t\t\"mobile\": \"07297 298788\",\n\t\t\"email_add\": \"pharetra.Quisque@Integer.org\"\n\t}\n]"
            }, 
	        #endregion
           #region Mxp Customer summary
		 {
                "sharepoint.GetCustomerSummary", @"[
	                    {
		                    ""name"": ""Neque Non Quam Corp."",
		                    ""cust_no"": 133273,
		                    ""city"": ""Zwevegem"",
		                    ""zip_code"": ""W6U 7IX"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 156901,
		                    ""MCs"": 37
	                    },
	                    {
		                    ""name"": ""Tristique LLC"",
		                    ""cust_no"": 68925,
		                    ""city"": ""Manisa"",
		                    ""zip_code"": ""NA99 1MO"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 119533,
		                    ""MCs"": 9
	                    },
	                    {
		                    ""name"": ""Rutrum Non Hendrerit Corporation"",
		                    ""cust_no"": 84223,
		                    ""city"": ""Dornoch"",
		                    ""zip_code"": ""M5F 5RT"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 156347,
		                    ""MCs"": 8
	                    },
	                    {
		                    ""name"": ""Velit Aliquam Nisl PC"",
		                    ""cust_no"": 70970,
		                    ""city"": ""Orilla"",
		                    ""zip_code"": ""N1Q 6VD"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 162480,
		                    ""MCs"": 30
	                    },
	                    {
		                    ""name"": ""Felis Nulla Limited"",
		                    ""cust_no"": 127987,
		                    ""city"": ""Rionero in Vulture"",
		                    ""zip_code"": ""M4 9ED"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 59011,
		                    ""MCs"": 9
	                    },
	                    {
		                    ""name"": ""Dictum Ultricies Ligula Foundation"",
		                    ""cust_no"": 127222,
		                    ""city"": ""Nizip"",
		                    ""zip_code"": ""SR34 8MC"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 54336,
		                    ""MCs"": 49
	                    },
	                    {
		                    ""name"": ""Ipsum Institute"",
		                    ""cust_no"": 84556,
		                    ""city"": ""Esterzili"",
		                    ""zip_code"": ""Q94 3QY"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 172271,
		                    ""MCs"": 29
	                    },
	                    {
		                    ""name"": ""Elementum Incorporated"",
		                    ""cust_no"": 134918,
		                    ""city"": ""Pizzoferrato"",
		                    ""zip_code"": ""Y2 8JQ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 47003,
		                    ""MCs"": 35
	                    },
	                    {
		                    ""name"": ""Malesuada Augue Corporation"",
		                    ""cust_no"": 46423,
		                    ""city"": ""Oromocto"",
		                    ""zip_code"": ""AL5 3UI"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 182848,
		                    ""MCs"": 40
	                    },
	                    {
		                    ""name"": ""Sed Associates"",
		                    ""cust_no"": 25638,
		                    ""city"": ""Richmond Hill"",
		                    ""zip_code"": ""YR4 4XJ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 87418,
		                    ""MCs"": 21
	                    },
	                    {
		                    ""name"": ""Arcu Sed PC"",
		                    ""cust_no"": 23158,
		                    ""city"": ""Gretna"",
		                    ""zip_code"": ""T8 2TB"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 43984,
		                    ""MCs"": 23
	                    },
	                    {
		                    ""name"": ""Sit Amet Corporation"",
		                    ""cust_no"": 75512,
		                    ""city"": ""Meridian"",
		                    ""zip_code"": ""CH6 4FY"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 76370,
		                    ""MCs"": 43
	                    },
	                    {
		                    ""name"": ""Gravida Nunc Sed PC"",
		                    ""cust_no"": 154955,
		                    ""city"": ""Colorado Springs"",
		                    ""zip_code"": ""T0E 3LG"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 21522,
		                    ""MCs"": 21
	                    },
	                    {
		                    ""name"": ""Suspendisse Non Leo Limited"",
		                    ""cust_no"": 58846,
		                    ""city"": ""Fulda"",
		                    ""zip_code"": ""HK7H 2ET"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 137737,
		                    ""MCs"": 3
	                    },
	                    {
		                    ""name"": ""Sit Amet Faucibus Industries"",
		                    ""cust_no"": 144853,
		                    ""city"": ""Milford Haven"",
		                    ""zip_code"": ""E2E 2QP"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 143757,
		                    ""MCs"": 35
	                    },
	                    {
		                    ""name"": ""Id Ante LLC"",
		                    ""cust_no"": 126512,
		                    ""city"": ""Castelmezzano"",
		                    ""zip_code"": ""QO1 0TK"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 138436,
		                    ""MCs"": 32
	                    },
	                    {
		                    ""name"": ""Tempor Bibendum Inc."",
		                    ""cust_no"": 64128,
		                    ""city"": ""Holman"",
		                    ""zip_code"": ""V4 6GF"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 176775,
		                    ""MCs"": 39
	                    },
	                    {
		                    ""name"": ""Aliquet Inc."",
		                    ""cust_no"": 195514,
		                    ""city"": ""Olathe"",
		                    ""zip_code"": ""JE84 3EL"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 108575,
		                    ""MCs"": 31
	                    },
	                    {
		                    ""name"": ""Ac Feugiat Associates"",
		                    ""cust_no"": 134310,
		                    ""city"": ""Incourt"",
		                    ""zip_code"": ""N0 8RG"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 140387,
		                    ""MCs"": 48
	                    },
	                    {
		                    ""name"": ""Vel LLP"",
		                    ""cust_no"": 76581,
		                    ""city"": ""King's Lynn"",
		                    ""zip_code"": ""ZF7 7KB"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 27878,
		                    ""MCs"": 28
	                    },
	                    {
		                    ""name"": ""Est Ac Incorporated"",
		                    ""cust_no"": 172855,
		                    ""city"": ""Bolzano Vicentino"",
		                    ""zip_code"": ""F8P 9ID"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 136930,
		                    ""MCs"": 46
	                    },
	                    {
		                    ""name"": ""Volutpat Ornare PC"",
		                    ""cust_no"": 83694,
		                    ""city"": ""Montefalcone nel Sannio"",
		                    ""zip_code"": ""SH89 9TX"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 32190,
		                    ""MCs"": 44
	                    },
	                    {
		                    ""name"": ""Est Mauris Eu Consulting"",
		                    ""cust_no"": 84025,
		                    ""city"": ""Moricone"",
		                    ""zip_code"": ""P0 9HX"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 97836,
		                    ""MCs"": 14
	                    },
	                    {
		                    ""name"": ""Cum Foundation"",
		                    ""cust_no"": 20957,
		                    ""city"": ""Charlottetown"",
		                    ""zip_code"": ""KD5B 6SP"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 112207,
		                    ""MCs"": 49
	                    },
	                    {
		                    ""name"": ""Malesuada Ut Institute"",
		                    ""cust_no"": 149113,
		                    ""city"": ""Landeck"",
		                    ""zip_code"": ""G02 0FT"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 142527,
		                    ""MCs"": 44
	                    },
	                    {
		                    ""name"": ""Id Libero Corporation"",
		                    ""cust_no"": 146577,
		                    ""city"": ""Antibes"",
		                    ""zip_code"": ""W05 6QJ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 61292,
		                    ""MCs"": 22
	                    },
	                    {
		                    ""name"": ""Donec Porttitor Tellus LLC"",
		                    ""cust_no"": 178317,
		                    ""city"": ""Millet"",
		                    ""zip_code"": ""Y31 2SR"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 60614,
		                    ""MCs"": 13
	                    },
	                    {
		                    ""name"": ""Urna LLP"",
		                    ""cust_no"": 121535,
		                    ""city"": ""Tuscaloosa"",
		                    ""zip_code"": ""T6E 5QK"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 193652,
		                    ""MCs"": 18
	                    },
	                    {
		                    ""name"": ""Suspendisse Commodo Company"",
		                    ""cust_no"": 136705,
		                    ""city"": ""Ferrandina"",
		                    ""zip_code"": ""AY2Q 1JB"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 38216,
		                    ""MCs"": 13
	                    },
	                    {
		                    ""name"": ""Massa LLC"",
		                    ""cust_no"": 152049,
		                    ""city"": ""Alsemberg"",
		                    ""zip_code"": ""FI93 7LA"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 76416,
		                    ""MCs"": 18
	                    },
	                    {
		                    ""name"": ""Sapien Cras LLP"",
		                    ""cust_no"": 57075,
		                    ""city"": ""Smoky Lake"",
		                    ""zip_code"": ""J12 0WO"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 160855,
		                    ""MCs"": 47
	                    },
	                    {
		                    ""name"": ""Aliquam Tincidunt Nunc Limited"",
		                    ""cust_no"": 127142,
		                    ""city"": ""Saint-Nazaire"",
		                    ""zip_code"": ""S3 0JI"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 163123,
		                    ""MCs"": 6
	                    },
	                    {
		                    ""name"": ""Diam Corp."",
		                    ""cust_no"": 163099,
		                    ""city"": ""Reims"",
		                    ""zip_code"": ""LX3B 4CH"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 142605,
		                    ""MCs"": 47
	                    },
	                    {
		                    ""name"": ""Tortor At Company"",
		                    ""cust_no"": 68459,
		                    ""city"": ""Ross-on-Wye"",
		                    ""zip_code"": ""JW3 7NN"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 30722,
		                    ""MCs"": 48
	                    },
	                    {
		                    ""name"": ""Vehicula Aliquet Industries"",
		                    ""cust_no"": 65706,
		                    ""city"": ""Wolverhampton"",
		                    ""zip_code"": ""JY9H 2NE"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 38629,
		                    ""MCs"": 13
	                    },
	                    {
		                    ""name"": ""Mus Ltd"",
		                    ""cust_no"": 75261,
		                    ""city"": ""Kingston"",
		                    ""zip_code"": ""DR8 1GG"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 143633,
		                    ""MCs"": 41
	                    },
	                    {
		                    ""name"": ""Sapien Molestie Orci Corporation"",
		                    ""cust_no"": 154492,
		                    ""city"": ""Valtournenche"",
		                    ""zip_code"": ""OZ56 4UH"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 169319,
		                    ""MCs"": 22
	                    },
	                    {
		                    ""name"": ""Consectetuer Limited"",
		                    ""cust_no"": 78386,
		                    ""city"": ""Kansas City"",
		                    ""zip_code"": ""VJ09 1WY"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 49710,
		                    ""MCs"": 41
	                    },
	                    {
		                    ""name"": ""Aliquam Incorporated"",
		                    ""cust_no"": 158680,
		                    ""city"": ""Heule"",
		                    ""zip_code"": ""B2L 0XW"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 86678,
		                    ""MCs"": 26
	                    },
	                    {
		                    ""name"": ""Elit Incorporated"",
		                    ""cust_no"": 151068,
		                    ""city"": ""Itterbeek"",
		                    ""zip_code"": ""WB6 1LO"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 156513,
		                    ""MCs"": 4
	                    },
	                    {
		                    ""name"": ""Tempor Augue Inc."",
		                    ""cust_no"": 63734,
		                    ""city"": ""Enterprise"",
		                    ""zip_code"": ""IC62 9IX"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 133342,
		                    ""MCs"": 46
	                    },
	                    {
		                    ""name"": ""Vitae Erat Vivamus Foundation"",
		                    ""cust_no"": 113180,
		                    ""city"": ""Perwez"",
		                    ""zip_code"": ""Y44 2WQ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 123844,
		                    ""MCs"": 39
	                    },
	                    {
		                    ""name"": ""Magna LLC"",
		                    ""cust_no"": 113482,
		                    ""city"": ""Castelseprio"",
		                    ""zip_code"": ""YH10 4NH"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 126540,
		                    ""MCs"": 19
	                    },
	                    {
		                    ""name"": ""Risus Morbi Metus Limited"",
		                    ""cust_no"": 51588,
		                    ""city"": ""Waterloo"",
		                    ""zip_code"": ""H6 8NI"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 174767,
		                    ""MCs"": 23
	                    },
	                    {
		                    ""name"": ""Ac Facilisis LLC"",
		                    ""cust_no"": 118084,
		                    ""city"": ""Knittelfeld"",
		                    ""zip_code"": ""TY2 3KT"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 91599,
		                    ""MCs"": 7
	                    },
	                    {
		                    ""name"": ""Leo Associates"",
		                    ""cust_no"": 87229,
		                    ""city"": ""Kester"",
		                    ""zip_code"": ""TB6S 8YQ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 121653,
		                    ""MCs"": 23
	                    },
	                    {
		                    ""name"": ""Turpis Non Enim LLC"",
		                    ""cust_no"": 191770,
		                    ""city"": ""Dignano"",
		                    ""zip_code"": ""M20 1NY"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 118386,
		                    ""MCs"": 29
	                    },
	                    {
		                    ""name"": ""Eu Corp."",
		                    ""cust_no"": 41030,
		                    ""city"": ""Gonars"",
		                    ""zip_code"": ""OD24 3FP"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 140315,
		                    ""MCs"": 50
	                    },
	                    {
		                    ""name"": ""Sed Neque Consulting"",
		                    ""cust_no"": 111520,
		                    ""city"": ""Cobourg"",
		                    ""zip_code"": ""ZP1 1RW"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 86288,
		                    ""MCs"": 27
	                    },
	                    {
		                    ""name"": ""Nibh Inc."",
		                    ""cust_no"": 136482,
		                    ""city"": ""Sikar"",
		                    ""zip_code"": ""K4Z 1GA"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 68886,
		                    ""MCs"": 12
	                    },
	                    {
		                    ""name"": ""Non Luctus Corp."",
		                    ""cust_no"": 75274,
		                    ""city"": ""Brixton"",
		                    ""zip_code"": ""WI06 0RV"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 110159,
		                    ""MCs"": 44
	                    },
	                    {
		                    ""name"": ""Blandit Mattis Cras Industries"",
		                    ""cust_no"": 174591,
		                    ""city"": ""Sant'Egidio alla Vibrata"",
		                    ""zip_code"": ""B9L 9YT"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 141487,
		                    ""MCs"": 44
	                    },
	                    {
		                    ""name"": ""Sit Amet Metus Company"",
		                    ""cust_no"": 155369,
		                    ""city"": ""Picinisco"",
		                    ""zip_code"": ""B1 1LT"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 128821,
		                    ""MCs"": 32
	                    },
	                    {
		                    ""name"": ""Iaculis LLP"",
		                    ""cust_no"": 132369,
		                    ""city"": ""Boorsem"",
		                    ""zip_code"": ""R11 8AF"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 92226,
		                    ""MCs"": 27
	                    },
	                    {
		                    ""name"": ""Nisi Sem Semper LLC"",
		                    ""cust_no"": 167613,
		                    ""city"": ""Musson"",
		                    ""zip_code"": ""BB9Y 3OC"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 120354,
		                    ""MCs"": 41
	                    },
	                    {
		                    ""name"": ""Fusce Feugiat Institute"",
		                    ""cust_no"": 61154,
		                    ""city"": ""Luton"",
		                    ""zip_code"": ""RY59 9TB"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 193028,
		                    ""MCs"": 29
	                    },
	                    {
		                    ""name"": ""Elit Fermentum Risus Company"",
		                    ""cust_no"": 121082,
		                    ""city"": ""Baileux"",
		                    ""zip_code"": ""Y7M 4MK"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 30759,
		                    ""MCs"": 36
	                    },
	                    {
		                    ""name"": ""Enim Gravida Company"",
		                    ""cust_no"": 184479,
		                    ""city"": ""Dorgali"",
		                    ""zip_code"": ""VY95 9HN"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 168161,
		                    ""MCs"": 20
	                    },
	                    {
		                    ""name"": ""Duis Risus Incorporated"",
		                    ""cust_no"": 152063,
		                    ""city"": ""Honolulu"",
		                    ""zip_code"": ""P02 0JA"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 124186,
		                    ""MCs"": 17
	                    },
	                    {
		                    ""name"": ""Leo Morbi Neque Corp."",
		                    ""cust_no"": 20154,
		                    ""city"": ""Lochranza"",
		                    ""zip_code"": ""R1X 1PJ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 69511,
		                    ""MCs"": 30
	                    },
	                    {
		                    ""name"": ""At Sem Molestie Institute"",
		                    ""cust_no"": 50364,
		                    ""city"": ""Gentinnes"",
		                    ""zip_code"": ""C2 6LI"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 42813,
		                    ""MCs"": 22
	                    },
	                    {
		                    ""name"": ""Non Vestibulum Inc."",
		                    ""cust_no"": 20145,
		                    ""city"": ""Neuwied"",
		                    ""zip_code"": ""BT61 4VU"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 72076,
		                    ""MCs"": 37
	                    },
	                    {
		                    ""name"": ""Nullam Feugiat Placerat Foundation"",
		                    ""cust_no"": 177832,
		                    ""city"": ""Houffalize"",
		                    ""zip_code"": ""A8 6YZ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 63391,
		                    ""MCs"": 8
	                    },
	                    {
		                    ""name"": ""Adipiscing Corp."",
		                    ""cust_no"": 139064,
		                    ""city"": ""Wommelgem"",
		                    ""zip_code"": ""X8 0WU"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 198622,
		                    ""MCs"": 39
	                    },
	                    {
		                    ""name"": ""Ultrices Company"",
		                    ""cust_no"": 160794,
		                    ""city"": ""İmamoğlu"",
		                    ""zip_code"": ""YX0 4QB"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 129902,
		                    ""MCs"": 24
	                    },
	                    {
		                    ""name"": ""A Enim Suspendisse Foundation"",
		                    ""cust_no"": 138851,
		                    ""city"": ""Neum�nster"",
		                    ""zip_code"": ""RP3O 2AL"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 109008,
		                    ""MCs"": 8
	                    },
	                    {
		                    ""name"": ""Sociis Natoque Incorporated"",
		                    ""cust_no"": 117399,
		                    ""city"": ""Camrose"",
		                    ""zip_code"": ""UX89 0LD"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 80201,
		                    ""MCs"": 41
	                    },
	                    {
		                    ""name"": ""Malesuada Malesuada Consulting"",
		                    ""cust_no"": 163605,
		                    ""city"": ""Reno"",
		                    ""zip_code"": ""AT6D 8FT"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 40043,
		                    ""MCs"": 16
	                    },
	                    {
		                    ""name"": ""Ligula Limited"",
		                    ""cust_no"": 62420,
		                    ""city"": ""Rouvreux"",
		                    ""zip_code"": ""XK4O 7AW"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 141290,
		                    ""MCs"": 11
	                    },
	                    {
		                    ""name"": ""Mauris Id Sapien Corp."",
		                    ""cust_no"": 58330,
		                    ""city"": ""Labrecque"",
		                    ""zip_code"": ""PC41 4XQ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 180298,
		                    ""MCs"": 39
	                    },
	                    {
		                    ""name"": ""Eu Corp."",
		                    ""cust_no"": 185674,
		                    ""city"": ""Jonesboro"",
		                    ""zip_code"": ""RB0 7GM"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 48090,
		                    ""MCs"": 45
	                    },
	                    {
		                    ""name"": ""Nulla Company"",
		                    ""cust_no"": 41244,
		                    ""city"": ""Sarre"",
		                    ""zip_code"": ""YC56 9VK"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 62208,
		                    ""MCs"": 25
	                    },
	                    {
		                    ""name"": ""Id Nunc Interdum Consulting"",
		                    ""cust_no"": 57691,
		                    ""city"": ""Kimberly"",
		                    ""zip_code"": ""V1N 6PS"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 87365,
		                    ""MCs"": 42
	                    },
	                    {
		                    ""name"": ""Natoque Penatibus Et Company"",
		                    ""cust_no"": 84379,
		                    ""city"": ""Wood Buffalo"",
		                    ""zip_code"": ""L5 5OF"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 57653,
		                    ""MCs"": 40
	                    },
	                    {
		                    ""name"": ""Mattis Cras Eget LLC"",
		                    ""cust_no"": 187963,
		                    ""city"": ""Kailua"",
		                    ""zip_code"": ""WJ64 9SN"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 115372,
		                    ""MCs"": 9
	                    },
	                    {
		                    ""name"": ""Nec Mauris Corporation"",
		                    ""cust_no"": 174318,
		                    ""city"": ""Sevilla"",
		                    ""zip_code"": ""IK79 3QL"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 63305,
		                    ""MCs"": 36
	                    },
	                    {
		                    ""name"": ""Amet Ornare Lectus Ltd"",
		                    ""cust_no"": 183653,
		                    ""city"": ""Tirupati"",
		                    ""zip_code"": ""Y2 4NN"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 151907,
		                    ""MCs"": 18
	                    },
	                    {
		                    ""name"": ""Suscipit LLC"",
		                    ""cust_no"": 145421,
		                    ""city"": ""Oranienburg"",
		                    ""zip_code"": ""BD14 0RF"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 195275,
		                    ""MCs"": 9
	                    },
	                    {
		                    ""name"": ""Metus Vitae Velit Incorporated"",
		                    ""cust_no"": 185948,
		                    ""city"": ""Livo"",
		                    ""zip_code"": ""A7S 3PZ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 144206,
		                    ""MCs"": 6
	                    },
	                    {
		                    ""name"": ""Nullam Suscipit Inc."",
		                    ""cust_no"": 164596,
		                    ""city"": ""St. John's"",
		                    ""zip_code"": ""YP3C 6ZM"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 73175,
		                    ""MCs"": 7
	                    },
	                    {
		                    ""name"": ""Eros PC"",
		                    ""cust_no"": 161099,
		                    ""city"": ""Vosselaar"",
		                    ""zip_code"": ""EX2B 2CR"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 178800,
		                    ""MCs"": 50
	                    },
	                    {
		                    ""name"": ""Duis Ac Consulting"",
		                    ""cust_no"": 125168,
		                    ""city"": ""Goz�e"",
		                    ""zip_code"": ""C0 4EP"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 183860,
		                    ""MCs"": 45
	                    },
	                    {
		                    ""name"": ""Tellus Company"",
		                    ""cust_no"": 130178,
		                    ""city"": ""Poitiers"",
		                    ""zip_code"": ""P51 6MR"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 166110,
		                    ""MCs"": 43
	                    },
	                    {
		                    ""name"": ""Dignissim Pharetra PC"",
		                    ""cust_no"": 76017,
		                    ""city"": ""Lozzo Atestino"",
		                    ""zip_code"": ""HE2 1BW"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 166714,
		                    ""MCs"": 35
	                    },
	                    {
		                    ""name"": ""Nunc Sed Orci LLP"",
		                    ""cust_no"": 181679,
		                    ""city"": ""Winnipeg"",
		                    ""zip_code"": ""AN7 7UB"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 30336,
		                    ""MCs"": 14
	                    },
	                    {
		                    ""name"": ""Tincidunt Industries"",
		                    ""cust_no"": 124950,
		                    ""city"": ""Sant'Urbano"",
		                    ""zip_code"": ""YE7 0PL"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 36305,
		                    ""MCs"": 19
	                    },
	                    {
		                    ""name"": ""Gravida Sagittis Duis Foundation"",
		                    ""cust_no"": 27389,
		                    ""city"": ""Gorakhpur"",
		                    ""zip_code"": ""WB25 9JV"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 95325,
		                    ""MCs"": 17
	                    },
	                    {
		                    ""name"": ""Justo Sit Amet Corp."",
		                    ""cust_no"": 64857,
		                    ""city"": ""Waitara"",
		                    ""zip_code"": ""V06 0GN"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 179695,
		                    ""MCs"": 31
	                    },
	                    {
		                    ""name"": ""Convallis Dolor Quisque Industries"",
		                    ""cust_no"": 156954,
		                    ""city"": ""Niort"",
		                    ""zip_code"": ""U3R 3WD"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 28701,
		                    ""MCs"": 40
	                    },
	                    {
		                    ""name"": ""Tellus Nunc Lectus Corporation"",
		                    ""cust_no"": 89384,
		                    ""city"": ""Emden"",
		                    ""zip_code"": ""O0W 3WJ"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 192073,
		                    ""MCs"": 8
	                    },
	                    {
		                    ""name"": ""At Pede Cras Consulting"",
		                    ""cust_no"": 33412,
		                    ""city"": ""Holman"",
		                    ""zip_code"": ""R0 4BD"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 134348,
		                    ""MCs"": 31
	                    },
	                    {
		                    ""name"": ""Non Cursus Limited"",
		                    ""cust_no"": 165984,
		                    ""city"": ""Pitt Meadows"",
		                    ""zip_code"": ""F3 9GR"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 112272,
		                    ""MCs"": 17
	                    },
	                    {
		                    ""name"": ""Non Justo Proin LLP"",
		                    ""cust_no"": 68957,
		                    ""city"": ""Port Hope"",
		                    ""zip_code"": ""PS71 8YT"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 180821,
		                    ""MCs"": 32
	                    },
	                    {
		                    ""name"": ""Pellentesque Habitant Morbi Limited"",
		                    ""cust_no"": 190015,
		                    ""city"": ""Balıkesir"",
		                    ""zip_code"": ""FE9 5LD"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 38118,
		                    ""MCs"": 17
	                    },
	                    {
		                    ""name"": ""Augue Incorporated"",
		                    ""cust_no"": 176395,
		                    ""city"": ""Herdersem"",
		                    ""zip_code"": ""YM5C 3HS"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 77137,
		                    ""MCs"": 16
	                    },
	                    {
		                    ""name"": ""Dis Industries"",
		                    ""cust_no"": 52734,
		                    ""city"": ""Montecarotto"",
		                    ""zip_code"": ""T7D 4QH"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 64948,
		                    ""MCs"": 13
	                    },
	                    {
		                    ""name"": ""Augue Porttitor LLP"",
		                    ""cust_no"": 198472,
		                    ""city"": ""Moncrivello"",
		                    ""zip_code"": ""CE3J 3YU"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 169497,
		                    ""MCs"": 35
	                    },
	                    {
		                    ""name"": ""Phasellus Fermentum Associates"",
		                    ""cust_no"": 40160,
		                    ""city"": ""Allentown"",
		                    ""zip_code"": ""HY69 2ZI"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 83033,
		                    ""MCs"": 46
	                    },
	                    {
		                    ""name"": ""Diam At LLP"",
		                    ""cust_no"": 63615,
		                    ""city"": ""Sioux City"",
		                    ""zip_code"": ""GV0 8HK"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 78325,
		                    ""MCs"": 11
	                    },
	                    {
		                    ""name"": ""Nam PC"",
		                    ""cust_no"": 44978,
		                    ""city"": ""Truro"",
		                    ""zip_code"": ""EC8V 6WU"",
		                    ""chrg"": ""No"",
		                    ""charge_cust"": 140683,
		                    ""MCs"": 47
	                    }
                    ]"
                                },
            #endregion
           #region Mxp Get Customer Details
		 {
                    "sharepoint.GetCustomerDetails",@"[
	        {
		       ""name"": ""Neque Non Quam Corp."",
		        ""cust_no"": 133273,
		        ""city"": ""Zwevegem"",
		        ""zip_code"": ""W6U 7IX"",
		        ""chrg"": ""No"",
		        ""charge_cust"": 156901,
		        ""legal_name"": ""Eu Accumsan Sed Corporation"",
		        ""trading_as"": ""Eu Accumsan Sed Corporation"",
		        ""address##1"": ""10"",
		        ""address##2"": ""Nascetur Avenue"",
		        ""address##3"": """",
		        ""address##4"": """",
		        ""country_code"": ""United Kingdom"",
		        ""currency_cod"": 3,
		        ""vat_reg"": ""P3H 5J0"",
		        ""co_reg"": ""Y0Z 8V2"",
		        ""extpr_sendmethod"": ""ut,"",
		        ""type_code"": ""condimentum."",
		        ""mcs"": 37
	        }
        ]"
            },
    #endregion
           #region Mxp Device Summary
		 {
            "sharepoint.GetDeviceSummary",@"[
	        {
		        ""serial_no"": ""EF6BD6C6-C10F-E776-F9DA-F4DBF1FAD5FB"",
		        ""item_no"": 37,
		        ""description##1"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing"",
		        ""description##2"": ""Lorem ipsum dolor sit amet, consectetuer"",
		        ""acqsystemref"": ""TPJ14VBP0HX"",
		        ""zip_code"": ""CD3 5CB"",
		        ""serial_stat"": ""enim"",
		        ""description"": ""purus,"",
		        ""cust_no"": 42606,
		        ""alt_ref"": ""dis"",
		        ""lease_id"": 1
	        },
	        {
		        ""serial_no"": ""1A0FE028-B58D-B630-C6FE-D289261A2259"",
		        ""item_no"": 68,
		        ""description##1"": ""Lorem ipsum dolor sit amet,"",
		        ""description##2"": ""Lorem ipsum dolor sit amet,"",
		        ""acqsystemref"": ""ONE91XHH6TV"",
		        ""zip_code"": ""F82 9OE"",
		        ""serial_stat"": ""vitae,"",
		        ""description"": ""ut"",
		        ""cust_no"": 33515,
		        ""alt_ref"": ""Duis"",
		        ""lease_id"": 2
	        },
	        {
		        ""serial_no"": ""0C71F176-6B4A-0B1F-D589-83C415845333"",
		        ""item_no"": 18,
		        ""description##1"": ""Lorem ipsum dolor sit amet, consectetuer"",
		        ""description##2"": ""Lorem ipsum dolor sit amet,"",
		        ""acqsystemref"": ""CCK58AQH5ED"",
		        ""zip_code"": ""T68 6DR"",
		        ""serial_stat"": ""Fusce"",
		        ""description"": ""eget"",
		        ""cust_no"": 194257,
		        ""alt_ref"": ""mi"",
		        ""lease_id"": 3
	        },
	        {
		        ""serial_no"": ""42B48BE0-304A-B338-5796-1975C101606F"",
		        ""item_no"": 87,
		        ""description##1"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur"",
		        ""description##2"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing"",
		        ""acqsystemref"": ""RDB86PTP1TQ"",
		        ""zip_code"": ""TK96 0QU"",
		        ""serial_stat"": ""Vivamus"",
		        ""description"": ""Donec"",
		        ""cust_no"": 78451,
		        ""alt_ref"": ""vulputate,"",
		        ""lease_id"": 4
	        },
	        {
		        ""serial_no"": ""4F394B06-AE28-D994-DF28-5E0A232E59F9"",
		        ""item_no"": 56,
		        ""description##1"": ""Lorem ipsum dolor sit"",
		        ""description##2"": ""Lorem ipsum dolor"",
		        ""acqsystemref"": ""TFG84JGD1ZA"",
		        ""zip_code"": ""Z2I 3QW"",
		        ""serial_stat"": ""imperdiet"",
		        ""description"": ""arcu."",
		        ""cust_no"": 97257,
		        ""alt_ref"": ""est"",
		        ""lease_id"": 5
	        },
	        {
		        ""serial_no"": ""B085690F-6A0A-5567-ABDF-8F9E99D26FF0"",
		        ""item_no"": 49,
		        ""description##1"": ""Lorem"",
		        ""description##2"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur sed"",
		        ""acqsystemref"": ""ENF05HVK0YV"",
		        ""zip_code"": ""M26 9CQ"",
		        ""serial_stat"": ""suscipit"",
		        ""description"": ""lacus"",
		        ""cust_no"": 149137,
		        ""alt_ref"": ""quis,"",
		        ""lease_id"": 6
	        },
	        {
		        ""serial_no"": ""5DE6A02C-EA7E-E014-56E2-ACA1AC14A54C"",
		        ""item_no"": 69,
		        ""description##1"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing"",
		        ""description##2"": ""Lorem ipsum dolor sit amet,"",
		        ""acqsystemref"": ""SEK26KUD8TH"",
		        ""zip_code"": ""T7 9IK"",
		        ""serial_stat"": ""sem"",
		        ""description"": ""tempor"",
		        ""cust_no"": 95052,
		        ""alt_ref"": ""Suspendisse"",
		        ""lease_id"": 7
	        },
	        {
		        ""serial_no"": ""3D5344AC-EF44-BF38-AECA-9973895C22B4"",
		        ""item_no"": 31,
		        ""description##1"": ""Lorem ipsum dolor sit amet,"",
		        ""description##2"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing"",
		        ""acqsystemref"": ""JWK70MCG1YU"",
		        ""zip_code"": ""D7 1TD"",
		        ""serial_stat"": ""Morbi"",
		        ""description"": ""eget"",
		        ""cust_no"": 46584,
		        ""alt_ref"": ""vulputate"",
		        ""lease_id"": 8
	        },
	        {
		        ""serial_no"": ""EFB87EC0-6AEC-C47D-0931-9D897EEF849C"",
		        ""item_no"": 7,
		        ""description##1"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing"",
		        ""description##2"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing"",
		        ""acqsystemref"": ""IFW12AOY7TI"",
		        ""zip_code"": ""RM2 3BX"",
		        ""serial_stat"": ""pellentesque"",
		        ""description"": ""accumsan"",
		        ""cust_no"": 198960,
		        ""alt_ref"": ""nec,"",
		        ""lease_id"": 9
	        },
	        {
		        ""serial_no"": ""36369695-9B97-6742-55F5-8DF9FF9CE218"",
		        ""item_no"": 38,
		        ""description##1"": ""Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur sed"",
		        ""description##2"": ""Lorem ipsum dolor sit amet, consectetuer"",
		        ""acqsystemref"": ""YLI00AUD5CZ"",
		        ""zip_code"": ""I3U 5NU"",
		        ""serial_stat"": ""quis"",
		        ""description"": ""dolor,"",
		        ""cust_no"": 79981,
		        ""alt_ref"": ""In"",
		        ""lease_id"": 10
	        }
        ]"
        },
            #endregion
           #region MXP Device Details
            {
            "sharepoint.GetDeviceDetails",@"[
	                {
		                ""serial_no"": ""75A3945D-0EE0-0CE9-E9C3-2F56294A6B71"",
		                ""item_no"": 32,
		                ""description##1"": ""Lorem ipsum"",
		                ""description##2"": ""Lorem ipsum"",
		                ""acqsystemref"": ""KRB99PUL1XI"",
		                ""zip_code"": ""X25 4XT"",
		                ""serial_stat"": ""In"",
		                ""description"": ""magna"",
		                ""cust_no"": 166081,
		                ""alt_ref"": ""Vivamus"",
		                ""lease_id"": 1,
		                ""reference"": 26,
		                ""install_date"": ""15/12/2015"",
		                ""entry_date"": ""04/01/2016"",
		                ""primary_con"": ""Oliver Michael"",
		                ""primary_phon"": ""0800 778302"",
		                ""city"": ""Kincardine"",
		                ""country"": ""United Kingdom"",
		                ""address##1"": ""7936 Nunc Avenue"",
		                ""address##2"": ""9834 Aliquet, Rd."",
		                ""address##3"": ""Ap #212-708 Nulla Rd."",
		                ""address##4"": ""P.O. Box 443, 4301 Cursus Road"",
		                ""servprov"": ""93739"",
		                ""lease_id"": 4,
		                ""last_rd_date"": ""04/01/2015"",
		                ""next_meter_dt"": ""17/02/2015"",
		                ""contract_no"": ""C2Q 3A3"",
                        ""line_no"": ""1.000""
	                }
                ]"
            },
            #endregion

            #region Contract Headers
            {
               "sharepoint.GetContractHeaderSummary",@"[
	{
		""contract_no"": ""WBC73FLB7KS"",
		""description"": ""mauris blandit mattis. Cras eget"",
		""NoLines"": 1,
		""cntrct_start"": ""26/02/2015"",
		""cntrct_end"": ""08/01/2016"",
		""Cust_no"": 58430,
		""charge_cust"": 179257
	},
	{
		""contract_no"": ""LIN28ZJA3YI"",
		""description"": ""Suspendisse tristique neque venenatis lacus."",
		""NoLines"": 8,
		""cntrct_start"": ""13/11/2015"",
		""cntrct_end"": ""07/07/2016"",
		""Cust_no"": 56985,
		""charge_cust"": 102894
	},
	{
		""contract_no"": ""MJI36HEG4YA"",
		""description"": ""Vestibulum ante ipsum primis in"",
		""NoLines"": 2,
		""cntrct_start"": ""02/01/2015"",
		""cntrct_end"": ""10/08/2016"",
		""Cust_no"": 91162,
		""charge_cust"": 177594
	},
	{
		""contract_no"": ""VDN93FIE1XZ"",
		""description"": ""mus. Aenean eget magna. Suspendisse"",
		""NoLines"": 10,
		""cntrct_start"": ""19/11/2015"",
		""cntrct_end"": ""02/11/2015"",
		""Cust_no"": 181811,
		""charge_cust"": 82002
	},
	{
		""contract_no"": ""KRT49SBI0ZS"",
		""description"": ""lobortis quis, pede. Suspendisse dui."",
		""NoLines"": 2,
		""cntrct_start"": ""25/12/2015"",
		""cntrct_end"": ""07/04/2015"",
		""Cust_no"": 114986,
		""charge_cust"": 74787
	},
	{
		""contract_no"": ""RWH32HBM8MD"",
		""description"": ""ligula tortor, dictum eu, placerat"",
		""NoLines"": 4,
		""cntrct_start"": ""25/07/2015"",
		""cntrct_end"": ""13/09/2015"",
		""Cust_no"": 192570,
		""charge_cust"": 30293
	},
	{
		""contract_no"": ""IKF95GCZ1IX"",
		""description"": ""euismod est arcu ac orci."",
		""NoLines"": 10,
		""cntrct_start"": ""24/07/2016"",
		""cntrct_end"": ""28/09/2015"",
		""Cust_no"": 93893,
		""charge_cust"": 78533
	},
	{
		""contract_no"": ""IUX32KPL5WQ"",
		""description"": ""sed leo. Cras vehicula aliquet"",
		""NoLines"": 4,
		""cntrct_start"": ""25/02/2016"",
		""cntrct_end"": ""04/10/2015"",
		""Cust_no"": 120172,
		""charge_cust"": 137272
	},
	{
		""contract_no"": ""VBD80ETW2LZ"",
		""description"": ""vitae dolor. Donec fringilla. Donec"",
		""NoLines"": 4,
		""cntrct_start"": ""09/08/2015"",
		""cntrct_end"": ""09/09/2016"",
		""Cust_no"": 147315,
		""charge_cust"": 99970
	},
	{
		""contract_no"": ""INA97EUQ1YP"",
		""description"": ""eu, odio. Phasellus at augue"",
		""NoLines"": 3,
		""cntrct_start"": ""26/03/2016"",
		""cntrct_end"": ""06/11/2016"",
		""Cust_no"": 182572,
		""charge_cust"": 33005
	}
]"
            },
            #endregion

            #region Contract Line
            {
             "sharepoint.GetContractLineSummary"  ,@"[
	{
		""contract_no"": ""TYP10BHO7CG"",
		""description"": ""Aenean sed pede nec ante"",
		""line_no"": 1,
		""item_no"": ""69644"",
		""charge_cust"": 50642,
		""cust_no"": 42349,
		""itemDescription"": ""eleifend non, dapibus rutrum, justo."",
		""serial_no"": ""JSC44RQF2TJ""
	},
	{
		""contract_no"": ""ZVU13VQV6KE"",
		""description"": ""aliquet lobortis, nisi nibh lacinia"",
		""line_no"": 2,
		""item_no"": ""96906"",
		""charge_cust"": 73505,
		""cust_no"": 79827,
		""itemDescription"": ""varius. Nam porttitor scelerisque neque."",
		""serial_no"": ""WMF40CGN6TH""
	},
	{
		""contract_no"": ""QMS32FEH6QY"",
		""description"": ""eu dui. Cum sociis natoque"",
		""line_no"": 3,
		""item_no"": ""76577"",
		""charge_cust"": 72740,
		""cust_no"": 81521,
		""itemDescription"": ""mi. Aliquam gravida mauris ut"",
		""serial_no"": ""RVE06RXY9KW""
	},
	{
		""contract_no"": ""QKA44JJV8VG"",
		""description"": ""Aliquam ornare, libero at auctor"",
		""line_no"": 4,
		""item_no"": ""31419"",
		""charge_cust"": 50946,
		""cust_no"": 92734,
		""itemDescription"": ""fermentum metus. Aenean sed pede"",
		""serial_no"": ""KSF16OME2GN""
	},
	{
		""contract_no"": ""AIJ90FYH0PO"",
		""description"": ""et magnis dis parturient montes,"",
		""line_no"": 5,
		""item_no"": ""00428"",
		""charge_cust"": 144080,
		""cust_no"": 44359,
		""itemDescription"": ""ac arcu. Nunc mauris. Morbi"",
		""serial_no"": ""OEI28YXR7ED""
	},
	{
		""contract_no"": ""CCA64GAV1SP"",
		""description"": ""mauris. Morbi non sapien molestie"",
		""line_no"": 6,
		""item_no"": ""30661"",
		""charge_cust"": 54876,
		""cust_no"": 45072,
		""itemDescription"": ""a, magna. Lorem ipsum dolor"",
		""serial_no"": ""OQL52EKY4XV""
	},
	{
		""contract_no"": ""TCT83NEM8RQ"",
		""description"": ""vel, faucibus id, libero. Donec"",
		""line_no"": 7,
		""item_no"": ""16111"",
		""charge_cust"": 44573,
		""cust_no"": 156628,
		""itemDescription"": ""quam a felis ullamcorper viverra."",
		""serial_no"": ""HEO49QKI6RJ""
	},
	{
		""contract_no"": ""MIP76HTN2AW"",
		""description"": ""ante lectus convallis est, vitae"",
		""line_no"": 8,
		""item_no"": ""63130"",
		""charge_cust"": 80030,
		""cust_no"": 146861,
		""itemDescription"": ""non leo. Vivamus nibh dolor,"",
		""serial_no"": ""DCZ02MRM4BT""
	},
	{
		""contract_no"": ""VGK78ZDX9OF"",
		""description"": ""elit. Curabitur sed tortor. Integer"",
		""line_no"": 9,
		""item_no"": ""29004"",
		""charge_cust"": 52204,
		""cust_no"": 196375,
		""itemDescription"": ""Donec egestas. Aliquam nec enim."",
		""serial_no"": ""MNQ30NMF5AN""
	},
	{
		""contract_no"": ""JDB40VEG3BJ"",
		""description"": ""risus. Nunc ac sem ut"",
		""line_no"": 10,
		""item_no"": ""83714"",
		""charge_cust"": 108289,
		""cust_no"": 115572,
		""itemDescription"": ""ultrices iaculis odio. Nam interdum"",
		""serial_no"": ""YQE55JIO3PN""
	}
]"
            },
            #endregion

            #region Contract Line details
            {
                "sharepoint.GetContractLineDetails",@"[
	                            {
		                            ""contract_no"": ""WNE87PBG4LP"",
		                            ""description"": ""convallis dolor. Quisque tincidunt pede"",
		                            ""line_no"": 1,
		                            ""item_no"": ""92487"",
		                            ""charge_cust"": 38331,
		                            ""cust_no"": 181521,
		                            ""itemDescription"": ""fringilla. Donec feugiat metus sit"",
		                            ""serial_no"": ""BZW30IEH0HR"",
		                            ""cntrct_start"": ""29/06/2015"",
		                            ""cntrct_end"": ""06/11/2016"",
		                            ""pi_end_dt"": ""24/04/2016"",
		                            ""next_pri_dt"": ""15/10/2015"",
		                            ""max_incr__"": 1,
		                            ""lease_ref"": ""00565"",
                                    ""acqsystemref"":""123456""
                                }
                            ]"
            },
            #endregion

            #region Lease Summary
            {
              "sharepoint.GetLeaseSummary" ,@"[
	                {
		                ""lease_ref"": ""XKH74FXU8EX"",
		                ""funder"": ""eu,"",
		                ""lease_term"": 4,
		                ""start_date"": ""03/06/16"",
		                ""calc_enddate"": ""10/12/15"",
		                ""lease_id"": 1
	                },
	                {
		                ""lease_ref"": ""EIK84COW1VL"",
		                ""funder"": ""lacinia"",
		                ""lease_term"": 10,
		                ""start_date"": ""23/04/15"",
		                ""calc_enddate"": ""19/02/15"",
		                ""lease_id"": 6
	                },
	                {
		                ""lease_ref"": ""QUK78VRK6YU"",
		                ""funder"": ""elit."",
		                ""lease_term"": 6,
		                ""start_date"": ""29/07/15"",
		                ""calc_enddate"": ""06/11/15"",
		                ""lease_id"": 10
	                },
	                {
		                ""lease_ref"": ""CRP55QBY6XI"",
		                ""funder"": ""tortor"",
		                ""lease_term"": 5,
		                ""start_date"": ""11/12/14"",
		                ""calc_enddate"": ""30/08/16"",
		                ""lease_id"": 9
	                },
	                {
		                ""lease_ref"": ""GJW54XVS3EQ"",
		                ""funder"": ""odio"",
		                ""lease_term"": 4,
		                ""start_date"": ""25/05/15"",
		                ""calc_enddate"": ""17/04/16"",
		                ""lease_id"": 4
	                }
                ]"
            },
            #endregion

            #region Lease Detail
            {
              "sharepoint.GetLeaseDetails" ,@"[
	                    {
		                    ""lease_ref"": ""CUF83IFO4OX"",
		                    ""funder"": ""sed"",
		                    ""lease_term"": 6,
		                    ""start_date"": ""25/02/15"",
		                    ""calc_enddate"": ""24/03/16"",
		                    ""lease_id"": 8,
		                    ""active"": 4,
		                    ""stat"": ""Mauris""
	                    }
                    ]"
            },
            #endregion

            #region CRM Account Summary
            {
                "sharepoint.GetCRMAccountSummary",@"[
	{
		""name"": ""Erat Eget Ipsum Company"",
		""address1_postalcode"": ""O90 5GE"",
		""address1_city"": ""Chelmsford"",
		""owneridname"": ""Hayden"",
		""dw_devicecount"": 83,
		""parentaccountidname"": ""Tincidunt Congue Turpis Incorporated"",
		""dw_lastactivitydate"": ""06/10/2015"",
		""dw_nextactivitydate"": ""13/09/2016"",
		""accountid"": ""2ED93F81-A713-F273-0D67-C1795C8E94AC"",
		""ownerid"": ""A7E6CD76-D034-1576-2994-FC7C26E15F2E"",
		""parentaccountid"": ""F43B8752-0EED-0EEB-9129-1792DA027E70"",
		""img_mxpgrpcustid"": 76784
	},
	{
		""name"": ""Et Tristique Pellentesque PC"",
		""address1_postalcode"": ""W0S 8PS"",
		""address1_city"": ""Terrance"",
		""owneridname"": ""Akeem"",
		""dw_devicecount"": 89,
		""parentaccountidname"": ""Eu LLP"",
		""dw_lastactivitydate"": ""13/10/2015"",
		""dw_nextactivitydate"": ""25/02/2016"",
		""accountid"": ""AFDF54C1-5569-7E25-56AC-5CE7E7995260"",
		""ownerid"": ""815E006D-1400-922D-44A3-A90057815CA6"",
		""parentaccountid"": ""C86489EE-44B4-9365-DF42-564EDE5635AD"",
		""img_mxpgrpcustid"": 69618
	},
	{
		""name"": ""Morbi Non Sapien Company"",
		""address1_postalcode"": ""TG0 4OC"",
		""address1_city"": ""Boise"",
		""owneridname"": ""Dexter"",
		""dw_devicecount"": 47,
		""parentaccountidname"": ""Mi Ac Mattis PC"",
		""dw_lastactivitydate"": ""28/01/2015"",
		""dw_nextactivitydate"": ""09/09/2015"",
		""accountid"": ""ADDB8727-7762-1A35-B460-1C7D3B7380F1"",
		""ownerid"": ""65370E01-DFD7-415C-F1B6-A3DBB500A790"",
		""parentaccountid"": ""938CA78A-61AB-3CFE-FFB1-8D926C563B86"",
		""img_mxpgrpcustid"": 83432
	},
	{
		""name"": ""Sociosqu PC"",
		""address1_postalcode"": ""M1 6YL"",
		""address1_city"": ""Dolembreux"",
		""owneridname"": ""Jelani"",
		""dw_devicecount"": 59,
		""parentaccountidname"": ""Duis Incorporated"",
		""dw_lastactivitydate"": ""21/01/2015"",
		""dw_nextactivitydate"": ""22/01/2016"",
		""accountid"": ""BA18C88F-B069-B069-516A-9AEEE0F29334"",
		""ownerid"": ""C869A4AB-21CE-D48C-7809-5B9BBA1EB15F"",
		""parentaccountid"": ""AF2D3BC5-62FE-DA6D-FDA0-FA76B386F4CF"",
		""img_mxpgrpcustid"": 40549
	}
	
]"
            },
            #endregion
            #region CRM Account Details
            {
                "sharepoint.GetCRMAccountDetails",@"[
	                    {
		                    ""name"": ""Lorem Institute"",
		                    ""address1_postalcode"": ""96926"",
		                    ""address1_city"": ""Chichester"",
		                    ""owneridname"": ""Ethan"",
		                    ""dw_devicecount"": 51,
		                    ""parentaccountidname"": ""Praesent Foundation"",
		                    ""dw_lastactivitydate"": ""02/02/2015"",
		                    ""dw_nextactivitydate"": ""11/05/2016"",
		                    ""accountid"": ""52D8D457-4E99-7B78-D2CB-D31BCDA9BBDC"",
		                    ""ownerid"": ""8A2490DF-B67C-73E3-C67F-B50FA809FF87"",
		                    ""parentaccountid"": ""AE8FE884-93F6-7103-8F83-0521128D3608"",
		                    ""img_mxpgrpcustid"": 29345,
		                    ""img_patchidname"": ""50664"",
		                    ""accountcategorycodename"": ""sagittis"",
		                    ""img_vmscategoryname"": ""interdum"",
		                    ""img_vmssubcategoryname"": ""morbi"",
		                    ""primarycontactidname"": ""Chadwick"",
		                    ""img_primarygeneralcontact"": ""Donovan"",
		                    ""emailaddress1"": ""at.risus@Pellentesque.edu"",
		                    ""address1_telephone1"": ""0321 223 5593"",
		                    ""address1_line1"": ""684 Tristique St."",
		                    ""address1_line2"": ""P.O. Box 832, 3099 Bibendum Ave"",
		                    ""address1_line3"": ""3791 Augue Road"",
		                    ""address1_stateorprovince"": ""Sussex"",
		                    ""address1_country"": ""Peru"",
		                    ""primarycontactid"": ""06F13BFD-3B75-F5C1-096A-BD3445C43CB5"",
		                    ""img_primarygeneralcontact1"": ""632C3CCB-0CB9-C030-30F0-2DA2C395D18C"",
		                    ""img_mxpgrpcustid"": 708328,
		                    ""outs_sharepointid"": ""17AB5285-6569-119A-0BD9-588EC8034989"",
		                    ""parentaccountidname"": ""Libero Associates""
	                    }
                    ]"
            },
            #endregion
            #region CRM Contacts
            {
                "sharepoint.GetCRMContactSummary",@"[
	{
		""firstname"": ""Raja"",
		""lastname"": ""Nissim"",
		""jobtitle"": ""Proin"",
		""emailaddress1"": ""facilisis@metusurna.co.uk"",
		""parentcustomeridname"": ""Vitae Sodales At Limited"",
		""telephone1"": ""(016977) 7469"",
		""parentcustomerid"": ""E93BB390-3922-896F-53E5-D18C1927665D"",
		""contactid"": ""1E098175-9107-0884-70C8-D57AFFB2ED30"",
		""mobilephone"": ""(0111) 206 6396""
	},
	{
		""firstname"": ""Graiden"",
		""lastname"": ""Walker"",
		""jobtitle"": ""ipsum."",
		""emailaddress1"": ""pharetra@diamvelarcu.com"",
		""parentcustomeridname"": ""Hymenaeos Mauris Institute"",
		""telephone1"": ""0500 122575"",
		""parentcustomerid"": ""52220A56-9738-34BF-A166-5A320AB920D3"",
		""contactid"": ""ABFAB720-2545-C6C5-6DBE-C9117548C48B"",
		""mobilephone"": ""0845 46 46""
	},
	{
		""firstname"": ""Alexander"",
		""lastname"": ""Len"",
		""jobtitle"": ""Sed"",
		""emailaddress1"": ""sapien@atsem.com"",
		""parentcustomeridname"": ""Volutpat Ornare Facilisis Ltd"",
		""telephone1"": ""(016977) 4692"",
		""parentcustomerid"": ""42EDA9ED-B1C0-B8CA-0DB2-C88E88727475"",
		""contactid"": ""3A4D3A51-DA2F-6F58-3B39-83E5BB4247C1"",
		""mobilephone"": ""(0151) 181 3192""
	},
	{
		""firstname"": ""Cairo"",
		""lastname"": ""Philip"",
		""jobtitle"": ""adipiscing"",
		""emailaddress1"": ""dignissim.Maecenas@duiCumsociis.com"",
		""parentcustomeridname"": ""Amet Consectetuer Institute"",
		""telephone1"": ""07820 587386"",
		""parentcustomerid"": ""15ACF273-13E0-79CA-51D4-D1158ABC1C51"",
		""contactid"": ""3BE6030B-164F-76C9-67EE-A802192F535A"",
		""mobilephone"": ""07113 773907""
	}]"
            },

            #endregion
        }; 
       

       
    }
}
