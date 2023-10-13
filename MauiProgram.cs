﻿using SkiaSharp.Views.Maui.Controls.Hosting;
namespace BankTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseSkiaSharp(true)
			.UseMauiMaps()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<BranchesDetailViewModel>();
		builder.Services.AddTransient<BranchesDetailPage>();

		builder.Services.AddSingleton<BranchesViewModel>();
		builder.Services.AddTransient<TestLocationService>();
		builder.Services.AddSingleton<BranchesPage>();

		builder.Services.AddSingleton<MapViewModel>();

		builder.Services.AddSingleton<MapPage>();

		return builder.Build();
	}
}
