import { TestBed } from '@angular/core/testing';
import { BaseService } from './base-service.service';
import { Base } from '../../Models/Base';



describe('BaseServiceService', () => {
  let service: BaseService<Base>;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
