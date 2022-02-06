using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test_front_page.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            DataContext Context = new DataContext();

            var contact = new List<Messages>()
            {
                new Messages() {Mail="mehmetgon@hotmail.com",Name="Mehmet",SurName="Gön",Phone="01234567891",IsRead=false,Subject="Deneme",IpAdress="91.93.113.253",Message="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur."},
                new Messages() {Mail="aliveli@hotmail.com",Name="Ali",SurName="Veli",Phone="03216987452",IsRead=false,Subject="Deneme1",IpAdress="151.174.39.142",Message="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir." },
                new Messages() {Mail="omeromer@hotmail.com",Name="Ömer",SurName="Ömer",Phone="07896354123",IsRead=false,Subject="Denem2",IpAdress="88.326.153.96",Message="Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir."},
                new Messages() {Mail="mehmetgon@hotmail.com",Name="Mehmet",SurName="Gön",Phone="03694253674",IsRead=false,Subject="Deneme3",IpAdress="413.811.697.453",Message="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?"},


            };
            foreach (var con in contact)
            {
                context.Contact.Add(con);

            }
            context.SaveChanges();
            base.Seed(context);



            var product = new List<Products>()
            {
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now ,Statu=true,Image="mahsul-image1.png",Height=30,Width=30,Stock=100},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsul-image2.png",Height=60,Width=60,Stock=90},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image3.png",Height=50,Width=50,Stock=125},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsullar-image4.png",Height=70,Width=70,Stock=741},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsul-image1.png",Height=30,Width=30,Stock=803},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image2.png",Height=60,Width=60,Stock=33},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image3.png",Height=50,Width=50,Stock=42},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsullar-image4.png",Height=70,Width=70,Stock=487},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsul-image1.png",Height=30,Width=30,Stock=523},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image2.png",Height=60,Width=60,Stock=981},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image3.png",Height=50,Width=50,Stock=345},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsullar-image4.png",Height=70,Width=70,Stock=112},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image1.png",Height=30,Width=30,Stock=642},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsul-image2.png",Height=60,Width=60,Stock=490},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image3.png",Height=50,Width=50,Stock=500},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsullar-image4.png",Height=70,Width=70,Stock=100},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image1.png",Height=30,Width=30,Stock=100},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsul-image2.png",Height=60,Width=60,Stock=90},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image3.png",Height=50,Width=50,Stock=125},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsullar-image4.png",Height=70,Width=70,Stock=741},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsul-image1.png",Height=30,Width=30,Stock=803},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image2.png",Height=60,Width=60,Stock=33},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image3.png",Height=50,Width=50,Stock=42},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsullar-image4.png",Height=70,Width=70,Stock=487},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsul-image1.png",Height=30,Width=30,Stock=523},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image2.png",Height=60,Width=60,Stock=981},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image3.png",Height=50,Width=50,Stock=345},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsullar-image4.png",Height=70,Width=70,Stock=112},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image1.png",Height=30,Width=30,Stock=642},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=false,Image="mahsul-image2.png",Height=60,Width=60,Stock=490},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsul-image3.png",Height=50,Width=50,Stock=500},
                new Products() {Name="Sun Salfet",AddedDate=DateTime.Now,Statu=true,Image="mahsullar-image4.png",Height=70,Width=70,Stock=100},
            };
            foreach (var pro in product)
            {
                context.Products.Add(pro);

            }
            context.SaveChanges();
            base.Seed(context);


            var settings = new List<Settings>()
            {
                new Settings() {Logo="logo.svg",Phone="(+99412) 404 19 19",Mail="info@azersun.com",Address="Heydər Əliyev pr., 92a Bakı, Azərbaycan, AZ1029",Map="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3037.95612412804!2d49.89241271563385!3d40.40982276398306!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x403062b9b75d7abf%3A0x1196186aad77cb20!2sAzersun%20Holding!5e0!3m2!1sen!2str!4v1637259086159!5m2!1sen!2str",ProjectText="SUN markası ənənəvi olaraq hər il bölgə əhalisini şəxsi gigiyena mövzusunda maarifləndirir. Qapıdan - qapıya gəzərək tualet kağızı istifadə edilmədikdə yayılan xəstəliklər və bunun fəsadları barədə həkim nümayəndə vasitəsiylə kənd əhalisini məlumatlandırır. Digər ənənəyə çevrilmiş layihəmiz Məktəbli layihəsidir. Uşaqlıqdan qazanılan bilik daşa həkk olunan yazıdır. - deyirlər. Biz də məhsul qrupu olaraq hədəfimizi böyük tutub, məktəblərdə maarifləndirmə layihəmizi həm əyləncəli, həm də interaktiv şəkildə həyata keçirməyi özümüzə məqsəd qoyduq."}
            };
            foreach (var set in settings)
            {
                context.Settings.Add(set);
            }
            context.SaveChanges();
            base.Seed(context);



            var slider = new List<Sliders>()
            {
                new Sliders(){Header="Gələcək sağlam olSUN!",Content="SUN gigiyenik kağız markası 20 ildən artıq müddətdir ki, daxili bazarda lider məhsullardan birinə çevrilib.",Image="home-slider-1.jpg" },
                new Sliders(){Header="Sun Paper",Content="SUN gigiyenik kağız markası 20 ildən artıq müddətdir ki, daxili bazarda lider məhsullardan birinə çevrilib.",Image="home-slider-2.jpg" },

            };
            foreach (var sli in slider)
            {
                context.Sliders.Add(sli);
            }
            context.SaveChanges();
            base.Seed(context);



            var social = new List<SocialMedia>()
            {
                new SocialMedia(){FaceBook="https://tr-tr.facebook.com/",Instagram="https://www.instagram.com/",Youtube="https://www.youtube.com/"}

            };
            foreach (var soc in social)
            {
                context.SocialMedia.Add(soc);
            }
            context.SaveChanges();
            base.Seed(context);




            var videos = new List<Videos>()
            {
                new Videos(){Image="layihe-image1.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
                new Videos(){Image="leyiha-image-2.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
                new Videos(){Image="layihe-image1.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
                new Videos(){Image="layihe-image1.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
                new Videos(){Image="leyiha-image-2.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
                 new Videos(){Image="layihe-image1.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
                new Videos(){Image="leyiha-image-2.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
                 new Videos(){Image="leyiha-image-2.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
                new Videos(){Image="layihe-image1.png",Link="https://www.youtube.com/watch?v=CbasHrrBP9M" },
            };
            foreach (var vid in videos)
            {
                context.Videos.Add(vid);
            }
            context.SaveChanges();
            base.Seed(context);




            var about = new List<About>()
            {
                new About(){Image="home-about.png",text="SUN gigiyenik kağız markası 20 ildən artıq müddətdir ki, daxili bazarda lider məhsullardan birinə çevrilib. Bu marka tarixə ilk yerli gigiyenik kağız brendi kimi düşmüşdür. SUN markasının özəlliklərindən ən əsası onun hər bir ailə üzvü tərəfindən istifadə edilməsidir. Məhsulların müxtəlif ölçülərdə olması ev və iş yerləri üçün sərfəli salfetləri, kağız, qutu, cib dəsmalları illərdir ki, hər kəsin sağlamlığını qoruyur." }

            };
            foreach (var abo in about)
            {
                context.About.Add(abo);
            }
            context.SaveChanges();
            base.Seed(context);

            var admin = new List<Admin>()
            {
                new Admin(){UserName="admin",Password="admin",Mail="mehmetgon@hotmail.com",NameSurname="Mehmet GÖN",AdminAbout="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce vitae diam ut sem accumsan lobortis sed id augue. Curabitur maximus.",Address="Adana/Seyhan",Phone="05553331122",Image="Admin.jpg"}
            };
            foreach (var adm in admin)
            {
                context.Admin.Add(adm);
            }
            context.SaveChanges();
            base.Seed(context);




        }
    }
}





