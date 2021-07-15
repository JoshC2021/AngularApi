/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ListdonutsComponent } from './listdonuts.component';

let component: ListdonutsComponent;
let fixture: ComponentFixture<ListdonutsComponent>;

describe('listdonuts component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ListdonutsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ListdonutsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});