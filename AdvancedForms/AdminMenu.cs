using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using OrchardCore.Navigation;

namespace AdvancedForms
{
    public class AdminMenu : INavigationProvider
    {
        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            T = localizer;
        }

        public IStringLocalizer T { get; set; }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }
            builder
                .Add(T["Advanced Forms"], "12", advancedForms => advancedForms
                    .AddClass("advancedForms").Id("advancedForms")
                    .AddClass("Active")
                    .Add(T["New"], layers => layers
                        .Action("Create", "Admin", new { area = "AdvancedForms" })
                        .Permission(Permissions.ManageOwnAdvancedForms)
                        .LocalNav()
                    ).Add(T["Forms"], layers => layers
                        .Url("Admin/Contents/ContentItems?id=AdvancedForm&active=AdvancedForms")
                        .Permission(Permissions.ManageOwnAdvancedForms)
                        .LocalNav()
                    ).Add(T["Submissions"], layers => layers
                        .Url("Admin/Contents/ContentItems?id=AdvancedFormSubmissions&active=AdvancedForms")
                        .Permission(Permissions.ManageOwnAdvancedForms)
                        .LocalNav()
                    ));
            return Task.CompletedTask;
        }
    }
}
