import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AstreaSettings } from './astrea-settings';

describe('AstreaSettings', () => {
  let component: AstreaSettings;
  let fixture: ComponentFixture<AstreaSettings>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AstreaSettings]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AstreaSettings);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
