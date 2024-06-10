
// <div class="main_field" style={{ unselected: {display: none,visibility: hidden,}}}>
//     <div class="filter">
//         <div class="prop">
//             <div class="input-group mb-3">
//                 <form method="post" asp-action="Search">
//                     <input id="search_prop" type="text" name="request"  class="form-control" placeholder="Search by title" aria-label="Recipient's username" aria-describedby="button-addon2" list="list">
//                     <button class="btn btn-success" style="    margin-top: 10px;" type="submit" id="button-addon2" onclick="FindByTitle()">Search</button>
//                 </form>
//                 <a class="btn btn-secondary" style="margin-left: 80px;border-radius: 5px;margin-top: -38px;" href="/Order/OrdersList">View All Orders</a>
//                 <datalist id="list">
//                     @if (Model.Any())
//                         @foreach (var option in Model)
//                         {
//                             <option value="@option.Name"></option>
//                         }
//                 </datalist>
//             </div>

//             <div class="prop_seperator"></div>

//             <div class="prop_header">Diffacalty:</div>
//             <ul style="list-style-type: none; margin: 0; padding-left: 10px;">
//                 <li class="prop_option">
//                     <input class="form-check-input" type="checkbox" value="" id="cb_unpossible" style="accent-color: #282c2c;">
//                     <label class="form-check-label prop_label" for="flexCheckDefault">
//                         Unpossible
//                     </label>
//                 </li>
//                 <li class="prop_option">
//                     <input class="form-check-input" type="checkbox" value="" id="cb_hard">
//                     <label class="form-check-label prop_label" for="flexCheckDefault">
//                         Hard
//                     </label>
//                 </li>
//                 <li class="prop_option">
//                     <input class="form-check-input" type="checkbox" value="" id="cb_middle">
//                     <label class="form-check-label prop_label" for="flexCheckDefault">
//                         Middle
//                     </label>
//                 </li>
//                 <li class="prop_option">
//                     <input class="form-check-input" type="checkbox" value="" id="cb_normal">
//                     <label class="form-check-label prop_label" for="flexCheckDefault">
//                         Normal
//                     </label>
//                 </li>
//                 <li class="prop_option">
//                     <input class="form-check-input" type="checkbox" value="" id="cb_easy">
//                     <label class="form-check-label prop_label" for="flexCheckDefault">
//                         Easy
//                     </label>
//                 </li>
//                 <li class="prop_option">
//                     <button onclick="SetAll()" class="btn btn-secondary" id="cb_all">View All</button>
//                 </li>
//             </ul>
//             <button type="button" class="btn btn-secondary prop_btn_clear" onclick="Clear()">Clear</button>
//             <button type="button" class="btn btn-primary prop_btn_apply" onclick="ViewOrdersByDiff()">Apply</button>
//         </div>
//     </div>
//     <div class="orders" id="orderCards">

//             // @foreach (var item in Model)
//             // {
//                 <div class="order_card">
//                     <div style="color:#fff; margin:5px;">@((Statuses)item.Status)</div>
//                     <div class="card_left">
//                         <h1 class="card_header">@item.Name</h1>
//                         <a class="card_user" href="/Account/ShowUser/@item.CreatorId">Show owner</a>
//                         <div class="card_description">
//                             @item.MainTask
//                         </div>
//                         <div class="card_helper">
//                             <p>Posted @item.PostDate</p>
//                             <div style="display: flex; flex-direction: row; margin-left: 50px;">
//                                 @if (string.IsNullOrEmpty(item.DbLink))
//                                 {
//                                     <svg xmlns="http://www.w3.org/2000/svg" style="margin-top: 3px" width="18" height="18" fill="darkred" class="bi bi-plus-square-fill" viewBox="0 0 16 16">

//                                         <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2zm2.5 7.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1" />}
//                                     </svg>
//                                 }
//                                 else
//                                 {
//                                     <svg xmlns="http://www.w3.org/2000/svg" style="margin-top: 3px" width="18" height="18" fill="forestgreen" class="bi bi-plus-square-fill" viewBox="0 0 16 16">
//                                         <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2zm6.5 4.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3a.5.5 0 0 1 1 0" />}
//                                     </svg>
//                                 }
//                                 <p style="font-weight: bold; margin-left: 5px;">Data Base</p>
//                             </div>
//                             <div style="display: flex; flex-direction: row; margin-left: 20px;">
//                                 @if (string.IsNullOrEmpty(item.ExampleLink))
//                                 {
//                                     <svg xmlns="http://www.w3.org/2000/svg" style="margin-top: 3px" width="18" height="18" fill="darkred" class="bi bi-plus-square-fill" viewBox="0 0 16 16">

//                                         <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2zm2.5 7.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1" />}
//                                     </svg>
//                                 }
//                                 else
//                                 {
//                                     <svg xmlns="http://www.w3.org/2000/svg" style="margin-top: 3px" width="18" height="18" fill="forestgreen" class="bi bi-plus-square-fill" viewBox="0 0 16 16">
//                                         <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2zm6.5 4.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3a.5.5 0 0 1 1 0" />}
//                                     </svg>
//                                 }
//                                 <p style="font-weight: bold; margin-left: 5px;">Reference</p>
//                             </div>
//                         </div>
//                         @if (ViewBag.Role == "Admin")
//                         {
//                             <a class="btn btn-primary" asp-action="EditOrder" asp-route-id="@item.Id">Edit</a>
//                             <a asp-action="DeleteOrder" asp-route-id="@item.Id" class="btn btn-danger">Delete</a>
//                         }
//                     </div>
//                     <div class="card_right">
//                         <div class="diff text_difficalty_@((Difficuties)item.Difficulty)">@((Difficuties)item.Difficulty)</div>
//                         <button type="button" onclick="redirect(@item.Id)" class="btn btn-primary card_btn">View</button>
//                     </div>
//                 </div>
//             // }


//             // <div style="margin: 50px;color: #FFF;">
//             //     <h2> Ще не створено Замовлень </h2>
//             // </div>
        


//     </div>
// </div>