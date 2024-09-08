# -*- coding: utf-8 -*-
"""
Created on Tue Jun  4 18:35:38 2024
länk till videoklipp: https://youtu.be/1d5UNtUypJA
@author: Emelie Wärmlund
"""

import numpy as np
import matplotlib.pyplot as plt

# %% uppgift 1
men_length = np.loadtxt('men_length.txt')
women_length = np.loadtxt('women_length.txt')

mean_men = np.mean(men_length)
a = 0
for x in men_length:
    a += (x-mean_men)**2

men_deviation = np.sqrt(a/len(men_length))

mean_women = np.mean(women_length)
b = 0
for x in women_length:
    b += (x-mean_women)**2

women_deviation = np.sqrt(b/len(women_length))

print('Medellängden för män: ', round(mean_men, 1))
print('Medellängd för kvinnor: ', round(mean_women, 1))
print()
print('Medianlängden för män: ', round(np.median(men_length), 1))
print('Medianlängd för kvinnor: ', round(np.median(women_length), 1))
print()
print('Högsta längd för män: ', round(np.max(men_length), 1))
print('Högsta längd för män: ', round(np.max(women_length), 1))
print()
print('Minsta längd för män: ', round(np.min(men_length), 1))
print('Minsta längd för män: ', round(np.min(women_length), 1))
print()
print('Standardavvikelse för män: ', round(men_deviation, 1))
print('Standardavvikelse för kvinnor: ', round(women_deviation, 1))

fig_men, ax_men = plt.subplots()  # skapa instanserna fig_men och ax_men
fig_women, ax_women = plt.subplots()  # skapa instanserna fig_women och ax_women
# histogram med 20 klasser över mäns längd
ax_men.hist(men_length, 20, edgecolor='black')
# histogram med 20 klasser över kvinnors längd
ax_women.hist(women_length, 20, edgecolor='black')
ax_men.set_xlabel('längd i cm', fontsize=14)  # sätter label för x-axel för män
# sätter label för x-axel för kvinnor
ax_men.set_ylabel('Frekvens', fontsize=14)
# sätter label för x-axel för män
ax_women.set_xlabel('längd i cm', fontsize=14)
# sätter label för x-axel för kvinnor
ax_women.set_ylabel('Frekvens', fontsize=14)
# sätter rubrik på histogram för medellängd för män
ax_men.set_title("Medellängd män i cm")
# sätter rubrik för histogram för medellängd för kvinnor
ax_women.set_title("Medellängd kvinnor i cm")
plt.show()

# %% uppgift 2
age_limit = np.arange(-0.5, 104.6, 5)  # skapar vektor för åldersgrupper
age_mid = np.arange(2, 102.1, 5)  # skapa vektor för åldersmitt
frequency = np.array([286361, 316609, 324475, 315801, 311004, 332023, 399933,
                      367985, 335631, 328040, 334373, 345526, 295365, 269801,
                      250856, 241515, 151369, 73559, 26561, 5256, 476])  # frekvens för antal män i varje åldersgrupp
fig, ax = plt.subplots()
ax.stairs(frequency, age_limit, fill=True)  # skapa histogram via stair
ax.set_xlabel('ålder', fontsize=14)
ax.set_ylabel('frekvens', fontsize=14)
ax.tick_params(labelsize=14)
# justerar y-axel för att visa max 400 000 med frekvens om 50 000
plt.yticks(np.arange(0, 450000, 50000))
plt.show()

mean_age = np.sum(age_mid*frequency)/np.sum(frequency)
print('Medelålder ', round(mean_age, 1))  # visar medelålder
# visar antal män över 70 år. index 14 är för åldersgrupp 70-74
print('Antal män över 70 ', np.sum(frequency[14:]))

# %% uppgift 3a
y = np.loadtxt('signal.txt') #laddar in txt-fil
k = 5 #sätter fönsterstorlek till 5
y_n = np.zeros(len(y)) #skapar en tom array med samma storlek som y
fig, ax = plt.subplots() 
ax.plot(y) #plottar originalsignalen

for i in range(len(y)): #itererar genom signal.txt och beräknar glidande medelvärdet 
    y1 = np.max([0, i-k]) 
    y2 = np.min([len(y), i+k+1])
    y_n[i]=np.mean(y[y1:y2])
    
ax.plot(y_n,'r') #plottar den utjämnade signalkurvan med röd linje
ax.set_xlim([0,len(y)]) #sätter x-axels längde till storleken på y
ax.set_ylabel(r'T i $^o$C',fontsize=14) #sätter y-label
ax.tick_params(labelsize=14)

# %% uppgift 3b
y = np.loadtxt('signal.txt') #laddar in txt-fil
k = 5 #sätter fönsterstorlek till 5
y_n = np.zeros(len(y)) #skapar en tom array med samma storlek som y
fig, ax = plt.subplots() 
ax.plot(y) #plottar originalsignalen

