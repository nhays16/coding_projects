# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models
from dateutil.parser import parse
from datetime import datetime
import re
import bcrypt
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')


class UserManager(models.Manager):
    def validator(self, postData):
        errors = {}
        for key in postData:
            if postData[key] == '':
                errors['empty_field'] = 'All fields are required for registration'
        if len(postData['first_name']) < 3 or not postData['first_name'].isalpha():
            errors['fname'] = 'Your first name must be at least 3 characters and contain only letters'
        if len(postData['last_name']) < 3 or not postData['last_name'].isalpha():
            errors['lname'] = 'Your last name must be at least 3 characters and contain only letters'
        if len(postData['alias']) < 3:
            errors['alias'] = 'Your username must be at least 3 characters'
        if not EMAIL_REGEX.match(postData['email']):
            errors['email'] = 'You must provide a valid email address'
        if len(postData['password']) < 8 or len(postData['confirm']) < 8:
            errors['password'] = 'You must provide a password that is at least 8 characters'
        if postData['password'] != postData['confirm']:
            errors['match'] = 'Your passwords do not match'
    
        return errors
    def password_hash(self, pwd):
        password = bcrypt.hashpw(pwd.encode(), bcrypt.gensalt())
        return password
    
    def login_validator(self, postData):
        errors = {}
        for key in postData:
            if postData[key] == '':
                errors['empty_field'] = 'All fields are required for login'
        try:
            user = User.objects.get(email=postData['email'])
        except:
            user = None
        if User:
            try:
                if not bcrypt.checkpw(postData['password'].encode(), user.password.encode()):
                    errors['loginfail'] = 'Login info does not match database- please try again or please register'
            except:
                errors['loginfail'] = 'Login info does not match database- please try again or please register'
            return errors

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    alias = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    birthday = models.DateField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = UserManager()
