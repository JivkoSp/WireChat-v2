// Get the current DateTimeOffset string
function getCurrentDateTimeOffset() {
    const now = new Date();
    const offset = -now.getTimezoneOffset();
    const offsetHours = Math.floor(Math.abs(offset) / 60);
    const offsetMinutes = Math.abs(offset) % 60;
    const offsetSign = offset >= 0 ? '+' : '-';
    const pad = (num) => num.toString().padStart(2, '0');

    const formattedOffset = `${offsetSign}${pad(offsetHours)}:${pad(offsetMinutes)}`;
    const dateTimeOffset = `${now.toISOString().split('.')[0]}${formattedOffset}`;

    return dateTimeOffset;
}