for i in range(len(y)): #itererar genom signal.txt och beräknar glidande medianvärdet
    y1 = np.max([0, i-k]) 
    y2 = np.min([len(y), i+k+1])
    y_n[i]=np.median(y[y1:y2])
    
ax.plot(y_n,'r') #plottar den utjämnade signalkurvan med röd linje
ax.set_xlim([0,len(y)]) #sätter x-axels längde till storleken på y
ax.set_ylabel(r'T i $^o$C',fontsize=14) #sätter y-label
ax.tick_params(labelsize=14)

#%% Uppgift 4
w=lambda m,v: (m*(v**2))/2 #lambdafunktion för att beräkna rörelseenergi
w_list=[] #skapar tom lista att lägga beräknade värden i

#Skapar slumpmässiga värden för massa och hastighet med standardavvikelser
m=5000+100*np.random.randn(100000) 
v=400+70*np.random.randn(100000)
                         
for i in range(100000): #itererar 100000 gånger och beräknar rörelseenergin med de slumpmässiga talen
    w_list.append(w(m[i],v[i])) #beräknade tal läggs i listan

d = 0 #initierar variabel d för standardavvikelse
w_m=np.mean(w_list) #hämtar medeltalet för beräknad rörelseenergi
for x in w_list: #itererar genom alla tal
    d += (x-w_m)**2 

w_deviation = np.sqrt(d/len(w_list)) #beräknar standardavvikelsen

#skriver ut resultat för medelvärde och standardavvikelse
print('Medelvärde är: ',round(np.mean(w_list),1)) 
print('Standardavvikelsen är: ', round(w_deviation,1))

#skapar ett histogram med 20 klasser
fig,ax =plt.subplots() 
ax.hist(w_list,20,edgecolor='black')
ax.set_xlabel('rörelseenergi W', fontsize=14)
ax.set_ylabel('frekvens', fontsize=14)
plt.show()

#%% uppgift 5
a=[-2,-1] #initierar variabel a
b=[2,4] #initierar variabel b

k = (b[1]-a[1])/(b[0]-a[0]) #beräknar k
x = np.linspace(-3,3) #sätter intervall för x
m = a[1] - k*a[0] #beräknar m med hjälp av en av punkterna likt y1 - kx1 = m i kapitel 10.3
y= k*x + m #linjär funktion

fig, ax=plt.subplots() 
plt.scatter([a[0], b[0]], [a[1], b[1]],color='C1') #plottar punkterna
ax.plot(x,y,'b') #plottar linje

#%% uppgift 6
year=np.array([1954,1956,1958,1960,1962,1964,1966,1968,1970]) #lista över år
nesting=np.array([45,33,26,16,10,8,6,6,5]) #lista över häckande par
y=lambda t,r: 45*np.exp(-r*(t-1954)) #lambda funktion
x=np.linspace(1954,1980,100) #skapar grid
r1 = 0.1 #sätter konstant r 0.1
r3= 0.3 #sätter konstant r 0.3
r=0.17 #sätter anpassad konstant efter tester av flera olika värden på r

fig1, ax1 =plt.subplots()
plt.scatter(year,nesting) #skapa scatter plot av värden
ax1.plot(x,y(x,r1), color='C1') #skapar en beräknad linje med det beräknade värdet och r= 0.1
plt.title("r=0.1")
ax.set_xlabel('År', fontsize=14) #sätter label för x-axel
ax.set_ylabel('Antal', fontsize=14) #sätter label för y-axel

fig3, ax3 =plt.subplots()
plt.scatter(year,nesting) #skapa scatter plot av värden
plt.title("r=0.3")
ax3.plot(x,y(x,r3), color='C1') #skapar en beräknad linje med det beräknade värdet och r = 0.3
ax.set_xlabel('År', fontsize=14) #sätter label för x-axel
ax.set_ylabel('Antal', fontsize=14) #sätter label för y-axel

fig, ax=plt.subplots()
plt.scatter(year,nesting) #skapa scatter plot av värden
plt.title("r=0.17")
ax.plot(x,y(x,r), color='C1') #skapar en beräknad linje med det beräknade värdet och r = 0.17
ax.set_xlabel('År', fontsize=14) #sätter label för x-axel
ax.set_ylabel('Antal', fontsize=14) #sätter label för y-axel

#beräkning av år då häckande par är mindre än 1
y_values = y(x,r) #hämtar samtliga y-värden i en array
exstintion_year = x[y_values<1][0] #hämtar första värdet i x-array då y-värdet är under 1, dvs utdöd
print(f'År då artantal är mindre än 1 (utdöd): {round(exstintion_year,0)}') #skriver ut resultatet