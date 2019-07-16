import { TestBed, inject } from '@angular/core/testing';

import { $className$ } from './$importFileName$';

describe('$className$', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [$className$]
        });
    });

    it('should be created', inject([$className$], (service: $className$) => {
        expect(service).toBeTruthy();
    }));
});
