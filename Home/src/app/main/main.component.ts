import { Component, Injector , OnInit } from '@angular/core';
import { Observable } from 'rxjs-compat';
import { BaseComponent } from '../Services/base-component';

@Component({
  selector: 'app-main' + 'date-pipe' ,
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent extends BaseComponent implements OnInit {
  bt1:any;                                                 btpl:any;
  bt_new1:any;                                             bt_newpl:any;
  bt2:any;                                                 btvl:any;
  bt_new2:any;                                             bt_newvl:any;
  bt3:any;                                                 btgd:any;
  bt_new3:any;                                             bt_newgd:any;
  bt4:any;
  bt_new4:any;
  bt5:any;
  bt_new5:any;
  btds:any;
  bt_newds:any;
  btdl:any;
  bt_newdl:any;
  bttt:any;
  bt_newtt:any;
  btds1: any;
  bt_newds1: any;
  today: number = Date.now();
  constructor(injector : Injector) { 
    super(injector);
   }
  ngOnInit(): void {
    this.bt2=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new2'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt2 = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new2'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_new2 = res[0];
      
    }, err => {});

    this.bt1=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new1'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt1 = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new1'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_new1 = res[0];
    }, err => {});

    this.bt3=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new3'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt3 = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new3'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_new3 = res[0];
    }, err => {});

    this.bt4=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new4'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt4 = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new4'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_new4 = res[0];
    }, err => {});

    this.bt5=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new5'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt5 = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-new5'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_new5 = res[0];
    }, err => {});

    this.btds=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newdoisong'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.btds = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newdoisong'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_newds = res[0];
    }, err => {});

    this.btds1=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newdoisong1'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.btds1 = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newdoisong1'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_newds1 = res[0];
    }, err => {});

    this.btdl=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newdulich'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.btdl = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newdulich'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_newdl = res[0];
    }, err => {});

    this.bttt=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newthethao'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bttt = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newthethao'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_newtt = res[0];
    }, err => {});

    this.btpl=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newphapluat'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.btpl = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newphapluat'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_newpl = res[0];
    }, err => {});

    this.btvl=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newvieclam'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.btvl = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newvieclam'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_newvl = res[0];
    }, err => {});

    this.btgd=[];
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newgiaoduc'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.btgd = res[0];
    }, err => {});
    Observable.combineLatest(
      this._api.get('api/bangtin/get-newgiaoduc'),
    ).takeUntil(this.unsubscribe).subscribe(res => {
      this.bt_newgd = res[0];
    }, err => {});
}
}
