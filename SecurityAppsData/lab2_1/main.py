def encode(keyword, message, normalize=False):
    # True - отбрасывать пробелы при шифровании
    if normalize:
        message = ''.join(message.split())

    rows = len(message) // len(keyword)
    if len(message) % len(keyword) != 0:
        rows += 1

    indexes = sorted([(index, value) for index, value in enumerate(keyword)], key=lambda item: item[1])
    result = ''

    for row in range(rows):
        for index in indexes:
            position = index[0] * rows + row
            if position < len(message):
                result += message[position]
            else:
                result += ' '

    return result


def decode(keyword, cipher):
    rows = len(cipher) // len(keyword)
    if len(cipher) % len(keyword) != 0:
        rows += 1

    indexes = sorted([(index, value) for index, value in enumerate(keyword)], key=lambda item: item[1])
    indexes = sorted([(index, value) for index, value in enumerate(indexes)], key=lambda item: item[1][0])
    result = ''

    for index in indexes:
        for row in range(rows):
            position = index[0] + len(keyword) * row
            if position < len(cipher):
                result += cipher[position]

    return result


key = 'ПЕЛИКАН'
text = 'ГОГУЛОВ ЯРОСЛАВ ВОЛОДИМИРОВИЧ'

enc = encode(key, text, True)
print('ENCODE:', enc)
dec = decode(key, enc)
print('DECODE:', dec)
print()
enc = encode(key, text)
print('ENCODE:', enc)
dec = decode(key, enc)
print('DECODE:', dec)