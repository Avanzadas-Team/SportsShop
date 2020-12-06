import { HttpService } from './../../../http.service';
import { Component, OnInit } from '@angular/core';
import { ConvertPropertyBindingResult } from '@angular/compiler/src/compiler_util/expression_converter';
import { Observable, Subscriber } from 'rxjs';

@Component({
  selector: 'app-add-article-module',
  templateUrl: './add-article-module.component.html',
  styleUrls: ['./add-article-module.component.scss']
})
export class AddArticleModuleComponent implements OnInit {

  constructor(private service: HttpService) { }

  aname : string;

  brand : string;

  price : number;

  sport : string;

  edition :string;

  stock :number;

  sports: string[] = [];

  image : Observable<any>;

  imageSelected : string;

  type: number;

  edit: boolean;

  info;

  response;

  ngOnInit(): void {
  }

  addSport(){
    this.sports.push(this.sport);
  }

  onEditionChange(){
    if(this.edition == "Yes"){
      this.edit = true;
    }else{
      this.edit = false;
    }
  }

  onChange($event: Event) {
    const file = ($event.target as HTMLInputElement).files[0];
    
    this.convertToBase64(file);
  }

  convertToBase64(file: File) {
    this.image = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    });const observable = new Observable((subscriber: Subscriber<any>) => { this.readFile(file, subscriber) });
    observable.subscribe((d) => {
      this.imageSelected = d;
    });
  }

  readFile(file: File, subscriber: Subscriber<any>) {
    const filereader = new FileReader();
    filereader.readAsDataURL(file);

    filereader.onload = () => {
      subscriber.next(filereader.result);
      subscriber.complete();
    };
    filereader.onerror = (error) => {
      subscriber.error(error);
      subscriber.complete();
    };
  }

  addArticle(){

    this.info = {
      name: this.aname,
      marca: this.brand,
      precio: this.price,
      deportes: this.sports,
      edicionLim: this.edit,
      tipo: Number(this.type),
      unDisp: this.stock,
      imagen: this.imageSelected
    }
    var formData = new FormData();
    formData.append('image',this.imageSelected);
    console.log(this.imageSelected);
    console.log(formData.get('file'));
    this.service.postArticle(this.info);
  }
}
