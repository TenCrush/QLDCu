import { BsDatepickerConfig, BsDaterangepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxBootstrapLocaleMappingService } from 'assets/ngx-bootstrap/ngx-bootstrap-locale-mapping.service';
import { defineLocale } from 'ngx-bootstrap/chronos';

export class NgxBootstrapDatePickerConfigService {

    static getDaterangepickerConfig(): BsDaterangepickerConfig {
        return Object.assign(new BsDaterangepickerConfig(), {
        });
    }

    static getDatepickerConfig(): BsDatepickerConfig {
        return Object.assign(new BsDatepickerConfig(), {});
    }

    static getDatepickerLocale(): BsLocaleService {
        let localeService = new BsLocaleService();
        return localeService;
    }

    static registerNgxBootstrapDatePickerLocales(): Promise<boolean> {
        let supportedLocale = "vi";
        let moduleLocaleName = "vi";
        return new Promise<boolean>((resolve, reject) => {
            import(`ngx-bootstrap/chronos/esm5/i18n/${supportedLocale}.js`)
                .then(module => {
                    defineLocale(abp.localization.currentLanguage.name.toLowerCase(), module[`${moduleLocaleName}Locale`]);
                    resolve(true);
                }, reject);
        });
    }
}
