# -*- coding: utf-8 -*-
"""
Created on Tue Jun  4 09:40:08 2024

@author: Emelie Wärmlund
länk till videoklipp: https://youtu.be/e1mfS192dCM
"""
import numpy as np
import matplotlib.pyplot as plt

#%% uppgift 1a
x=np.linspace(0,10) #variabel med x-värden
x = np.linspace(0,10) # vektor med x-värden
f = x/(x+1) # initierar variabel f
g=x**2/(1+x**2) #initierar variabel g
fig, ax = plt.subplots() # skapa instanserna fig och ax
ax.plot(x,f,'g--',g,'r') #plottar varaibel f och g mot x. f är satt som grön streckad linje och g är satt som röd heldragen linje
ax.tick_params(labelsize=10) # sätt storlek på labeletiketter

#uppgift 1b
x = np.linspace(0,10) # vektor med x-värden
f = x/(x+1) # initierar variabel f
g=x**2/(1+x**2) #initierar variabel g
fig, ax = plt.subplots() # skapa instanserna fig och ax
ax.plot(x,f,'g--') #plottar varaibel f mot x. f är satt som grön streckad linje
ax.plot(x,g,'r') #plottar varaibel g mot x. g är satt som röd heldragen linje
ax.tick_params(labelsize=10) # sätt storlek på labeletiketter

#%% uppgift 1b
x=np.linspace(0,10) #varaibel med x-värden
f = x/(x+1) # initierar variabel f
g=x**2/(1+x**2) #initierar variabel g
fig, ax = plt.subplots() # skapa instanserna fig och ax
ax.plot(x,f,'g--') #plottar varaibel f mot x. f är satt som grön streckad linje
ax.plot(x,g,'r') #plottar varaibel g mot x. g är satt som röd heldragen linje
ax.tick_params(labelsize=10) # sätt storlek på labeletiketter
ax.grid('on') #visar rutnät
ax.spines['top'].set_visible(False) #döljer ramen högst upp
ax.spines['right'].set_visible(False) #döljer ramen till höger

#%% uppgift 2

x=np.linspace(1790,1960) #variabel med x-värden
n=(197273000/(1+np.exp(-0.03134*(x-1913.25)))) #funktion n för y-värden
t=[x for x in range(1790,1970,10)] #komprimerad forloop som skapar en lista av alla år i 10 årsintervall
u=[3929000,5308000,7240000,9638000,12866000,17069000,23192000,31443000,38558000,
   50156000,62948000,75995000,91972000,105711000,122775000,131669000,150697000,179323000] #lista över alla värden i tabellen över befolkningsmängd
fig, ax=plt.subplots() # skapa instanserna fig och ax
ax.plot(x,n,'C1') #plottar variabler x och n 
ax.grid('on') #visar grid
ax.set_xlabel('År',fontsize=14) #sätter label för x-axel till år
ax.set_ylabel('Befolkningsstorlek',fontsize=14) #sätter label för y-axel
plt.scatter(t,u) #skapar en scatter plot för datan
plt.yticks(np.arange(0,2*(10**8),0.25*(10**8))) #ändrar intervall för y-axeln min är 0 och max är 2e8 med ett intervall på 0.25e8
plt.title('Befolkningsutveckling i USA, 1790-1960') #sätter titel
plt.show() #visar plot

#%% upppgift 3a
T=np.loadtxt('T10365.txt' ) #laddar in dokument
fig, ax = plt.subplots() # skapa instanserna fig och ax
ax.hist(T[0,:],15,edgecolor='black') # histogram med 15 klasser för 
ax.tick_params(labelsize=14) #sätter label storlek till 14
ax.set_xlabel('temperatur år 1981',fontsize=14) #sätter label för x-axel till år
ax.set_ylabel('Frekvens',fontsize=14) #sätter label för y-axel
plt.show() #visar plot

#%% uppgift 3b
T=np.loadtxt('T10365.txt' )
fig, ax = plt.subplots()
ax.hist(T[4,:],15,edgecolor='black') # histogram med 15 klasser över rad index fyra i matris
ax.tick_params(labelsize=14) # skapa instanserna fig och ax
ax.set_xlabel('temperatur år 1985',fontsize=14) #sätter label för x-axel till år
ax.set_ylabel('Frekvens',fontsize=14) #sätter label för y-axel
plt.show() #visar plot

#%% uppgift 4
a=float(input('ange värde a:')) #input för värde a
b=float(input('ange värde b: ')) #input för värde b

if b ==0: #if-sats om b=0
    print('Division med noll är ej tillåtet') #skriver meddelande om att division med noll är inte tillåtet

else: #else-sats om b inte är noll
    print('a/b är: ',a/b) #skriver resultat för a/b

    
#%% uppgift 5a och 5b
T=np.loadtxt('CCD.txt') #laddar textdokument
fig, ax = plt.subplots() # skapa instanserna fig och ax
plt.imshow(T,vmin=3,vmax=7,cmap='gray') #skapar mönster
plt.show() #visar mönster

#%% uppgift 5c och 5d
T=np.loadtxt('CCD.txt') #laddar textdokument
m=lambda i,j: (T[i-1,j-1]+T[i-1,j]+T[i-1,j+1]+T[i,j-1]+T[i,j+1]+T[i+1,j-1]+T[i+1,j]+T[i+1,j+1])/8 #skapar lambdauttryck för att beräkna medelvärde

for i in range(len(T)): #loopar genom första skalären
    for j in range(len(T[i])): #loopar genom andra skalären
        if T[i][j]==0: #if-sats för att se om värdet är 0
            T[i][j]=m(i,j) #om värdet är 0 ersätts det med ett medelvärde
            
plt.imshow(T,vmin=3,vmax=7,cmap='gray') #skapar mönster
plt.show() #visar mönster

#%% uppgift 6
import numpy as np
import matplotlib.pyplot as plt
fig,ax = plt.subplots()
A = plt.imread('havsorn_PO.jpg') # läs bild och spara i A
A = A.astype(dtype='float') # obs, omvandla från uint8 till flyttal
RGB = [1,122,195] # blå färg
RGBNY = [255,192,203] # ny färg, ljus rosa
(m,n,o) = A.shape # dimensionerna på bilden, m antal rader # n antalet kolonner, o djupet
for i in range(m): # loopa över rader och kolonner
    for j in range(n):
        a = (A[i,j,0]-RGB[0])**2 + (A[i,j,1]-RGB[1])**2 + \
            (A[i,j,2]-RGB[2])**2
        b = RGB[0]**2 + RGB[1]**2 + RGB[2]**2
        dist = np.sqrt(a/b) # relativt färgavstånd
        if dist > 0.1: # om färgavstånd stort, byt ut färgen
            A[i,j,:] = RGBNY # samma som A[i,j,0] = RGBNY[0],
            # A[i,j,1] = RGBNY[1] och A[i,j,2] = RGBNY[2]
A = A.astype(dtype='int') # måste omvandla till heltal innan vi visar
ax.imshow(A) # visa modifierad bild
ax.axis('equal')
ax.axis('off')

