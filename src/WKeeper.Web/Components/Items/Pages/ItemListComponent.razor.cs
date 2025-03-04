using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using WKeeper.Core.Entities.Warehouses;


namespace WKeeper.Web.Components.Items.Pages;

public partial class ItemListComponent : IDialogContentComponent
{
    private IQueryable<Item>? _Items;
    string nameFilter = string.Empty;
    private readonly PaginationState pagination = new() { ItemsPerPage = 10 };

    protected override async Task OnInitializedAsync()
    {
        await GetDataAsync();
    }

    private async Task GetDataAsync()
    {
        var items = await ItemService.GetAsync();
        _Items = items.AsQueryable();
    }

    IQueryable<Item>? FilteredItems
    {
        get
        {
            return _Items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void HandleNameFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            nameFilter = value;
        }
    }

    // panel Oversee
    private async Task Oversee(Item data)
    {
        //DialogParameters<Warehouse> parameters = new()
        //{
        //    Content = data,
        //    Title = $"Oversee {data.Name} Warehouse",
        //    OnDialogResult = DialogService.CreateDialogCallback(this, HandlePanelAsync),
        //    Alignment = HorizontalAlignment.Left,
        //    Modal = false,
        //    ShowDismiss = false,
        //    PrimaryAction = "Ok",
        //    SecondaryAction = "Cancel",
        //    Width = "600px"
        //};
        //await DialogService.ShowPanelAsync<WarehouseOverseePanel, Warehouse>(parameters);
    }

    // create modal
    private async Task Create()
    {
        //var dialog = await DialogService.ShowDialogAsync<WarehouseCreateForm>(new DialogParameters()
        //{
        //    Height = "400px",
        //    Title = $"Create Warehouse",
        //    PreventDismissOnOverlayClick = true,
        //    PreventScroll = true,
        //});

        //var result = await dialog.Result;
        //if (!result.Cancelled && result.Data != null)
        //{
        //    StateHasChanged();
        //    await GetDataAsync();
        //}
    }

    // Update modal
    private async Task Update(Item data)
    {
        //var dialog = await DialogService.ShowDialogAsync<WarehouseUpdateForm>(data, new DialogParameters()
        //{
        //    Height = "400px",
        //    Title = $"Update Warehouse {data.Name}",
        //    PreventDismissOnOverlayClick = true,
        //    PreventScroll = true,
        //});

        //var result = await dialog.Result;
        //if (!result.Cancelled && result.Data != null)
        //{
        //    await GetDataAsync();
        //    StateHasChanged();
        //}

    }

    // Delete
    private async Task Delete(int Id, string Name)
    {
        //await WarehouseService.DeleteAsync(Id);
        //ToastService.ShowWarning($"Warehouse: {Name}. Eliminado");
        //await GetDataAsync();
        //StateHasChanged();
    }

    //// handle panel
    //private async Task HandlePanelAsync(DialogResult result)
    //{
    //    if (result.Cancelled)
    //    {
    //        ToastService.ShowSuccess($"Action Canceled");
    //        return;
    //    }
    //    if (result.Data != null)
    //    {
    //        ToastService.ShowSuccess($"Action manage");
    //        return;
    //    }
    //    ToastService.ShowWarning($"Panel closed");
    //}
}
