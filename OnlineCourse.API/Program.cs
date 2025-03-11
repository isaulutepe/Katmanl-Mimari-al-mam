using OnlineCourse.Business.Abstract;
using OnlineCourse.Business.Concrete;
using OnlineCourse.DataAccess.Abstarct;
using OnlineCourse.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers(); //Controller kullanmak için.

//Dependency Injection Yaptýk bu da her seferinde yeniden constructer içinde çaðrýlamasýný engeller.
builder.Services.AddSingleton<IOgrenciService, OgrenciManager>();
builder.Services.AddSingleton<IKursService, KursManager>();
builder.Services.AddSingleton<IKayitService, KayitManager>();
builder.Services.AddSingleton<IOgrenciRepository, OgrenciRepository>();
builder.Services.AddSingleton<IKursRepository, KursRepository>();
builder.Services.AddSingleton<IKayitRepository, KayitRepository>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); //Controller dan yönlendirme saðlamak için.

app.Run();
