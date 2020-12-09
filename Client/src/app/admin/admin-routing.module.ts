import { SearchClientComponent } from './components/search-client/search-client.component';
import { AddpromotionModuleComponent } from './components/addpromotion-module/addpromotion-module.component';
import { AddArticleModuleComponent } from './components/add-article-module/add-article-module.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'addArticle', component: AddArticleModuleComponent },
  { path: 'addPromotion', component: AddpromotionModuleComponent },
  { path: 'searchClient', component: SearchClientComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

