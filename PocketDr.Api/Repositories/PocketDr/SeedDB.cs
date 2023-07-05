using PocketDr.Api.Repositories.PocketDr.Models;

namespace PocketDr.Api.Repositories.PocketDr
{
    public class SeedDB
    {
        public static void SeedData(PocketDrContext context)
        {
            if (!context.Chats.Any())
            {
                System.Console.WriteLine("\n\nAdding data - Seeding ...\n\n");

                Guid userId = Guid.Parse("d195ece6-e293-11ed-b5ea-0242ac120002");

                var chat1 = new Chat
                {
                    ChatId = Guid.NewGuid(),
                    UserId = userId,
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Chats.Add(chat1);

                var chat2 = new Chat
                {
                    ChatId = Guid.NewGuid(),
                    UserId = userId,
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Chats.Add(chat2);

                context.SaveChanges();

                // Chat grupp 1

                var message1 = new Message
                {
                    MessageId = Guid.NewGuid(),
                    ChatId = chat1.ChatId,
                    Text = "Är kapslar med kosttillskott bättre än tabletter?",
                    Sender = chat1.UserId.ToString(),
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Messages.Add(message1);
                context.SaveChanges();
                var message2 = new Message
                {
                    MessageId = Guid.NewGuid(),
                    ChatId = chat1.ChatId,
                    Text = "Det beror på vilket kosttillskott det gäller och hur kapseln eller tabletten är tillverkad. I allmänhet kan kapslar ha vissa fördelar jämfört med tabletter. Snabbare upptag: Kapslar kan brytas ned snabbare än tabletter, vilket kan göra det lättare för kroppen att absorbera kosttillskottet.",
                    Sender = "chatgpt",
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Messages.Add(message2);
                context.SaveChanges();

                var message3 = new Message
                {
                    MessageId = Guid.NewGuid(),
                    ChatId = chat1.ChatId,
                    Text = "Vilken av dem två är enklast att svälja",
                    Sender = chat1.UserId.ToString(),
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Messages.Add(message3);
                context.SaveChanges();

                var message4 = new Message
                {
                    MessageId = Guid.NewGuid(),
                    ChatId = chat1.ChatId,
                    Text = "Generellt sett kan kapslar vara enklare att svälja eftersom de vanligtvis är mjukare och glidande, medan tabletter kan vara större och svårare att svälja för vissa personer. Men det beror också på den specifika kapseln eller tabletten, då det kan finnas varierande storlekar och former av båda. Det är alltid viktigt att läsa etiketterna noggrant och rådgöra med din läkare eller apotekspersonal om du har svårt att svälja någon av dem. Det finns också alternativ som flytande kosttillskott som kan vara ett lättare alternativ att svälja för personer som har svårt att svälja kapslar eller tabletter.",
                    Sender = "chatgpt",
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Messages.Add(message4);
                context.SaveChanges();

                var message5 = new Message
                {
                    MessageId = Guid.NewGuid(),
                    ChatId = chat1.ChatId,
                    Text = "Varför är det lämpligt att dricka lite vatten efter att man har svalt en mixtur",
                    Sender = chat1.UserId.ToString(),
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Messages.Add(message5);
                context.SaveChanges();

                var message6 = new Message
                {
                    MessageId = Guid.NewGuid(),
                    ChatId = chat1.ChatId,
                    Text = "Det är lämpligt att dricka lite vatten efter att man har svalt en mixtur av flera skäl:Minskar risken för irritation i halsen: Vatten kan hjälpa till att skölja ner mixturer som kan ha irriterande ingredienser eller smaker. Det kan också hjälpa till att minska risken för att en del av mixturer fastnar i halsen och orsakar obehag eller hosta. Ökar upptaget av mixturer: Vatten kan hjälpa till att öka upptaget av mixturer genom att späda ut dem och göra dem lättare att passera genom matsmältningssystemet. Detta kan också bidra till att öka effekten av de aktiva ingredienserna i mixturer. Förhindrar uttorkning: Vatten kan också hjälpa till att förhindra uttorkning som kan orsakas av vissa mixturer eller mediciner.",
                    Sender = "chatgpt",
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Messages.Add(message6);
                context.SaveChanges();

                // Chat grupp 2

                var message7 = new Message
                {
                    MessageId = Guid.NewGuid(),
                    ChatId = chat2.ChatId,
                    Text = "Hur kan man snabbast återhämta sig från en menisken skada",
                    Sender = chat2.UserId.ToString(),
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Messages.Add(message7);
                context.SaveChanges();

                var message8 = new Message
                {
                    MessageId = Guid.NewGuid(),
                    ChatId = chat2.ChatId,
                    Text = "Återhämtning från en meniskskada beror på graden av skada och kan variera från person till person. I allmänhet kan en kombination av följande åtgärder hjälpa till att främja snabbare återhämtning: RICE-metoden: RICE står för Rest, Ice, Compression och Elevation. Detta är en välkänd metod för att behandla akuta skador och kan hjälpa till att minska svullnad, smärta och inflammation i det skadade området. Resten ger kroppen tid att läka, is minskar svullnaden, kompression minskar svullnad och inflammation och elevation förbättrar blodcirkulationen. Fysioterapi: En fysioterapeut kan hjälpa till att återställa rörlighet, styrka och funktion i det skadade området genom specifika övningar och terapier. Antiinflammatorisk medicin: Antiinflammatoriska läkemedel kan hjälpa till att minska svullnad och inflammation och lindra smärta. Kirurgi: I vissa fall kan en meniskskada kräva kirurgi, särskilt om skadan är allvarlig eller inte svarar på icke-kirurgiska behandlingar. Det är också viktigt att undvika aktiviteter som kan öka belastningen på det skadade området och ge kroppen tillräckligt med tid att återhämta sig. En hälsosam kost och adekvat vila kan också hjälpa till att främja snabbare återhämtning från en meniskskada. Det är viktigt att rådfråga en läkare eller sjukgymnast för råd om hur man bäst återhämtar sig från en meniskskada.",
                    Sender = "chatgpt",
                    CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                context.Messages.Add(message8);
                context.SaveChanges();

                System.Console.WriteLine("\n\n Seeding Completed!! ...\n\n");
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}
