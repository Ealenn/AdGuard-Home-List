import { Injectable } from '@nestjs/common';
const IP_REGEX = new RegExp('^([0–9]{1,3}.){3}.([0–9]{1,3})$');

const IGNORE_HOST_START = ['0.0.0.0', '127.0.0.1', '::1'];

@Injectable()
/**
 * @see https://kb.adguard.com/en/general/how-to-create-your-own-ad-filters
 */
export class AdguardRuleService {
  public FromUrlOrIp(value: string, allowRule: boolean): string {
    value = value.split('#')[0].split('!')[0].trim();

    for (const hostStart of IGNORE_HOST_START) {
      if (value.startsWith(hostStart)) {
        value = value.slice(hostStart.length).trim();
      }
    }

    if (value === '') {
      return null;
    }

    if (value.match(IP_REGEX)) {
      if (allowRule) {
        return `@@${value}$network`;
      } else {
        return `${value}$network`;
      }
    }

    if (allowRule) {
      return `@@||${value}^$important`;
    } else {
      return `||${value}^`;
    }
  }

  public FromAdGuard(value: string): string {
    value = value.split('#')[0].split('!')[0].trim();
    if (value === '') {
      return null;
    }
    return value;
  }
}
